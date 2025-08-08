# 📝 Task Manager API
A clean and minimal REST API for managing personal tasks, built using **ASP.NET**, **Entity Framework**, **JWT authentication**, and **PostgreSQL**.

This project demonstrates secure user authentication, role-based access, and basic CRUD operations — a perfect foundation for fullstack applications or microservices.

---

## ✨ Features

- 🔐 User registration and JWT-based login
- 📋 Create, view, update, and delete tasks
- 🧾 Swagger documentation for easy testing
- 🔒 Role-based access control (admin/user)
- 🗄️ PostgreSQL database integration
- ✅ Clean code structure using DTOs and Services

---

## 🛠 Tech Stack

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- PostgreSQL
- JWT (JSON Web Tokens)
- Swagger (Swashbuckle)
- C#

---

## 🚀 How to Run

```bash
git clone https://github.com/dotnetbysomik/aspnet-task-api.git
cd aspnet-task-api
```
1. ✅ Update the database connection string in appsettings.json:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=taskdb;Username=postgres;Password=yourpassword"
}
```
2. ✅ Apply EF migrations:
```bash
dotnet ef database update
```
3. ✅ Run the project:
```bash
dotnet run
```
4. ✅ Open https://localhost:5001/swagger for the Swagger UI
---

## 🔐 Example Endpoints

| Method | Endpoint           | Auth | Description        |
|--------|--------------------|------|--------------------|
| POST   | /api/auth/register | ❌   | Register user      |
| POST   | /api/auth/login    | ❌   | Get JWT token      |
| GET    | /api/tasks         | ✅   | Get all tasks      |
| POST   | /api/tasks         | ✅   | Create new task    |
| PUT    | /api/tasks/{id}    | ✅   | Update task        |
| DELETE | /api/tasks/{id}    | ✅   | Delete task        |

---

## 👩‍💻 Author

Made with ❤️ by [dotnetbysomik](https://github.com/dotnetbysomik)

[![Ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/dotnetbysomik)
