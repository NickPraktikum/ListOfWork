import { useMutation } from "@tanstack/react-query";
import { ITodoItem } from "../interfaces/ITodoItem";
import { ICreateTodo } from "../interfaces/ICreateTodo";

// A function that calls the https://localhost:7071/api/v1/TodoList endpoint to create a todo.
export function CreateTodo() {
  return useMutation<ITodoItem, Error, ICreateTodo>({
    mutationFn: async (parameters: ICreateTodo) => {
      return await fetch(`https://localhost:7071/api/v1/TodoList`, {
        method: "POST",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Title: parameters.title,
          Description: parameters.description,
          DueTime: parameters.dueTime,
        }),
      })
        .then(async (res) => {
          if (res.ok) {
            return await res.json();
          } else if (res.status == 400) {
            const response = await res.json();
            throw Error(response.detail);
          } else {
            throw Error("Couldn't create a todo!");
          }
        })
        .catch((err) => {
          throw Error(`${err}`);
        });
    },
  });
}
