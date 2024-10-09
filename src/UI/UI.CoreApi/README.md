# Todo List Frontend Application

This is a frontend web application built using Next.js, Tailwind CSS, React Query, and TypeScript. The application allows users to create, retrieve, update, and delete tasks, leveraging a backend API for managing the todo items.

## Features

- **Create Todo**: Users can create new todo items by providing a title, description, and due date.
- **View Todos**: Fetch and display a list of all todo items.
- **Update Todo**: Edit existing todo items by updating their title, description, and due/completion date.
- **Delete Todo**: Remove todo items from the list.
- **Mark as Completed**: Users can mark tasks as completed.
- **Responsive UI**: Styled using Tailwind CSS, with a mobile-friendly design.

## Tech Stack

- **[Next.js](https://nextjs.org/)**: A React framework for server-side rendering and static site generation.
- **[TypeScript](https://www.typescriptlang.org/)**: A typed superset of JavaScript to improve code quality and maintainability.
- **[Tailwind CSS](https://tailwindcss.com/)**: A utility-first CSS framework for designing responsive and modern UI.
- **[React Query](https://react-query.tanstack.com/)**: For managing server state and performing efficient data fetching.

## Project Structure

- **components/**: Reusable UI components such as forms, buttons, and todo list items.
- **functions/**: Contains all the API interaction functions using React Query (e.g., `CreateTodo`, `GetAllTodos`).
- **pages/**: Includes the pages of the app, with components mapped to each route.
- **interfaces/**: TypeScript interfaces used to define data models like `ITodoItem`, `ICreateTodo`, etc.

## Available Scripts

- `yarn dev`: Starts the development server.
- `yarn build`: Builds the application for production.
- `yarn start`: Starts the production server.
- `yarn lint`: Lints the project using ESLint.

## API Integration

The app interacts with a backend API to manage todos. Each operation is handled by a React Query hook:

- **CreateTodo**: Sends a `POST` request to create a new task.
- **GetTodoById**: Sends a `GET` request and retrieves a todo by its Id.
- **GetAllTodos**: Sends a `GET` request and retrieves a list of all todos.
- **UpdateTodo**: Sends a `PUT` request and updates an existing todo.
- **DeleteTodo**: Sends a `PATCH` request and deletes a specific todo by its Id.

## Custom Styling

Tailwind CSS is used for styling the application. The app uses a custom font, **Oxygen Mono**, and employs Tailwind's utility classes for layout, spacing, and responsive design.
