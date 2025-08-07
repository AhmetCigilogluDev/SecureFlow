# 🔐 SecureFlow

Kurumsal düzeyde geliştirilmiş, **JWT Authentication** destekli, **katmanlı mimariye** sahip bir **C# (.NET 6) Web API** ve **React.js** tabanlı Login uygulamasıdır.

---

## 🚀 Özellikler

- JWT tabanlı kimlik doğrulama sistemi  
- Katmanlı (Layered) mimari  
- RESTful API  
- React tabanlı frontend arayüz  
- React Router ile yönlendirme  
- Token yönetimi (`localStorage`)  
- Genişletilebilir servis & validasyon altyapısı  

---

## 🔧 Kullanılan Teknolojiler

| Katman     | Teknoloji                     |
|------------|-------------------------------|
| Backend    | .NET 6 Web API, C#            |
| Frontend   | React.js (Vite)               |
| Auth       | JWT (JSON Web Token)          |
| HTTP       | Axios                         |
| Routing    | React Router                  |
| State Mgmt | React Hooks (`useState`, `useNavigate`) |
| Database   | (Planlanıyor: SQL Server + EF Core)     |

---

## 🧱 Proje Mimarisi

SecureFlow/
│
├── API/ → ASP.NET Core Web API (Controller, Middleware)
├── Application/ → DTOs, Interfaces, Validations
├── Domain/ → Entities, ValueObjects
├── Infrastructure/ → Service Implementations (UserService, JwtTokenGenerator)
├── Frontend/ → React App (Login Page, Routing, CSS)
├── Shared/ → Ortak modeller, sabitler (opsiyonel)
└── SecureFlow.sln → Solution dosyası



## 🛠️ Kurulum

```bash
# Backend için
cd SecureFlow
dotnet build
dotnet run

# Frontend için
cd Frontend
npm install
npm run dev


.gitignore
node_modules/
bin/
obj/
.vscode/
.env
*.db
*.dll
*.pdb
*.exe
