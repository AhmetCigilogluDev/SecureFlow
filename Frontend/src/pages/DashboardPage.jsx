import React from "react";
import { useNavigate } from "react-router-dom";
import "./DashboardPage.css";

export default function DashboardPage() {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("token"); // Token'ı sil
    navigate("/"); // Login sayfasına yönlendir
  };

  return (
    <div className="dashboard-container">
      <div className="dashboard-card">
        <h1>🎉 Hoş geldiniz!</h1>
        <p>Giriş başarılı. Güvenli paneldesiniz.</p>
        <button onClick={handleLogout}>Çıkış Yap</button>
      </div>
    </div>
  );
}
