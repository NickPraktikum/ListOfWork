"use client";
import { FunctionComponent, useState } from "react";
import { CreateTodo } from "../functions/CreateTodo";
import ErrorBlock from "./ErrorBlock";

// A form that creates a todo element.
const CreateForm: FunctionComponent = () => {
  const { mutate, error } = CreateTodo();
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [dueDate, setDueDate] = useState<string>("");
  const [titleError, setTitleError] = useState<boolean>(false);
  const [descriptionError, setDescriptionError] = useState<boolean>(false);
  const [dueDateError, setDueDateError] = useState<boolean>(false);

  const handleCreateTodo = () => {
    let isValid = true;

    if (!title) {
      setTitleError(true);
      isValid = false;
    } else {
      setTitleError(false);
    }

    if (!description) {
      setDescriptionError(true);
      isValid = false;
    } else {
      setDescriptionError(false);
    }

    if (!dueDate) {
      setDueDateError(true);
      isValid = false;
    } else {
      setDueDateError(false);
    }

    if (isValid) {
      mutate({
        title: title,
        description: description,
        dueTime: dueDate.toString(),
      });

      setTitle("");
      setDescription("");
      setDueDate("");
    }
  };

  return (
    <>
      <form
        onSubmit={(e) => e.preventDefault()}
        className="bg-[#FFB0B0] w-[877px] h-[583px] flex justify-around items-center gap-[22px] flex-col oxygen-mono-regular py-6 shadow-lg overflow-y-scroll scroll-behavior"
      >
        <h4 className="text-white text-xl">Create todo</h4>

        <div className="w-[555px] flex flex-col">
          <input
            type="text"
            placeholder="Enter the title:"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            className="w-full h-auto p-[15px] rounded-md shadow-lg"
          />
          {titleError && (
            <p className="text-red-500 text-sm mt-1 text-left">
              Please enter a title
            </p>
          )}
        </div>

        <div className="w-[555px] flex flex-col">
          <input
            type="text"
            placeholder="Enter the description: "
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            className="w-full h-auto p-[15px] rounded-md shadow-lg"
          />
          {descriptionError && (
            <p className="text-red-500 text-sm mt-1 text-left">
              Please enter a description
            </p>
          )}
        </div>

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

          <div
            className={`overflow-hidden transition-all duration-[900ms] ease-in-out ${
              dueDateError
                ? "max-h-40 text-red-500"
                : "max-h-0 text-gray-700 group-hover:max-h-40 group-hover:text-gray-700"
            }`}
          >
            <p className="mt-2 text-sm leading-relaxed">
              Please enter the due date and time for this task.
            </p>
          </div>
        </div>

        <button
          type="submit"
          className="bg-white w-[300px] h-auto p-5 rounded-lg shadow-lg"
          onClick={handleCreateTodo}
        >
          Create todo
        </button>

        {error && <ErrorBlock message={error.message} />}
      </form>
    </>
  );
};

export default CreateForm;
