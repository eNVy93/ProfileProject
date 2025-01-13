import React from "react";
import "./App.css";
import { Route, Routes } from 'react-router-dom';
import BankStatementPage from "./components/BankStatement/BankStatementPage";
import { NavMenu } from "./components/NavMenu";
import AppRoutes from './AppRoutes';
export default function App() {
  const displayName = App.name;

  function render() {
    return (
      <div className="App">
        {/* <UserPage /> */}
        {/* <NavMenu />
        <BankStatementPage /> */}
        <NavMenu />
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, requireAuth, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
            //element={requireAuth ? <AuthorizeRoute {...rest} element={element} /> : element}
          })}
        </Routes>
      </div>
    );
  }

  return render();
}
