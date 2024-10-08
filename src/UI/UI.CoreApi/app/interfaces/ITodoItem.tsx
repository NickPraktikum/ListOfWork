export interface ITodoItem {
  id: string;
  title: string;
  description: string;
  createdAt: Date | string;
  dueTime: Date | string;
  completedAt: Date | null;
}
