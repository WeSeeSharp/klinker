import * as React from "react";

interface IMainContentProps {
  children: any;
}

export const MainContent = ({ children }: IMainContentProps) => {
  return (
    <div>
      {children}
    </div>
  );
};