"use client";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

// A wrapper that provides react-query and react-query-devtools.
const client = new QueryClient();
function QueryProvider({ children }: { children: React.ReactNode }) {
  return (
    <QueryClientProvider client={client}>
      {children}
      <ReactQueryDevtools initialIsOpen={true} />
    </QueryClientProvider>
  );
}
export { QueryProvider };
