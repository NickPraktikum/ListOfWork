// An interface that represents a single todo item.
export interface ITodoItem {
  id: string;
  title: string;
  description: string;
  createdAt: Date | string;
  dueTime: Date | string;
  completedAt: Date | string | null;
}
