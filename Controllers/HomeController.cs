using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proyectoAPI.Models;
using Newtonsoft.Json;
namespace proyectoAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;
    private const string ApiKey = "883e7da9dc8504a0c0ba60f7885b22aa";
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }
    public async Task<IActionResult> Index(int? page )
    {
        try
        {
            int currentPage = page ?? new Random().Next(1, 21);

            string url = $"https://api.themoviedb.org/3/movie/popular?api_key={ApiKey}&page={currentPage}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return View("Error", new ErrorViewModel { RequestId = "API error" });

            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<MovieListResponse>(content);

            ViewBag.CurrentPage = currentPage;
            return View(model?.results ?? new List<Movie>());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Index");
            return View("Error", new ErrorViewModel { RequestId = ex.Message });
        }
    }

    

    public async Task<IActionResult> TopRated(int? page)
    {

        int currentPage = page ?? new Random().Next(1, 21);
        string url = $"https://api.themoviedb.org/3/movie/top_rated?api_key={ApiKey}&page={currentPage}";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Error");

        var content = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<MovieListResponse>(content);

        ViewBag.CurrentPage = currentPage;
        return View("Index", model?.results ?? new List<Movie>());
    }
   
    public async Task<IActionResult> Upcoming(int? page)
    {

        int currentPage = page ?? new Random().Next(1, 21);
        string url = $"https://api.themoviedb.org/3/movie/upcoming?api_key={ApiKey}&page={currentPage}";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Error");

        var content = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<MovieListResponse>(content);

        ViewBag.CurrentPage = currentPage;
        return View("Index", model?.results ?? new List<Movie>());
    }

    // GET: /Home/Details/5
    public async Task<IActionResult> Details(int id)
    {
        string url = $"https://api.themoviedb.org/3/movie/{id}?api_key={ApiKey}&append_to_response=credits,videos";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Error");

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonConvert.DeserializeObject<Movie>(content);
        return View(movie);
    }

    // GET: /Home/Search?query=batman
    public async Task<IActionResult> Search(string query, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(query))
            return RedirectToAction("Index");

        string url = $"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(query)}&page={page}";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Index", new List<Movie>());

        var content = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<MovieListResponse>(content);
        ViewBag.SearchQuery = query;
        return View("Index", model?.results ?? new List<Movie>());
    }

    // GET: /Home/Actors
    public async Task<IActionResult> Actors(int? page)
    {

        int currentPage = page ?? new Random().Next(1, 11); // random page 1-10
        string url = $"https://api.themoviedb.org/3/trending/person/week?api_key={ApiKey}&page={currentPage}";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Error");

        var content = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<PeopleResponse>(content);

        ViewBag.CurrentPage = currentPage;
        return View(model?.results ?? new List<Person>());
    }

    // GET: /Home/ActorDetails/2
    public async Task<IActionResult> ActorDetails(int id)
    {
        string url = $"https://api.themoviedb.org/3/person/{id}?api_key={ApiKey}&append_to_response=movie_credits";
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return View("Error");

        var content = await response.Content.ReadAsStringAsync();
        var actor = JsonConvert.DeserializeObject<PersonDetails>(content);
        return View(actor);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


