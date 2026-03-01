# E-Food Menu Viewer

A web application for browsing, filtering, and meal-planning with the [e-Food.hu](https://rendel.e-food.hu) weekly catering menu.

**Built with:** .NET 10 · Blazor Server (Interactive SSR) · WebAssembly · ASP.NET Core · Docker

![C#](https://img.shields.io/badge/C%23-13-239120) ![.NET](https://img.shields.io/badge/.NET-10-512BD4) ![Blazor](https://img.shields.io/badge/Blazor-Server-6C3FC5) ![Docker](https://img.shields.io/badge/Docker-Compose-2496ED)

## Features

- Browse the weekly lunch menu fetched from the e-Food API
- Filter by calories, protein, day, and week
- Sort by macros or protein-per-calorie ratio
- Select meals to see combined nutritional totals

## Project Structure

| Project | Description |
|---|---|
| `EFoodAPI` | Shared class library — HTTP client for the e-Food API and data models |
| `EFoodWeb` | Blazor Server host — serves the interactive web UI |
| `EFoodWeb.Client` | Blazor WebAssembly client project |
| `EFoodConsole` | Console app — CLI prototype for quick menu queries |

## Running

```bash
docker compose up --build
```

Forward port **5795** to access the app.
