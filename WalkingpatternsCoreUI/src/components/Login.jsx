
import React, { useState } from "react";
import { login } from "../services/authService";
import { useNavigate } from "react-router-dom";
import "./Login.css";

function Login() {

  const [username,setUsername] = useState("");
  const [password,setPassword] = useState("");

  const navigate = useNavigate();

  const handleLogin = async(e)=>{
    e.preventDefault();

    try{

      await login(username,password);


      navigate("/dashboard");

    }catch{
      alert("Invalid username or password");
    }
  }

  return (
    <div className="login-container">

      <div className="login-box">

        <h2>Login</h2>

        <form onSubmit={handleLogin}>

          <label>Username</label>
          <input 
            type="text"
            value={username}
            onChange={(e)=>setUsername(e.target.value)}
          />

          <label>Password</label>
          <input
            type="password"
            value={password}
            onChange={(e)=>setPassword(e.target.value)}
          />

          <button type="submit">Login</button>

        </form>

      </div>

    </div>
  );
}

export default Login;