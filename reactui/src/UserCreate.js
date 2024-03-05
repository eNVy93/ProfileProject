import React from 'react'
import { useState, useEffect } from 'react';

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
    <div>
      <p>UserCreate</p>
      <form  onSubmit={handleSubmit}>
        <label>
        UserName:
          <input type="text" name="userName" value={user.userName} onChange={handleChangeUserName}/>
        </label>
        <label>
        Password:
          <input type="password" name="password" value={user.password} onChange={handleChangePassword}/>
        </label>
        <button type="submit">Create</button>
      </form>
      <p>
        {user.userName}{' '}
        {user.password}{' '}
      </p>
    </div>
  );
}

