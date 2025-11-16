# 🔐 CryptoKeyToolbox

CryptoKeyToolbox es una aplicación **.NET MAUI Blazor Hybrid** diseñada para generar claves, IDs únicos y herramientas relacionadas con seguridad y criptografía.  
Está inspirada en herramientas como generate-random.org, pero enfocada en desarrolladores y administradores de sistemas.

---

## 🚀 Características (en desarrollo)

### 🔒 Security
- **Authentication**
- **Tokens**
- **Cryptography**
  - ✔️ SSH Key Generator (RSA)
  - 🔜 Hash Generator (SHA256, SHA512, MD5)
  - 🔜 Salt Generator

### 🔑 UUID Tools
- ✔️ UUID Generator (v4)
- 🔜 Minecraft UUID conversion tools

---

## Arquitectura

El proyecto sigue una arquitectura limpia y modular:

```
CryptoKeyToolbox.sln
│
├── CryptoKeyToolbox.UI -> MAUI Blazor Hybrid (UI)
├── CryptoKeyToolbox.Domain -> Entidades e interfaces (Core)
├── CryptoKeyToolbox.App -> Lógica de negocio / servicios
└── CryptoKeyToolbox.Infrastructure -> Inyección de dependencias
```


## Tecnologías

- **.NET 8**
- **MAUI Blazor Hybrid**
- **MudBlazor** (UI Material Design)
- **RSA / Cryptography API**
- Arquitectura por capas (Domain / App / Infrastructure / UI)


## Cómo ejecutar

```bash
dotnet restore
dotnet build
dotnet maui run -f net8.0-windows
```


## Contribuciones

Este es un proyecto personal en desarrollo.
Las contribuciones, ideas y sugerencias son bienvenidas.