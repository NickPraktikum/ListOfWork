import type { Metadata } from "next";
import "./globals.css";
import React from "react";
import { QueryProvider } from "./providers/QueryProvider";
import Navigation from "./components/Navigation";

// A root layout of the app.
export const metadata: Metadata = {
  title: "List of Work",
  description: "Created by Nick Sidenko for devdeer.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en" className="bg-[#FFD99F] flex justify-center items-center">
      <body className="w-[1058px] h-[815px] bg-white mt-[100px] p-[41px] flex flex-col items-center">
        <div className="justify-between items-center p-4 mb-[50px]">
          <Navigation />
        </div>
        <QueryProvider>{children}</QueryProvider>
      </body>
    </html>
  );
}
