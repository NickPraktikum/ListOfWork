export interface IUpdateTodoItem {
  id: string;
  title: string;
  description: string;
  dueTime: Date | string;
  completedAt: Date | string | null;
}
