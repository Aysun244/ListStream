using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public class Program
{
    static string FilePath = "names.json";
    static List<string> names = LoadFromFile();

    static List<string > LoadFromFile()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
         }
        return new List<string>();
    }

    static void SaveToFile()
    {
        string json = JsonSerializer.Serialize(names, new JsonSerializerOptions { WriteIndented=true});
        File.WriteAllText(FilePath, json);
    }
    static void Add(string name)
    {
        names.Add(name);
        SaveToFile();
    }
    static void Delete(int index)
    {
        if (index >= 0 && index < names.Count)
            names.RemoveAt(index);
        SaveToFile();

    }
}



       static void Main()
{
    Add("a3");
    Add("asuheur4");
    Add("asde1");


    Console.WriteLine("Butun adlar:");
    foreach (var name in names)
    {
        Console.WriteLine(name);
    }

    Console.WriteLine("Sertlerin odendiyi adlar:");

    var filtered = names.FindAll(names =>
    names.Length == 5 &&
    char.IsUpper(names[0]) &&
    char.IsDigit(names[^1])
    );


    foreach (var name in filtered)
    {
        Console.WriteLine(name);
    }
}

