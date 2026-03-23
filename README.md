# Food Safety Inspection System

## Overview
This project is a Food Safety Inspection system built with ASP.NET Core MVC.
It allows users to manage premises, inspections, and follow-up actions in a structured and secure way.

---

## Features

- CRUD for Premises, Inspections, and Follow-Ups
- Role-based access control (Admin, Inspector, Viewer)
- Dashboard with real-time data and filters
- Tracks inspections and outcomes (Pass/Fail)
- Manages follow-ups with status (Open/Closed)
- Detects overdue follow-ups
- Seeded database with sample data
- Logging using Serilog (console and file)
- Global error handling with friendly error page
- Unit tests using xUnit
- CI pipeline with GitHub Actions

---

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (SQLite)
- ASP.NET Identity
- Serilog
- xUnit
- GitHub Actions

---

## How to Run

1. Clone the repository
2. Open in Visual Studio
3. Run the following commands:
- Update-Database
4. Run the project

---

## Logins

Default Admin
- Email: admin@test.com 
- Password: Admin123!

Inspector
- inspector@test.com
- Admin123!

Viewer
- viewer@test.com
- Admin123!

---

## Testing

Run tests using:
- dotnet test
  
---

## CI/CD

The project includes a GitHub Actions workflow that:

- Builds the project
- Runs tests
