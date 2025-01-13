import React from 'react'
import { useState, useEffect } from 'react';

export default function UserLogin() {
    const [user, setUser] = useState({
        userName: '',
        password: '',
        passwordHash: ''
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

        fetch('https://localhost:7062/api/users/login', { 
                method: 'POST', 
                body: JSON.stringify(user), 
                headers: { 'Content-Type': 'application/json' }, 
            })
            .then(res => res.json())
            .then(json => console.log(`USER ${user.userName} Logged IN`))
            .catch((err) => console.log(err))

        
    }
    return (
    <div className='card'>
      <p className='title'>LogIn</p>
      <form  onSubmit={handleSubmit}>
        <div className='input'>
          <p className='label'>UserName:</p>
          <input type="text" name="userName" value={user.userName} onChange={handleChangeUserName}/>
        </div>
        <div className='input'>
          <p className='label'>Password:</p>
          <input type="password" name="password" value={user.password} onChange={handleChangePassword}/>
          <button type="submit">Log In</button>
        </div>
      </form>
      <p>
        {user.userName}{' '}
        {user.password}{' '}
      </p>
    </div>
  );
}

