# **List of Work**

Source code for the project called List Of Work. The project lets user create his own to To-Do list.

## **Todo List API**

The **Todo List API** is a simple REST API that provides endpoints to manage users personal **To-Do list**. It allows you to **create**, **read**, **update**, **complete**, and **delete** **To-Do list** items. The API supports **JSON** format.

### **Features**

- **Create**, **retrieve**, **update**, **delete**, and **complete** tasks in your **To-Do list**.
- Easily manage the tasks you need to complete.
- Return appropriate HTTP status codes based on the request.
- **RESTful** and **JSON**-based API design.

### Endpoints

#### 1. Create Todo Item

- **URL**: `/api/v1/todolist`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "title": "Sample Todo",
    "description": "Description of the task",
    "isCompleted": false
  }
  ```
- **Response**:
  - `200 OK`: Returns the created todo item.
  - Example:
  ```json
  {
    "id": "1",
    "title": "Sample Todo",
    "description": "Description of the task",
    "isCompleted": false
  }
  ```

#### 2. Get All Todo Items

- **URL**: `/api/v1/todolist`
- **Method**: `GET`
- **Response**:
  - `200 OK`: Returns a list of todo items.
  - `404 Not Found`: If no todo items are found.
  - Example:
  ```json
  [
    {
      "id": "1",
      "title": "Sample Todo",
      "description": "Description of the task",
      "isCompleted": false
    }
  ]
  ```

#### 3. Get Todo Item by ID

- **URL**: `/api/v1/todolist/{id}`
- **Method**: `GET`
- **Parameters**: `id` (string) – The ID of the todo item.
- **Response**:
  - `200 OK`: Returns the todo item with the given `id`.
  - `404 Not Found`: If the todo item with the given `id` is not found.
  - Example:
  ```json
  {
    "id": "1",
    "title": "Sample Todo",
    "description": "Description of the task",
    "isCompleted": false
  }
  ```

#### 4. Update Todo Item

- **URL**: `/api/v1/todolist/{id}`
- **Method**: `PUT`
- **Parameters**: `id` (string) – The ID of the todo item.
- **Request Body**:
  ```json
  {
    "title": "Updated Todo",
    "description": "Updated description",
    "isCompleted": true
  }
  ```
- **Response**:
  - `200 OK`: Returns the updated todo item.
  - `404 Not Found`: If the todo item with the given `id` is not found.
  - Example:
  ```json
  {
    "id": "1",
    "title": "Updated Todo",
    "description": "Updated description",
    "isCompleted": true
  }
  ```

#### 5. Delete Todo Item

- **URL**: `/api/v1/todolist/{id}`
- **Method**: `DELETE`
- **Parameters**: `id` (string) – The ID of the todo item.
- **Response**:
  - `200 OK`: Returns `true` if the item was successfully deleted.
  - `404 Not Found`: If the todo item with the given `id` is not found.
  - Example:
  ```json
  true
  ```

#### 6. Mark Todo Item as Completed

- **URL**: `/api/v1/todolist/{id}`
- **Method**: `PATCH`
- **Parameters**: `id` (string) – The ID of the todo item.
- **Response**:
  - `200 OK`: Returns the todo item with its state set to completed.
  - `404 Not Found`: If the todo item with the given `id` is not found.
  - Example:
  ```json
  {
    "id": "1",
    "title": "Sample Todo",
    "description": "Description of the task",
    "isCompleted": true
  }
  ```

### Data Models

#### TodoItemModel

- **Properties**:
  - `id`: The unique identifier of the todo item (string).
  - `title`: The title of the todo item (string).
  - `description`: A description of the todo item (string).
  - `isCompleted`: A boolean indicating whether the todo item is completed (boolean).

#### CreateTodoItemModel

- **Properties**:
  - `title`: The title of the todo item (string).
  - `description`: A description of the todo item (string).
  - `isCompleted`: A boolean indicating whether the todo item is completed (boolean).

### Setup and Usage

#### Requirements

- .NET SDK 6.0 or later
- Visual Studio or VS Code (Optional)
