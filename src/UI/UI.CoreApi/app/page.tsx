"use client";
import TodoItems from "./components/TodoItems";
import { GetAllTodos } from "./functions/GetAllTodos";
import { ITodoItem } from "./interfaces/ITodoItem";

export default function Home() {
  const { data, error } = GetAllTodos();
  return (
    <>
      <TodoItems data={data as ITodoItem[]} />
    </>
  );
}
