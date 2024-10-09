"use client";
import { FunctionComponent, useState } from "react";
import { GetTodoById } from "../functions/GetTodoById";
import TodoItem from "./TodoItem";
import ErrorBlock from "./ErrorBlock";

// A form to retrieve an element with a provided id.
const GetForm: FunctionComponent = () => {
  const [id, setId] = useState<string>("");
  const [idError, setIdError] = useState<boolean>(false);
  const { data, error, refetch } = GetTodoById(id);
  const handleFetchTodo = () => {
    let isValid = true;

    if (!id) {
      setIdError(true);
      isValid = false;
    } else {
      setIdError(false);
    }

    if (isValid) {
      refetch();
    }
  };

  return (
    <div className="flex flex-col justify-between items-center gap-[20px] h-auto overflow-y-scroll scroll-behavior">
      <form
        onSubmit={(e) => e.preventDefault()}
        className="bg-[#FFB0B0] w-[877px] h-[583px] flex justify-around items-center gap-[22px] flex-col oxygen-mono-regular py-6 shadow-lg shrink-0"
      >
        <h4 className="text-white text-xl">Get todo</h4>

        <div className="w-[555px] flex flex-col">
          <input
            type="text"
            placeholder="Enter the id:"
            value={id}
            onChange={(e) => setId(e.target.value)}
            className="w-full h-auto p-[15px] rounded-md shadow-lg"
          />
          {idError && (
            <p className="text-red-500 text-sm mt-1 text-left">
              Please enter a valid Id
            </p>
          )}
        </div>

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
