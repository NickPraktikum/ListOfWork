import { FunctionComponent } from "react";
import TodoItem from "./TodoItem";
import { ITodoItem } from "../interfaces/ITodoItem";

// A block of item that receives data and displays the todos.
const TodoItems: FunctionComponent<{ data: ITodoItem[] }> = ({ data }) => {
  return (
    <div className="overflow-y-scroll scroll-behavior">
      {data?.map((todo: ITodoItem, index: number) => (
        <TodoItem
          title={todo.title}
          description={todo.description}
          createdAt={todo.createdAt}
          dueTime={todo.dueTime}
          key={index}
          id={todo.id}
          completedAt={todo.completedAt}
        />
      ))}
    </div>
  );
};
export default TodoItems;
