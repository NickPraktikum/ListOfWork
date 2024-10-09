import { useMutation, useQueryClient } from "@tanstack/react-query";
export function DeleteTodo() {
  const queryClient = useQueryClient();
  return useMutation<boolean, Error, string>({
    mutationFn: async (id: string) => {
      return await fetch(`https://localhost:7071/api/v1/TodoList/${id}`, {
        method: "DELETE",
        mode: "cors",
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then(async (res) => {
          if (res.ok) {
            return await res.json();
          } else if (res.status == 400) {
            const response = await res.json();
            throw Error(response.detail);
          } else {
            throw Error("Couldn't delete a todo!");
          }
        })
        .catch((err) => {
          throw Error(err.detail);
        });
    },
    retry: 0,
    retryDelay: 1000,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["all-todos"] });
    },
  });
}
