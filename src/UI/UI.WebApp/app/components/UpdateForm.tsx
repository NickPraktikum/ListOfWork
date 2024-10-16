"use client";
import { FunctionComponent, useState } from "react";
import ErrorBlock from "./ErrorBlock";
import { UpdateTodo } from "../functions/UpdateTodo";

// The update form to update a todo with provided id.
const UpdateForm: FunctionComponent = () => {
  const { mutate, error } = UpdateTodo();

  const [id, setId] = useState<string>("");
  const [title, setTitle] = useState<string>("");
  const [description, setDescription] = useState<string>("");
  const [dueDate, setDueDate] = useState<string>("");
  const [completedDate, setCompletedDateDate] = useState<string>("");

  // Validation state variables
  const [idError, setIdError] = useState<boolean>(false);
  const [titleError, setTitleError] = useState<boolean>(false);
  const [descriptionError, setDescriptionError] = useState<boolean>(false);
  const [dueDateError, setDueDateError] = useState<boolean>(false);
  const [completedDateError, setCompletedDateError] = useState<boolean>(false);

  const handleUpdateTodo = () => {
    let isValid = true;

    if (!id) {
      setIdError(true);
      isValid = false;
    } else {
      setIdError(false);
    }

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
    if (!completedDate) {
      setCompletedDateError(true);
      isValid = false;
    } else {
      setCompletedDateError(false);
    }

    if (isValid) {
      mutate({
        id: id,
        title: title,
        description: description,
        dueTime: dueDate.toString(),
        completedAt: completedDate.toString(),
      });

      setId("");
      setTitle("");
      setDescription("");
      setDueDate("");
      setCompletedDateDate("");
    }
  };

  return (
    <>
      <form
        onClick={(e) => e.preventDefault()}
        className="bg-[#FFB0B0] w-[877px] h-[583px] flex justify-around items-center gap-[22px] flex-col oxygen-mono-regular py-6 shadow-lg overflow-y-scroll scroll-behavior"
      >
        <h4 className="text-white text-xl">Update todo</h4>
        <div className="w-[555px] flex flex-col">
          <input
            type="text"
            placeholder="Enter the item id:"
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

        <div className="w-[555px] flex flex-col">
          <input
            type="text"
            placeholder="Enter the new title:"
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
            placeholder="Enter the new description:"
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

        <div className="w-[555px] h-auto group flex flex-col p-6 mb-4 bg-white rounded-xl shadow-lg transition-transform duration-[900ms] ease-in-out">
          <div className="flex justify-between items-center mb-2">
            <h3 className="text-xl font-bold text-gray-800">Completed time</h3>
          </div>

          <div className="flex items-center bg-white p-4 rounded-lg shadow-md mb-4">
            <input
              type="datetime-local"
              value={completedDate}
              onChange={(e) => setCompletedDateDate(e.target.value)}
              className="w-full p-2 bg-gray-200 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-[#FFAD60] transition-all duration-300"
            />
          </div>

          <div
            className={`overflow-hidden transition-all duration-[900ms] ease-in-out ${
              completedDateError
                ? "max-h-40 text-red-500"
                : "max-h-0 text-gray-700 group-hover:max-h-40 group-hover:text-gray-700"
            }`}
          >
            <p className="mt-2 text-sm leading-relaxed">
              Please enter the completed date and time for this task.
            </p>
          </div>
        </div>

        <button
          type="submit"
          className="bg-white w-[300px] h-auto p-5 rounded-lg shadow-lg"
          onClick={handleUpdateTodo}
        >
          Update todo
        </button>

        {error && <ErrorBlock message={error.message} />}
      </form>
    </>
  );
};
export default UpdateForm;
