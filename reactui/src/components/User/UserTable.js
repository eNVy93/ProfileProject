import React from "react";

export default function UserTable(props) {
  return (
    <table className="table table-striped" aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Username</th>
          <th>Password</th>
          <th>UserState</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {props.users.map((user) => (
          <tr key={user.id}>
            <td>{user.username} </td>
            <td>{user.password} </td>
            <td>{user.userState} </td>
            <button onClick={() => props.handleDeleteUser(user)}>delete</button>
            <button onClick={() => props.handleMarkAsDeleted(user)}>
              mark deleted
            </button>
            <button onClick={() => props.handleLogout(user)}>Log Out</button>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
