# Peliculas-Info

## Justificación
Me apasiona el cine, por eso he desarrollado una aplicación web que permite explorar películas populares, las mejor valoradas, los próximos estrenos y los actores más tendencia. Los datos se obtienen en tiempo real a través de **The Movie Database (TMDb) API**. Esta aplicación demuestra el uso de la arquitectura MVC, programación asíncrona, consumo de APIs y diseño responsive.

## Arquitectura (MVC)
┌─────────────────────────────────────────────────────────┐
│                      NAVEGADOR                          │
│                   (Usuario ve la web)                   │
└─────────────────────────┬───────────────────────────────┘
                          │ HTTP Request
                          ▼
┌─────────────────────────────────────────────────────────┐
│              CONTROLADOR (HomeController.cs)            │
│  Acciones: Index, TopRated, Upcoming, Details,          │
│            Search, Actors, ActorDetails                 │
└───────────┬─────────────────────────────┬───────────────┘
            │                             │
            ▼                             ▼
┌───────────────────────┐    ┌────────────────────────────┐
│       MODELOS         │    │          VISTAS            │
│  - Movies.cs          │    │  - Index.cshtml            │
│  - MovieListResponse  │    │  - Details.cshtml          │
│  - Person.cs          │    │  - Actors.cshtml           │
│  - PersonDetails.cs   │    │  - ActorDetails.cshtml     │
│  - ErrorViewModel.cs  │    │  - Shared/_Layout.cshtml   │
└───────────────────────┘    └────────────────────────────┘
            │
            ▼
┌─────────────────────────────────────────────────────────┐
│                    API EXTERNA                          │
│       🌐 api.themoviedb.org (películas y actores)       │
└─────────────────────────────────────────────────────────┘


## 3. Explicación MVC
- **Modelos**: `Movie.cs`, `Person.cs` – mapean el JSON de la API.
- **Controlador**: Acciones `async` que llaman a TMDb con `HttpClient`, deserializan con `Newtonsoft.Json` y pasan datos a las vistas.
- **Vistas**: `Index.cshtml` (grid de películas), `Details.cshtml` (detalle + reparto), `Actors.cshtml`, etc. CSS moderno y responsive.

## 4. Mejoras propuestas
- Añadir favoritos con localStorage
- Desplazamiento infinito
- Crear cuentas para cada usuario
