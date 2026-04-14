# Task Management API

A RESTful API for managing tasks, built with ASP.NET Core 10. Supports full CRUD operations with proper validation, clean layered architecture, and a consistent response format across all endpoints.

## Tech Stack

- **ASP.NET Core 10**
- **Entity Framework Core 10** — SQL Server
- **AutoMapper** — DTO mapping
- **Scalar** — API documentation (replaces Swagger UI)

## Project Structure

```
TaskManagement_API/
├── Controllers/        # HTTP layer — handles requests and responses
├── Services/           # Business logic
├── Repositories/       # Data access
├── Entities/           # EF Core models and DbContext
├── Models/
│   ├── DTOs/           # Separate DTOs for Create, Update, and Read
│   └── ApiResponse/    # Wrapper for consistent API responses
├── Enums/              # TaskItemStatus, TaskItemPriority
├── CustomValidation/   # EnumValidation attribute
└── Profiles/           # AutoMapper profiles
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- SQL Server (LocalDB works fine)

### Setup

1. Clone the repo
   ```bash
   git clone https://github.com/josephcreed10/task-management-api.git
   cd task-management-api
   ```

2. Update the connection string in `appsettings.json` if needed
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "your-connection-string-here"
   }
   ```

3. Apply migrations
   ```bash
   Update-Database
   ```

4. Run the project
   ```bash
   dotnet run
   ```

5. Open the API docs at `https://localhost:{port}/scalar`

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/tasks` | Get all tasks |
| GET | `/api/tasks/{id}` | Get a task by ID |
| POST | `/api/tasks` | Create a new task |
| PUT | `/api/tasks/{id}` | Update a task |
| DELETE | `/api/tasks/{id}` | Delete a task |

## Request & Response

### Create a Task — `POST /api/tasks`

**Request body:**
```json
{
  "title": "Fix login bug",
  "description": "Users getting 401 on valid credentials",
  "status": "Pending",
  "priority": "High",
  "dueDate": "2025-12-31"
}
```

**Valid values:**
- `status` — `Pending`, `InProgress`, `Completed`
- `priority` — `Low`, `Medium`, `High`

**Response:**
```json
{
  "success": true,
  "statusCode": 201,
  "message": "Task created successfully.",
  "data": {
    "id": 1,
    "title": "Fix login bug",
    "description": "Users getting 401 on valid credentials",
    "status": "Pending",
    "priority": "High",
    "dueDate": "2025-12-31",
    "createdAt": "2025-04-14T07:10:00Z",
    "updatedAt": "2025-04-14T07:10:00Z"
  },
  "errors": null,
  "timestamp": "2025-04-14T07:10:00Z"
}
```

All endpoints return this same `ApiResponse<T>` shape, so error handling is predictable on the client side too.

## Validation

Invalid enum values are rejected with a clear error message:

```json
{
  "success": false,
  "statusCode": 400,
  "message": "Invalid value. Allowed values are: Pending, InProgress, Completed"
}
```

## Notes

- Timestamps (`createdAt`, `updatedAt`) are set automatically — no need to pass them in requests
- The repository pattern is used to keep data access separate from business logic, making it easier to swap out or test later
- Enums are stored as integers in the database but serialized as strings in the API
