const LoadingBlock = () => {
  return (
    <div className="flex items-center justify-center h-screen">
      <div className="flex flex-col items-center justify-center">
        <div className="w-16 h-16 border-4 border-blue-500 border-t-transparent rounded-full animate-spin"></div>
        <p className="mt-4 text-blue-500 oxygen-mono-regular">Loading...</p>
      </div>
    </div>
  );
};
export default LoadingBlock;
