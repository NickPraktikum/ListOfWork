// An interface that provides data that will be updated in the todo.
export interface IUpdateTodoItem {
  id: string;
  title: string;
  description: string;
  dueTime: Date | string;
  completedAt: Date | string | null;
}
