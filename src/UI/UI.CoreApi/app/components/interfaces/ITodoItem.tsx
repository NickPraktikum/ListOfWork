export interface TodoItemProps {
  title: string;
  description: string;
  creationTime: Date;
  dueTime: Date;
  onDelete: () => void;
}
