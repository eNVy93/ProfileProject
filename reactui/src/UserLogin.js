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
        // const formData = new FormData(form.current);
        // if(!formData.get("userName")?.length>3){
        //     console.warn(`Name length should be more than 3 symbols`);
        //     return;
        // }
        // if(!formData.get("password")?.length>3){
        //     console.warn(`Password length should be more than 4 symbols`);
        //     return;
        // }
        
        //event.preventDefault()
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
    <div>
      <p>LogIn</p>
      <form  onSubmit={handleSubmit}>
        <label>
        UserName:
          <input type="text" name="userName" value={user.userName} onChange={handleChangeUserName}/>
        </label>
        <label>
        Password:
          <input type="password" name="password" value={user.password} onChange={handleChangePassword}/>
        </label>
        <button type="submit">Log In</button>
      </form>
      <p>
        {user.userName}{' '}
        {user.password}{' '}
      </p>
    </div>
  );
}

