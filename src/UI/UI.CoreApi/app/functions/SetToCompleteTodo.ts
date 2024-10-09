import { useMutation } from "@tanstack/react-query";
import { ITodoItem } from "../interfaces/ITodoItem";
export function SetTodoToComplete() {
  return useMutation<ITodoItem, Error, string>({
    mutationFn: async (id: string) => {
      return await fetch(`https://localhost:7071/api/v1/TodoList/${id}`, {
        method: "PATCH",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then(async (res) => {
          if (res.ok) {
            return await res.json();
          }
          if (res.status == 400) {
            const response = await res.json();
            throw Error(response.detail);
          } else {
            throw Error("Couldn't set a todo to complete!");
          }
        })
        .catch((err) => {
          throw Error(`${err}`);
        });
    },
    retry: 0,
    retryDelay: 1000,
  });
}
