import { FunctionComponent } from "react";

const ErrorBlock: FunctionComponent<{ message: string }> = ({ message }) => {
  return (
    <div className="bg-white rounded-[15px] p-5 shadow-[0px_4px_4px_0px_rgba(0,0,0,0.25)] mx-5">
      <h4 className="font-bold text-2xl">An error occurred!</h4>
      <p className="font-normal text-xl">{message}</p>
    </div>
  );
};
export default ErrorBlock;
