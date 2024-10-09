import { useMutation } from "@tanstack/react-query";
import { ITodoItem } from "../interfaces/ITodoItem";
import { IUpdateTodoItem } from "../interfaces/IUpdateTodo";
export function UpdateTodo() {
  return useMutation<ITodoItem, Error, IUpdateTodoItem>({
    mutationFn: async (parameters: IUpdateTodoItem) => {
      return await fetch(
        `https://localhost:7071/api/v1/TodoList/${parameters.id}`,
        {
          method: "PUT",
          mode: "cors",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            Title: parameters.title,
            Description: parameters.description,
            DueTime: parameters.dueTime,
            CompletedAt: parameters.completedAt,
          }),
        }
      )
        .then(async (res) => {
          if (res.ok) {
            return await res.json();
          } else if (res.status === 404) {
            throw Error("No todos were found!");
          } else if (res.status == 400) {
            const response = await res.json();
            throw Error(response.detail);
          } else {
            throw Error("Couldn't update a todo!");
          }
        })
        .catch((err) => {
          throw Error(`${err}`);
        });
    },
  });
}
