"use client";
import { FunctionComponent, useState } from "react";
import { CreateTodo } from "../functions/CreateTodo";
import ErrorBlock from "./ErrorBlock";

const CreateForm: FunctionComponent = () => {
  const { mutate, error } = CreateTodo();
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [dueDate, setDueDate] = useState<string>("");
  return (
    <>
      <form
        onClick={(e) => e.preventDefault()}
        className="bg-[#FFB0B0] w-[877px] h-[583px] flex justify-around items-center gap-[22px] flex-col oxygen-mono-regular py-6 shadow-lg overflow-y-scroll scroll-behavior"
      >
        <h4 className="text-white text-xl">Create todo</h4>
        <input
          type="text"
          placeholder="Enter the title:"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="w-[555px] h-auto p-[15px] rounded-md shadow-lg"
        />
        <input
          type="text"
          placeholder="Enter the description: "
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          className="w-[555px] h-auto p-[15px] rounded-md shadow-lg"
        />
        <div className="w-[555px] h-auto group flex flex-col p-6 mb-4 bg-white rounded-xl shadow-lg transition-transform duration-[900ms] ease-in-out">
          <div className="flex justify-between items-center mb-2">
            <h3 className="text-xl font-bold text-gray-800">Due Time</h3>
          </div>

          <div className="flex items-center bg-white p-4 rounded-lg shadow-md mb-4">
            <input
              type="datetime-local"
              value={dueDate}
              placeholder="Put the due time: "
              onChange={(e) => setDueDate(e.target.value)}
              className="w-full p-2 bg-gray-200 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-[#FFAD60] transition-all duration-300"
            />
          </div>

          <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
            <p className="mt-2 text-sm text-gray-700 leading-relaxed">
              Please enter the due date and time for this task.
            </p>
          </div>
        </div>

        <button
          type="submit"
          className="bg-white w-[300px] h-auto p-5 rounded-lg shadow-lg"
          onClick={() => {
            mutate({
              title: title,
              description: description,
              dueTime: dueDate.toString(),
            });
            setTitle("");
            setDescription("");
            setDueDate("");
          }}
        >
          Create todo
        </button>
        {error != null ? <ErrorBlock message={error.message} /> : null}
      </form>
    </>
  );
};
export default CreateForm;
