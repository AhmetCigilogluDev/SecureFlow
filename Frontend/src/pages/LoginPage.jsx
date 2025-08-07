import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

import "./LoginPage.css"; // CSS dosyasını içe aktar

export default function LoginPage() {
  const [username, setUsername] = useState("");   // kullanıcı adını tutan state, doldur formu
  const [password, setPassword] = useState("");
  const navigate = useNavigate(); // yönlendirme hook'u

  const handleLogin = async () => {              // axios ile backend'e istek atma
    try {
      const res = await axios.post("http://localhost:5161/api/auth/login", {
        username,
        password,

      });

      
        console.log("Login response:", res.data);

      const token = res.data.token;
      localStorage.setItem("token", token); //Token'ı localStorage'a kaydet

      console.log("Login successful. Token:", token);
      navigate("/dashboard"); //  Login başarılı olursa Dashboard'a yönlendir
    } catch (err) {
      console.error("Login failed:", err.response?.data || err.message);
    }
  };

  return (
    <div className="login-container">
        <div className="login-box">
              <h2>Login</h2>
      <input
        type="text"
        placeholder="Username"
        onChange={(e) => setUsername(e.target.value)}
        value={username}
      />
      <br />
      <input
        type="password"
        placeholder="Password"
        onChange={(e) => setPassword(e.target.value)}
        value={password}
      />
      <br />
      <button onClick={handleLogin}>Login</button>


        </div>
    
    </div>
  );
}
