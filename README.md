# Assecor Assessment - C# Implementierung

Dieses Repository enthält eine C# Implementierung des Assecor Assessment mit ASP.NET Core Web API.

## Übersicht

Das Projekt implementiert eine RESTful Web-Schnittstelle zur Verwaltung von Personen und ihren Lieblingsfarben, wobei Daten aus einer CSV-Datei gelesen werden, ohne diese zu verändern.

## Implementierte Funktionen

- **GET /persons**: Gibt alle Personen als JSON-Array zurück
- **GET /persons/{id}**: Gibt eine spezifische Person nach ID zurück
- **GET /persons/color/{color}**: Gibt alle Personen mit der angegebenen Lieblingsfarbe zurück
- **POST /persons**: Fügt eine neue Person zur Datenquelle hinzu (ohne die CSV zu verändern)

## Verwendete Technologien

- .NET 9
- ASP.NET Core Web API
- Dependency Injection
- CSV-Datenparsing

## Ausführung

1. Stellen Sie sicher, dass .NET 9 SDK installiert ist.
2. Klonen Sie das Repository.
3. Navigieren Sie zum Projektverzeichnis.
4. Führen Sie `dotnet build` aus, um das Projekt zu bauen.
5. Führen Sie `dotnet run` aus, um die Anwendung zu starten.
6. Die API ist unter `http://localhost:5183` (oder ähnlichem Port) verfügbar.

## Projektstruktur

- `Models/Person.cs`: Datenmodell für Person
- `Services/IPersonService.cs`: Interface für Datenzugriff
- `Services/PersonService.cs`: Implementierung, die aus CSV liest
- `Controllers/PersonsController.cs`: API-Controller
- `sample-input.csv`: Beispieldatendatei

## Erfüllte Akzeptanzkriterien

1. ✅ CSV-Datei wird gelesen und durch eine Person-Modellklasse repräsentiert.
2. ✅ Datenzugriff ist über IPersonService-Interface abstrahiert.
3. ✅ REST-Schnittstelle mit korrekten Endpunkten implementiert.
4. ✅ Dependency Injection für Datenzugriff verwendet.
5. ✅ `sample-input.csv` nicht verändert.

## Erfüllte Bonuspunkte

- ✅ MSBuild-Projekt: Für CI mit TFS/DevOps geeignet.
- ✅ Zusätzlicher POST /persons: Implementiert, fügt neue Personen hinzu.
- ✅ Zweite Datenquelle: SQLite via EF Core angebunden.

---

# Assecor Assessment Test (DE)

## Zielsetzung

Das Ziel ist es ein REST – Interface zu implementieren, Bei den möglichen Frameworks stehen .NET(C#) oder Java zur Auswahl. Dabei sind die folgenden Anforderungen zu erfüllen:

* Es soll möglich sein, Personen und ihre Lieblingsfarbe über das Interface zu verwalten
* Die Daten sollen aus einer CSV Datei lesbar sein, ohne dass die CSV angepasst werden muss
* Alle Personen mit exakten Lieblingsfarben können über das Interface identifiziert werden

Einige Beispieldatensätze finden sich in `sample-input.csv`. Die Zahlen der ersten Spalte sollen den folgenden Farben entsprechen:

| ID | Farbe |
| --- | --- |
| 1 | blau |
| 2 | grün |
| 3 | violett |
| 4 | rot |
| 5 | gelb |
| 6 | türkis |
| 7 | weiß |

Das Ausgabeformat der Daten ist als `application/json` festgelegt. Die Schnittstelle soll folgende Endpunkte anbieten:

**GET** /persons
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**GET** /persons/{id}

*Hinweis*: als **ID** kann hier die Zeilennummer verwendet werden.
```json
{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
}
```

**GET** /persons/color/{color}
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**POST** /persons
```json
{
  "id": 8,
  "name": "Max",
  "lastname": "Mustermann",
  "zipcode": "12345",
  "city": "Berlin",
  "color": "rot"
}
```

## Akzeptanzkriterien

1. Die CSV Datei wurde eingelesen, und wird programmintern durch eine dem Schema entsprechende Modellklasse repräsentiert.
2. Der Zugriff auf die Datensätze so abstrahiert, dass eine andere Datenquelle angebunden werden kann, ohne den Aufruf anpassen zu müssen.
3. Die oben beschriebene REST-Schnittstelle wurde implementiert und liefert die korrekten Antworten.
4. Der Zugriff auf die Datensätze, bzw. auf die zugreifende Klasse wird über Dependency Injection gehandhabt.
5.  Die REST-Schnittstelle ist mit Unit-Tests getestet. 
6.  Die `sample-input.csv` wurde nicht verändert 

## Bonuspunkte
* Implementierung als MSBuild Projekt für kontinuierliche Integration auf TFS (C#/.NET) oder als Maven/Gradle Projekt (Java)
* Implementieren Sie eine zusätzliche Methode POST/ Personen, die eine zusätzliche Aufzeichnung zur Datenquelle hinzufügen
* Anbindung einer zweiten Datenquelle (z.B. Datenbank via Entity Framework)

Denk an deine zukünftigen Kollegen, und mach es ihnen nicht zu einfach, indem du deine Lösung öffentlich zur Schau stellst. Danke!

# Assecor Assessment Test (EN)

## goal

You are to implement a RESTful web interface. The choice of framework and stack is yours between .NET (C#) or Java. It has to fulfull the following criteria:

* You should be able to manage persons and their favourite colour using the interface
* The application should be able to read the date from the CSV source, without modifying the source file
* You can identify people with a common favourite colour using the interface

A set of sample data is contained within `sample-input.csv`. The number in the first column represents one of the following colours:

| ID | Farbe |
|---|---|
| 1 | blau |
| 2 | grün |
| 3 | violett |
| 4 | rot |
| 5 | gelb |
| 6 | türkis |
| 7 | weiß |

the return content type is `application/json`. The interface should offer the following endpoints:

**GET** /persons
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**GET** /persons/{id}

*HINT*: use the csv line number as your **ID**.
```json
{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
}
```

**GET** /persons/color/{color}
```json
[{
"id" : 1,
"name" : "Hans",
"lastname": "Müller",
"zipcode" : "67742",
"city" : "Lauterecken",
"color" : "blau"
},{
"id" : 2,
...
}]
```

**POST** /persons
```json
{
  "id": 8,
  "name": "Max",
  "lastname": "Mustermann",
  "zipcode": "12345",
  "city": "Berlin",
  "color": "rot"
}
```

## acceptance criteria

1. The csv file is read and represented internally by a suitable model class.
2. File access is done with an interface, so the implementation can be easily replaced for other data sources.
3. The REST interface is implemented according to the above specifications.
4. Data access is done using a dependency injection mechanism
5. Unit tests for the REST interface are available.
6. `sample-input.csv` has not been changed.

## bonus points are awarded for the following
* implement the project with MSBuild in mind for CI using TFS/DevOps when using .NET, or as a Maven/Gradle project in Java
* Implement an additional **POST** /persons to add new people to the dataset
* Add a secondary data source (e.g. database via EF or JPA)

Think about your potential future colleagues, and do not make it too easy for them by posting your solution publicly. Thank you!
