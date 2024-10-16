"use client";
import ErrorBlock from "./components/ErrorBlock";
import LoadingBlock from "./components/Loading";
import TodoItems from "./components/TodoItems";
import { GetAllTodos } from "./functions/GetAllTodos";
import { ITodoItem } from "./interfaces/ITodoItem";

// A page where a user can list of his todos, delete them and set them to completed.
export default function Page() {
  const { data, error, isLoading } = GetAllTodos();
  return (
    <>
      {isLoading && <LoadingBlock />}
      {error != null ? (
        <ErrorBlock message={error.message} />
      ) : (
        <TodoItems data={data as ITodoItem[]} />
      )}
    </>
  );
}
