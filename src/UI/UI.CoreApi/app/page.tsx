"use client";
import TodoItem from "./components/TodoItem";

export default async function Home() {
  return (
    <>
      <TodoItem
        title={"fdfs"}
        description={"dadsa"}
        onDelete={function (): void {
          throw new Error("Function not implemented.");
        }}
        creationTime={new Date()}
        dueTime={new Date()}
      />
    </>
  );
}
