"use client";
import { FunctionComponent, useState } from "react";
import LikeIcon from "./svgs/LikeIcon";
import DeleteIcon from "./svgs/DeleteIcon";
import LikedIcon from "./svgs/LikedIcon";
import { TodoItemProps } from "./interfaces/ITodoItem";

const TodoItem: FunctionComponent<TodoItemProps> = ({
  title,
  description,
  creationTime,
  dueTime,
  onDelete,
}) => {
  const [isLiked, setIsLiked] = useState(false);
  const toggleLike = () => {
    setIsLiked(!isLiked);
  };
  return (
    <div className="group flex flex-col p-6 mb-4 bg-[#FFAD60] rounded-xl shadow-lg transition-transform duration-[900ms] oxygen-mono-regular">
      {/* Todo Header */}
      <div className="flex justify-between items-center mb-2">
        <h3 className="text-xl font-bold text-gray-800">Title: {title}</h3>
        <div className="flex space-x-4">
          <button
            onClick={toggleLike}
            aria-label="Like"
            className="focus:outline-none"
          >
            {isLiked ? <LikedIcon /> : <LikeIcon />}
          </button>

          <button
            onClick={onDelete}
            aria-label="Delete"
            className="text-red-500 hover:text-red-700"
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
          Creation date: {creationTime.toDateString()}
        </p>
      </div>
      <div className="max-h-0 group-hover:max-h-40 overflow-hidden transition-all duration-[900ms] ease-in-out">
        <p className="mt-2 text-sm text-gray-700 leading-relaxed">
          Due date: {dueTime.toDateString()}
        </p>
      </div>
    </div>
  );
};

export default TodoItem;
