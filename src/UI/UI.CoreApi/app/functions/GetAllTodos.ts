import { useQuery } from "@tanstack/react-query";
import { ITodoItem } from "../interfaces/ITodoItem";

export function GetAllTodos() {
  return useQuery<ITodoItem[], Error>({
    queryKey: ["all-todos"],
    queryFn: async () => {
      return await fetch("https://localhost:7071/api/v1/TodoList", {
        method: "GET",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then(async (res) => {
          if (res.ok) {
            return await res.json();
          } else if (res.status == 404) {
            throw Error("No todos were found!");
          } else {
            throw Error("Couldn't retrieve todos");
          }
        })
        .catch((err) => {
          throw Error(`${err}`);
        });
    },
    refetchInterval: 5000,
    retry: 1,
    retryDelay: 5000,
  });
}
