"use client";
import { FunctionComponent, useEffect } from "react";
import LikeIcon from "./svgs/LikeIcon";
import DeleteIcon from "./svgs/DeleteIcon";
import LikedIcon from "./svgs/LikedIcon";
import { ITodoItem } from "../interfaces/ITodoItem";
import { SetTodoToComplete } from "../functions/SetToCompleteTodo";
import { DeleteTodo } from "../functions/DeleteTodo";

const TodoItem: FunctionComponent<ITodoItem> = ({
  id,
  title,
  description,
  createdAt,
  dueTime,
  completedAt,
}) => {
  const { mutate: mutateRemove, error: errorRemove } = DeleteTodo();
  const { mutate: mutateSetToComplete, error: errorSetToComplete } =
    SetTodoToComplete();
  useEffect(() => {
    console.log(errorRemove?.message);
  }, [errorRemove]);
  useEffect(() => {
    console.log(errorSetToComplete?.message);
  }, [errorSetToComplete]);
  return (
    <div className="w-[977px] h-auto group flex flex-col p-6 mb-4 bg-[#FFAD60] rounded-xl shadow-lg transition-transform duration-[900ms] oxygen-mono-regular">
      <div className="flex justify-between items-center mb-2">
        <h3 className="text-xl font-bold text-gray-800">Title: {title}</h3>
        <div className="flex space-x-4">
          <button
            onClick={() => mutateSetToComplete(id)}
            aria-label="Like"
            className="focus:outline-none"
          >
            {completedAt != null ? <LikedIcon /> : <LikeIcon />}
          </button>

          <button
            aria-label="Delete"
            className="text-red-500 hover:text-red-700"
            onClick={() => mutateRemove(id)}
          >
            <DeleteIcon />
          </button>
        </div>
      </div>

      <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
        <p className="mt-2 text-sm text-gray-700 leading-relaxed">
          Description: {description}
        </p>
      </div>
      <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
        <p className="mt-2 text-sm text-gray-700 leading-relaxed">
          Creation date: {new Date(createdAt).toLocaleString()}
        </p>
      </div>
      <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
        <p className="mt-2 text-sm text-gray-700 leading-relaxed">
          Due date: {new Date(dueTime).toLocaleString()}
        </p>
      </div>
      {completedAt == null ? (
        <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
          <p className="mt-2 text-sm text-gray-700 leading-relaxed">
            Hasn&apos;t been completed yet.
          </p>
        </div>
      ) : (
        <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
          <p className="mt-2 text-sm text-gray-700 leading-relaxed">
            Completed at: {new Date(completedAt).toLocaleString()}
          </p>
        </div>
      )}
    </div>
  );
};

export default TodoItem;
