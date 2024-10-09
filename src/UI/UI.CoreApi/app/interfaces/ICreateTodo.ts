// An interface for the model that is used for creating a single todo item.
export interface ICreateTodo {
  title: string;
  description: string;
  dueTime: Date | string;
}
