import React from 'react'
import { useState, useEffect } from "react";
import UploadFile from "../User/UploadFile";
import BankStatementTable from "./BankStatementTable";

export default function BankStatementPage() {
    const [statements, setStatements] = useState({
        swedbankStatements: [],
        statementsLoading: true,
      });
    
      useEffect(() => {
        getSwedbankStatements();
      }, []);
    
      function renderStatementTable(swedbankStatements) {
        return <BankStatementTable statements={swedbankStatements} />;
      }
    
      function render() {
        let statementContents = statements.loading ? (
          <p>
            <em>Loading...</em>
          </p>
        ) : (
          renderStatementTable(statements.swedbankStatements)
        );
    
        /* TODO Create modals for register and login forms */
        return (
          <div>
            <UploadFile />
            <div>{statementContents}</div>
          </div>
        );
      }
    
      async function getSwedbankStatements() {
        const response = await fetch(
          "https://localhost:7062/api/bankstatement/get_all_swedbank"
        );
        const data = await response.json();
    
        setStatements({
          swedbankStatements: data,
          loading: false,
        });
      }
  return render();
}
