import axios from 'axios'
import {setUser} from "../Reducers/userReducer";

export const login =  (username1, password1) => {
    return async dispatch => {
        try {
            fetch('https://localhost:5001/token',{
                method:'POST',
                headers: { 
                    'Accept':'application/json',
                    'Content-Type': 'application/json' },
                body: JSON.stringify({ "username": "admin",  "password":"12345" })
            })
            .then(response => response.json())
        } catch (e) {
            alert(e.response.data.message)
        }
    }
}