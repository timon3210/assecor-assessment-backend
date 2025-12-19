using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace AssecorAssessment;

public class PersonService : IPersonService
{
    private readonly PersonDbContext _context;
    private readonly Dictionary<int, string> _colorMap = new()
    {
        {1, "blau"},
        {2, "grün"},
        {3, "violett"},
        {4, "rot"},
        {5, "gelb"},
        {6, "türkis"},
        {7, "weiß"}
    };

    private class CsvRow
    {
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Address { get; set; }
        public string? ColorId { get; set; }
    }

    public PersonService(PersonDbContext context)
    {
        _context = context;
        LoadData();
    }

    private void LoadData()
    {
        _context.Database.EnsureCreated();
        if (_context.Persons.Any()) return;

        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample-input.csv");
        var lines = File.ReadAllLines(path);
        var fixedLines = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (line.EndsWith(", ") && i + 1 < lines.Length && lines[i + 1].Length > 0 && char.IsDigit(lines[i + 1][0]))
            {
                line += lines[i + 1];
                i++; // skip next line
            }
            fixedLines.Add(line);
        }
        var csvText = string.Join(Environment.NewLine, fixedLines);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            MissingFieldFound = null
        };
        using (var reader = new StringReader(csvText))
        using (var csv = new CsvReader(reader, config))
        {
            var records = csv.GetRecords<CsvRow>().ToList();
            var persons = new List<Person>();
            for (int i = 0; i < records.Count; i++)
            {
                var record = records[i];
                var lastname = record.Lastname!;
                var firstname = record.Firstname!;
                var address = record.Address!;

                string color;
                int colorId = int.Parse(record.ColorId!);
                color = _colorMap[colorId];

                string zipcode = address.Substring(0, 5);
                string city = address.Substring(6);

                persons.Add(new Person
                {
                    Name = firstname,
                    Lastname = lastname,
                    Zipcode = zipcode,
                    City = city,
                    Color = color
                });
            }
            _context.Persons.AddRange(persons);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Person> GetAll() => _context.Persons;

    public Person? GetById(int id) => _context.Persons.FirstOrDefault(p => p.Id == id);

    public IEnumerable<Person> GetByColor(string color) => _context.Persons.Where(p => p.Color == color);

    public void Add(Person person)
    {
        person.Id = 0; // EF Core generiert eine neue auto-increment ID
        _context.Persons.Add(person);
        _context.SaveChanges();
    }
}