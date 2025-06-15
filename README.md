# 🎓 Student Grading Platform API

A clean and scalable ASP.NET Core Web API system for managing student grades and exam scores.  
Built as part of a full backend system simulation for an educational environment — with a focus on architecture, validation, modularity, and secure data handling.

> 💼 This project demonstrates my skills in backend development using .NET Core, layered architecture, model validation, dependency injection, logging, and secure API design.

---

## 📌 Key Highlights

- 🔐 Secure teacher & student login system
- 🧠 Smart grade management with dynamic weights from configuration
- 📈 Final grade calculation based on custom logic and `appsettings.json`
- 🧩 Exception handling using custom exception classes
- 📂 Clean architecture: DAL, BL, Models, Services
- 📄 Fully documented and testable with Swagger/Postman
- 🪵 Advanced logging: Console + file logging per action and error

---

## 🛠️ Tech Stack

| Layer        | Technologies                          |
|--------------|----------------------------------------|
| Language     | C#                                     |
| Backend      | ASP.NET Core Web API (.NET 6)          |
| Architecture | Layered: API, Services, Class Library  |
| Validation   | Data Annotations + Manual Checks       |
| Logging      | Console + File logs                    |
| Configuration| `appsettings.json`                     |
| Testing      | Swagger / Postman                      |

---

## 🧪 What I Built

### 👩‍🏫 For Teachers

- Create / Edit / Delete students  
- Assign grades to multiple students by exercise code  
- Update specific scores  
- View student records and grades  
- Calculate final grades dynamically

### 👩‍🎓 For Students

- Login using ID + password  
- View grades per task or exam  
- See class average per exercise  
- View their own final weighted score  

---

## 🧱 System Design

This project follows a **modular and scalable structure**:

