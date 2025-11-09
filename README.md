# 🧾 Sistema de Ventas (.NET Core MVC)

Aplicación web desarrollada en **.NET Core MVC** que permite gestionar productos, clientes, usuarios y ventas dentro de un entorno de punto de venta.  
El proyecto sigue una **arquitectura en capas** para garantizar una buena separación de responsabilidades, escalabilidad y mantenimiento a largo plazo.

---

## 🚀 Tecnologías Utilizadas

- 🟣 **.NET Core (MVC / Entity Framework Core)**  
- 💻 **C# 10+**  
- 🗄️ **SQL Server**  
- 🌐 **HTML, CSS, JavaScript, Bootstrap**  
- 🧩 **Inyección de dependencias (IoC)**  
- 🔍 **LINQ**  
- ⚙️ **Visual Studio 2022**

---

## 🏗️ Estructura del Proyecto

SolucionSistemaVenta/
│
├── SistemaVenta.Entity/ # Entidades del dominio (Producto, Cliente, Venta, Usuario, etc.)
├── SistemaVenta.DAL/ # Acceso a datos y contexto de base de datos
├── SistemaVenta.BLL/ # Lógica de negocio (servicios, validaciones, cálculos)
├── SistemaVenta.IOC/ # Configuración de inyección de dependencias
└── SistemaVenta.AplicacionWeb/ # Aplicación web (controladores, vistas y archivos estáticos)


---

## 🧠 Descripción del Sistema

El sistema permite administrar todo el ciclo de ventas de una organización:

- 📦 **Gestión de productos:** registro, actualización y control de stock.  
- 👥 **Gestión de clientes y usuarios:** altas, bajas y modificaciones.  
- 💰 **Registro de ventas:** cálculo automático de totales e impuestos.  
- 📊 **Reportes y consultas:** listados de ventas y productos.  
- 🔒 **Gestión de roles y permisos** (si aplica).  

---

## 🧩 Arquitectura

El sistema está diseñado con una arquitectura **multicapa**, basada en principios **Clean Architecture** y **SOLID**.

**Flujo general del sistema:**
Interfaz Web (MVC)
↓
Capa BLL (Reglas de negocio)
↓
Capa DAL (Acceso a datos)
↓
Base de datos SQL Server


**Capas principales:**
- **Entity:** modelos y entidades del dominio.  
- **DAL:** acceso a datos con Entity Framework Core.  
- **BLL:** lógica de negocio central.  
- **IOC:** configuración de inyección de dependencias.  
- **AplicacionWeb:** interfaz visual e interacción con el usuario.

---

## ⚙️ Instalación y Configuración

1️⃣ Clonar el repositorio
git clone https://github.com/Fermoyano07/sistema-ventas-net-core

2️⃣ Abrir la solución
Abrí SolucionSistemaVenta.sln con Visual Studio 2022.

3️⃣ Configurar la base de datos
Editá el archivo appsettings.json dentro del proyecto SistemaVenta.AplicacionWeb:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SistemaVentaDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

4️⃣ Aplicar migraciones
Ejecutá en la Package Manager Console:
Update-Database

5️⃣ Ejecutar la aplicación
Presioná F5 o seleccioná Iniciar sin depuración para ejecutar el sistema.

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/4de0af22-d503-4d07-a080-b03ca68b5635" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/09a94d6c-5b68-406e-ba7b-6e8ec01db1ae" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/f02fe11d-e6dc-42f2-b063-b3f953643aaf" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/26eff2d6-fb0f-44c4-9961-bb16eeaaaa51" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/a8fee6b0-1238-4f5e-b7c3-60739d7c96a6" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/c046230a-d7d2-4b7a-85b4-d65b97353db6" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/32007c4d-c1e3-45b3-8e59-8bcab82ef091" />
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/49955e16-c09f-4cf6-b366-4574e9466a6f" />

👨‍💻 Autor

Fernando Moyano
Desarrollador de Software | Técnico Superior en Desarrollo de Software
📍 Argentina

🔗 GitHub https://github.com/Fermoyano07

🔗 LinkedIn: https://www.linkedin.com/in/fermoyano-dev/

🔗 Portfolio: https://fermoyano07.github.io/Portafolio-Fer/







