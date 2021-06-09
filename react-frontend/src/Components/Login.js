import React, { useState} from 'react'
import {Navbar, Nav, Button, Form, FormControl, Container, Modal} from 'react-bootstrap'
import {useDispatch} from "react-redux";
import {login} from "../Actions/User";
import Input from "./Input";

const Login = () => {
    const [username, setUsername] = useState("")
    const [password, setPassword] = useState("")
    const dispatch = useDispatch()

    return (
        <>
        <div className='authorization'>
            <div className="authorization__header">Авторизация</div>
            <Input value={username} setValue={setUsername} type="text" placeholder="Введите email"/>
            <Input value={password} setValue={setPassword} type="password" placeholder="Введите пароль"/>
            <button className="authorization__btn" onClick={() => fetch('https://localhost:5001/token',{
                method:'POST',
                headers: { 
                    'Accept':'application/json',
                    'Content-Type': 'application/json' },
                body: JSON.stringify({ "username": "admin",  "password":"12345" })
            })
            .then(response => response.json())}>Войти</button>
        </div>
        </>
    );
};

export default Login;
