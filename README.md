# 🎓 Student Grading Platform API

A structured and scalable ASP.NET Core Web API for managing student grades in an educational setting.  
Built with clean architecture, secure access, and dynamic business logic — simulating a real-world backend system.

> 💼 This project showcases my skills in backend development, clean code, API design, model validation, and system thinking with .NET Core.

---

## 💡 Overview

A role-based grading system where teachers can manage students and their grades, while students can securely view personal scores and class averages.

### 👩‍🏫 Teacher Features

- Add, update, and delete students  
- Assign or update grades per student or exercise  
- View all student records with their scores  
- Automatically calculate final grades based on configurable weights

### 👩‍🎓 Student Features

- Secure login using ID and password  
- View grades per task or exam  
- See class average for each task  
- View personal final grade based on weighted scores

---

## 🛠 Tech Stack

- C# / ASP.NET Core Web API (.NET 6)  
- Layered architecture: Controllers, Services, Data Models  
- Dependency Injection  
- Custom Exceptions & Logging (Console + File)  
- Swagger / Postman for API testing  
- Configuration via `appsettings.json` (without hardcoding logic)

---

## 🧱 Architecture Highlights

- Separation of concerns between API, logic, and data  
- Reusable models and DTOs  
- Centralized configuration for credentials and grade logic  
- Defensive programming with custom exceptions  
- Extensive logging for both actions and errors

---

## 🚀 Run the Project

```bash
git clone https://github.com/RachelGenauer/Student-Grading-Platform-API-Project.git
cd Student-Grading-Platform-API-Project
dotnet build
dotnet run
