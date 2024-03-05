import React from 'react';
import { useState, useEffect } from 'react';

import UserCreate from './UserCreate';
import UserLogin from './UserLogin';
export default function App (){
    const displayName = App.name;

    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);
    const [fetchNeeded, setFetchNeeded] = useState(true);

useEffect(() => {
    populateUserData()
}, []);



useEffect(() => {
        populateUserData()
}, [fetchNeeded]);

     function renderForecastsTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Username</th>
                        <th>Password</th>
                        <th>UserState</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.username} </td>
                            <td>{user.password} </td>
                            <td>{user.userState} </td>
                            <button onClick={(() => deleteUser(user))}>delete</button> 
                            <button onClick={(() => markAsDeleted(user))}>mark deleted</button> 
                            <button onClick={(() => logout(user))}>Log Out</button> 
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    function render() {
        let contents = loading
            ? <p><em>Loading...</em></p>
            : renderForecastsTable(users);

        return (
            <div>
                <h1 id="tabelLabel" >User list</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <p>TODO: </p>
                <p>* Auto refresh after creating</p>
                <UserCreate></UserCreate>
                {contents}
                <UserLogin></UserLogin>
            </div>
        );
    }

    async function populateUserData() {
        const response = await fetch('https://localhost:7062/api/users/all');
        const data = await response.json();

        data.filter(d=> d.IsDeleted === false)

        setUsers(data);
        setLoading(false);
        setFetchNeeded(false);
    }

    async function deleteUser(user){
        fetch('https://localhost:7062/api/users/delete', { 
                method: 'POST', 
                body: JSON.stringify(user), 
                headers: { 'Content-Type': 'application/json' }, 
            })
            .then(res => {
                setFetchNeeded(true)
            })
            .catch((err) => console.log(err))
            
    }

    async function markAsDeleted(user){
        fetch('https://localhost:7062/api/users/markdeleted', { 
                method: 'POST', 
                body: JSON.stringify(user), 
                headers: { 'Content-Type': 'application/json' }, 
            })
            .then(res => res.json())
            .catch((err) => console.log(err))
    }

    async function logout(user){
        fetch('https://localhost:7062/api/users/logout', { 
                method: 'POST', 
                body: JSON.stringify(user), 
                headers: { 'Content-Type': 'application/json' }, 
            })
            .then(res => res.json())
            .catch((err) => console.log(err))
    }

    return render();
}
