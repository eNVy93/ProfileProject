import React from "react";

export default function BankStatementTable(props) {
  //TODO padaryti kazka geriau nei TABLE
  // TODO pagination
  // TODO filtering
  return (
    <div className="container">
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Acc. Number</th>
            <th>Date</th>
            <th>Beneficiary</th>
            <th>Gain/Loss</th>
            <th>Amount</th>
            <th>Currency</th>
            <th>Details</th>
          </tr>
        </thead>
        <tbody>
          {props.statements.map((statement) => (
            <tr key={statement.Id}>
              <td>{statement.accountNumber} </td>
              <td>{statement.date} </td>
              <td>{statement.beneficiary} </td>
              <td>{statement.dk} </td>
              <td>{statement.amount} </td>
              <td>{statement.currency} </td>
              <td>{statement.details} </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
