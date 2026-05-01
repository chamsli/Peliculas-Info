using Newtonsoft.Json;

namespace proyectoAPI.Models;

public class Movie
{
    public int id { get; set; }
    public string title { get; set; } = string.Empty;
    public string overview { get; set; } = string.Empty;
    public string poster_path { get; set; } = string.Empty;
    public string backdrop_path { get; set; } = string.Empty;
    public string release_date { get; set; } = string.Empty;
    public double vote_average { get; set; }
    public int vote_count { get; set; }
    public int runtime { get; set; }
    public string tagline { get; set; } = string.Empty;

    public List<Genre> genres { get; set; } = new();
    public Credits credits { get; set; } = new();
    public Videos videos { get; set; } = new();
}

public class Genre
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
}

public class Credits
{
    public List<Cast> cast { get; set; } = new();
    public List<Crew> crew { get; set; } = new();
}

public class Cast
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string character { get; set; } = string.Empty;
    public string profile_path { get; set; } = string.Empty;
}

public class Crew
{
    public string name { get; set; } = string.Empty;
    public string job { get; set; } = string.Empty;
}

public class Videos
{
    public List<VideoResult> results { get; set; } = new();
}

public class VideoResult
{
    public string key { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string site { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
}
