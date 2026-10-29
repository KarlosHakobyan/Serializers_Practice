using Serealisers.Helpers;
using SerializationApp.Helpers;

static void Main()
{

    Console.Write("Enter student ID: ");
    int id = int.Parse(Console.ReadLine()!);

    Console.Write("Enter student name: ");
    string name = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter student age: ");
    int age = int.Parse(Console.ReadLine()!);

    Console.Write("Enter student grade: ");
    double grade = double.Parse(Console.ReadLine()!);

    Student student = new()
    {
        Id = id,
        Name = name,
        Age = age,
        Grade = grade
    };

    Console.WriteLine("\nChoose format:");
    Console.WriteLine("1. JSON");
    Console.WriteLine("2. XML");
    Console.Write("Your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            JsonHelper.SaveToFile("student.json", student);
            Console.WriteLine("Student saved to JSON.");

            Student? jsonStudent =
                JsonHelper.LoadFromFile<Student>("student.json");

            Console.WriteLine($"Loaded: {jsonStudent?.Name}");
            break;

        case "2":
            XmlHelper.SaveToFile("student.xml", student);
            Console.WriteLine("Student saved to XML.");

            Student? xmlStudent =
                XmlHelper.LoadFromFile<Student>("student.xml");

            Console.WriteLine($"Loaded: {xmlStudent?.Name}");
            break;

        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}