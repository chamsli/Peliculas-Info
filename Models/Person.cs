namespace proyectoAPI.Models;

public class KnownFor
{
    public string title { get; set; } = string.Empty;
    public string media_type { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;  // For TV shows
}

public class Person
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string profile_path { get; set; } = string.Empty;
    public List<KnownFor> known_for { get; set; } = new();
}

public class PeopleResponse
{
    public List<Person> results { get; set; } = new();
}