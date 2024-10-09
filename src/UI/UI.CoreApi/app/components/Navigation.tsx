"use client";
import { FunctionComponent, useState } from "react";
import MenuIcon from "./svgs/MenuIcon";
import Link from "next/link";

const Navigation: FunctionComponent = (): React.ReactNode => {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div
      className={`w-[977px] h-auto bg-[#96CEB4] rounded-[10px] flex flex-col items-start px-6 pt-4 oxygen-mono-regular shadow-lg  transition-all duration-[600ms] ease-linear transform  ${
        menuOpen ? "py-4" : ""
      }`}
    >
      <div className="w-full flex items-center justify-between">
        <h1 className="text-[36px] font-light text-black">List of Work</h1>
        <button
          className="bg-transparent border-none cursor-pointer p-2 focus:outline-none hover:bg-gray-200 rounded"
          aria-label="Menu"
          onClick={toggleMenu}
        >
          <MenuIcon />
        </button>
      </div>

      <div
        className={`transition-all duration-[600ms] ease-linear transform ${
          menuOpen ? "max-h-[300px] opacity-100" : "max-h-0 opacity-0"
        } overflow-hidden w-full mt-4 bg-white rounded-lg shadow-md`}
      >
        <ul className="flex flex-col space-y-0 text-lg">
          <Link href="/">
            <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
              <p className="text-black">Todos</p>
            </li>
          </Link>
          <Link href="/CreateTodo">
            <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
              <p className="text-black">Create todo</p>
            </li>
          </Link>
          <Link href="/GetTodo" className="text-black">
            <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
              <p className="text-black">Get todo</p>
            </li>
          </Link>
          <Link href="/UpdateTodo" className="text-black">
            <li className="hover:bg-gray-100 px-4 py-2 border-t border-b border-gray-300">
              <p className="text-black">Update todo</p>
            </li>
          </Link>
        </ul>
      </div>
    </div>
  );
};

export default Navigation;
