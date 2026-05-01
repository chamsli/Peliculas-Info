namespace proyectoAPI.Models;

public class PersonDetails
{
    public string name { get; set; } = string.Empty;
    public string biography { get; set; } = string.Empty;
    public string birthday { get; set; } = string.Empty;
    public string place_of_birth { get; set; } = string.Empty;
    public string profile_path { get; set; } = string.Empty;
    public double popularity { get; set; }
    public MovieCredits movie_credits { get; set; } = new();
}

public class MovieCredits
{
    public List<ActorMovie> cast { get; set; } = new();
}

public class ActorMovie
{
    public string title { get; set; } = string.Empty;
    public double popularity { get; set; }
    public string poster_path { get; set; } = string.Empty;
}