"use client";
import { FunctionComponent, useState } from "react";
import MenuIcon from "./svgs/MenuIcon";

const Navigation: FunctionComponent = (): React.ReactNode => {
  // Add state to handle menu visibility
  const [menuOpen, setMenuOpen] = useState(false);

  // Toggle menu function
  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div
      className={`w-[977px] h-auto bg-[#96CEB4] rounded-[10px] flex flex-col items-start px-6 pt-4 oxygen-mono-regular transition-all duration-[600ms] ease-linear transform  ${
        menuOpen ? "py-4" : ""
      }`}
    >
      {/* Header Section */}
      <div className="w-full flex items-center justify-between">
        <h1 className="text-[36px] font-light text-black">List of Work</h1>
        <button
          className="bg-transparent border-none cursor-pointer p-2 focus:outline-none hover:bg-gray-200 rounded"
          aria-label="Menu"
          onClick={toggleMenu} // Add onClick handler
        >
          <MenuIcon />
        </button>
      </div>

      {/* Dropdown Menu */}
      <div
        className={`transition-all duration-[600ms] ease-linear transform ${
          menuOpen ? "max-h-[300px] opacity-100" : "max-h-0 opacity-0"
        } overflow-hidden w-full mt-4 bg-white rounded-lg shadow-md`}
      >
        <ul className="flex flex-col space-y-0 text-lg">
          <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
            <a href="#" className="text-black">
              Todos
            </a>
          </li>
          <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
            <a href="#" className="text-black">
              Get todo
            </a>
          </li>
          <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
            <a href="#" className="text-black">
              Update todo
            </a>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Navigation;
