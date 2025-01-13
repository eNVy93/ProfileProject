import React from 'react'
import { useState, useEffect } from 'react';

import '../App.css'

export default function UserCreate() {
    const [user, setUser] = useState({
        userName: '',
        password: '',
        passwordHash: "#super#duper$hash123"
    })
    function handleChangeUserName(event){
        setUser({
            ...user,
            userName: event.target.value
           });
    }

    //useEffect(user)
    
    function handleChangePassword(event){
       setUser({
        ...user,
        password: event.target.value
       });
    }

    async function handleSubmit(event){
        fetch('https://localhost:7062/api/users/create', { 
                method: 'POST', 
                body: JSON.stringify(user), 
                headers: { 'Content-Type': 'application/json' }, 
            })
            .then(res => res.json())
            .then(json => setUser(json.user))
            .catch((err) => console.log(err))

        
    }
    return (
    <div className="card">
      <form  onSubmit={handleSubmit}>
      <p className='title'>Register</p>
        <div className='input'>
          <p className='label'>UserName:</p>
          <input type="text" name="userName" value={user.userName} onChange={handleChangeUserName}/>
        </div>
        <div className='input'>
          <p className='label'>Password:</p>
          <input type="password" name="password" value={user.password} onChange={handleChangePassword}/>
        <button type="submit">Create</button>
        </div>
      </form>
      <p>
        {user.userName}{' '}
        {user.password}{' '}
      </p>
    </div>
  );
}

