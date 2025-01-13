import React from "react";
import { useState, useEffect } from "react";
import UserTable from "./UserTable";
import UserCreate from "./UserCreate";
import UserLogin from "./UserLogin";

export default function UserPage() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [fetchNeeded, setFetchNeeded] = useState(true);
  const [renderLogin, setRenderLogin] = useState(true);
  const [renderRegister, setRenderRegister] = useState(false);

  useEffect(() => {
    populateUserData();
  }, []);

  useEffect(() => {
    populateUserData();
  }, [fetchNeeded]);

  async function populateUserData() {
    const response = await fetch("https://localhost:7062/api/users/all");
    const data = await response.json();

    data.filter((d) => d.IsDeleted === false);

    setUsers(data);
    setLoading(false);
    setFetchNeeded(false);
  }

  async function deleteUser(user) {
    fetch("https://localhost:7062/api/users/delete", {
      method: "POST",
      body: JSON.stringify(user),
      headers: { "Content-Type": "application/json" },
    })
      .then((res) => {
        setFetchNeeded(true);
      })
      .catch((err) => console.log(err));
  }

  async function markAsDeleted(user) {
    fetch("https://localhost:7062/api/users/markdeleted", {
      method: "POST",
      body: JSON.stringify(user),
      headers: { "Content-Type": "application/json" },
    })
      .then((res) => res.json())
      .catch((err) => console.log(err));
  }

  async function logout(user) {
    fetch("https://localhost:7062/api/users/logout", {
      method: "POST",
      body: JSON.stringify(user),
      headers: { "Content-Type": "application/json" },
    })
      .then((res) => res.json())
      .catch((err) => console.log(err));
  }
  function renderUserTable(users) {
    return (
      <UserTable
        users={users}
        handleDeleteUser={deleteUser}
        handleMarkAsDeleted={markAsDeleted}
        handleLogout={logout}
      />
    );
  }
  function renderLoginOrRegister() {
    if (renderRegister) {
      return <UserCreate />;
    } else if (renderLogin) {
      return <UserLogin />;
    }
  }
  function render() {
    let contents = loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      renderUserTable(users)
    );

    /* TODO Create modals for register and login forms */
    return (
      <div className="App">
        <div>
          <h1 id="tabelLabel">User list</h1>
          {contents}
          <p>TODO: </p>
          <p>* Auto refresh after creating</p>
        </div>

        <div>
          <button
            type="submit"
            onClick={() => {
              setRenderLogin(true);
              setRenderRegister(false);
            }}
          >
            Click here to login
          </button>
          <button
            type="submit"
            onClick={() => {
              setRenderLogin(false);
              setRenderRegister(true);
            }}
          >
            Click here to register
          </button>
        </div>

        <div className="container">{renderLoginOrRegister()}</div>
      </div>
    );
  }
  return render();
}
