# Serializers

A C# console application that demonstrates **JSON and XML serialization and deserialization** using reusable helper classes.

## Features

- Collects student information from console input.
- Saves a `Student` object as either JSON or XML.
- Loads the saved data back into a `Student` object.
- Provides reusable generic helper methods for serialization and deserialization.
- Supports synchronous file operations and asynchronous file operations in the helper classes.
- Formats JSON output for readability and XML output with indentation.

## Technologies

- C#
- .NET
- `System.Text.Json` for JSON serialization
- `System.Xml.Serialization` and `System.Xml` for XML serialization

## Project structure

```text
Serializers/
├── Helpers/
│   ├── JsonHelper.cs
│   └── XmlHelper.cs
├── Models/
│   └── Student.cs
├── Program.cs
├── Serializers.csproj
└── Serializers.sln
```

## How it works

1. The application asks for the student's ID, name, age, and grade.
2. It creates a `Student` object from the entered values.
3. You choose an output format:
   - `1` — JSON
   - `2` — XML
4. The application saves the student data to a file.
5. It reads the file back and displays the loaded student's name.

### Example

```text
Enter student ID: 1
Enter student name: Alex
Enter student age: 20
Enter student grade: 95

Choose format:
1. JSON
2. XML
Your choice: 1
Student saved to JSON.
Loaded: Alex
```

The example above illustrates the console flow; actual input and output depend on the values entered.

## Helper classes

### `JsonHelper`

Uses `System.Text.Json` and provides generic methods:

| Method | Purpose |
|---|---|
| `Serialize<T>(T data)` | Converts an object to a JSON string. |
| `Deserialize<T>(string json)` | Converts a JSON string to an object. |
| `SaveToFile<T>(string path, T data)` | Serializes an object and writes it to a file. |
| `LoadFromFile<T>(string path)` | Reads a file and deserializes its JSON content. |
| `SaveToFileAsync<T>(string path, T data)` | Asynchronously serializes an object to a file stream. |
| `LoadFromFileAsync<T>(string path)` | Asynchronously reads and deserializes JSON from a file stream. |

JSON serialization is configured to use indented output and case-insensitive property-name matching during deserialization.

### `XmlHelper`

Uses `System.Xml.Serialization` and provides generic methods:

| Method | Purpose |
|---|---|
| `Serialize<T>(T data)` | Converts an object to an XML string. |
| `Deserialize<T>(string xml)` | Converts an XML string to an object. |
| `SaveToFile<T>(string path, T data)` | Serializes an object and writes it to a file. |
| `LoadFromFile<T>(string path)` | Reads a file and deserializes its XML content. |
| `SaveToFileAsync<T>(string path, T data)` | Serializes an object to a file stream using an asynchronous file stream and XML writer. |
| `LoadFromFileAsync<T>(string path)` | Deserializes an object from an asynchronously opened file stream. |

XML output is configured with indentation.

### `Student`

The model contains these properties:

- `Id` — `int`
- `Name` — `string`
- `Age` — `int`
- `Grade` — `double`

## Run the project

Make sure the .NET SDK required by `Serializers.csproj` is installed.

From the directory containing `Serializers.sln`, run:

```bash
dotnet restore
dotnet run --project Serializers.csproj
```

Alternatively, open `Serializers.sln` in Visual Studio and run the `Serializers` project.

## Output files

Depending on the selected format, the application creates or overwrites one of these files in its working directory:

- `student.json`
- `student.xml`

## Learning goals

This project is useful for practicing:

- JSON and XML serialization/deserialization
- Generic methods in C#
- Working with files and streams
- Synchronous and asynchronous I/O
- Separating data models and helper utilities

## Notes

- Enter values in the formats expected by the console application. The current `Program.cs` uses `int.Parse` and `double.Parse`, so invalid numeric input can cause an exception.
- The helper methods use the paths supplied by the caller; the console application currently uses relative file names.

## Author Karlos Hakobyan
