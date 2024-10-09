import { FunctionComponent } from "react";

const ErrorBlock: FunctionComponent<{ message: string }> = ({ message }) => {
  return (
    <div className="bg-white rounded-[15px] p-5 shadow-[0px_4px_4px_0px_rgba(0,0,0,0.25)] mx-5">
      {message == "Error: No todos were found!" ? (
        <>
          <h4 className="font-bold text-2xl oxygen-mono-regular">
            No todos were found!
          </h4>
        </>
      ) : (
        <>
          <h4 className="font-bold text-2xl oxygen-mono-regular">
            An error occurred!
          </h4>
          <p className="font-normal text-xl oxygen-mono-regular">{message}</p>
        </>
      )}
    </div>
  );
};
export default ErrorBlock;
