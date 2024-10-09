"use client";
import { FunctionComponent, useState } from "react";
import { GetTodoById } from "../functions/GetTodoById";
import TodoItem from "./TodoItem";
import ErrorBlock from "./ErrorBlock";

const GetForm: FunctionComponent = () => {
  const [id, setId] = useState<string>("");
  const { data, error, refetch } = GetTodoById(id);
  const handleFetchTodo = () => {
    if (id) {
      refetch();
    }
  };

  return (
    <div className="flex flex-col justify-between items-center gap-[20px] h-auto overflow-y-scroll scroll-behavior">
      <form
        onSubmit={(e) => e.preventDefault()}
        className="bg-[#FFB0B0] w-[877px] h-[583px]  flex justify-around items-center gap-[22px] flex-col oxygen-mono-regular py-6 shadow-lg shrink-0"
      >
        <h4 className="text-white text-xl">Get todo</h4>
        <input
          type="text"
          placeholder="Enter the id:"
          value={id}
          onChange={(e) => setId(e.target.value)}
          className="w-[555px] h-auto p-[15px] rounded-md shadow-lg"
        />

        <button
          type="button"
          className="bg-white w-[300px] h-auto p-5 rounded-lg shadow-lg"
          onClick={handleFetchTodo}
        >
          Get todo
        </button>

        <div>{error && <ErrorBlock message={error.message} />}</div>
      </form>

      {data && (
        <TodoItem
          id={data.id}
          title={data.title}
          description={data.description}
          createdAt={data.createdAt}
          dueTime={data.dueTime}
          completedAt={data.completedAt}
        />
      )}
    </div>
  );
};
export default GetForm;
