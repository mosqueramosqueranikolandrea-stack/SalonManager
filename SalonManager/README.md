# 💇‍♀️ Sistema de Gestión de Salón

## 📌 Descripción del sistema

Este proyecto consiste en una aplicación de consola desarrollada en C# que permite gestionar un salón de belleza.
El sistema permite registrar clientes, administrar servicios y agendar citas, facilitando la organización de la información.

Además, implementa persistencia de datos mediante archivos CSV, lo que permite conservar la información entre ejecuciones del programa.

---

## 🎯 Objetivo

Desarrollar un sistema que aplique los conceptos de programación orientada a objetos (POO), estructuras de datos y operaciones CRUD, junto con persistencia de datos.

---

## ⚙️ Funcionalidades

### 👤 Gestión de clientes

* Registrar clientes
* Consultar lista de clientes
* Actualizar información de clientes
* Eliminar clientes

### 💇 Gestión de servicios

* Registrar servicios
* Listar servicios disponibles

### 📅 Gestión de citas

* Registrar citas
* Consultar citas registradas

---

## 🔄 Operaciones CRUD implementadas

| Operación | Descripción                 |
| --------- | --------------------------- |
| Create    | Crear clientes y citas      |
| Read      | Consultar clientes y citas  |
| Update    | Modificar datos de clientes |
| Delete    | Eliminar clientes           |

---

## 💾 Persistencia de datos

El sistema utiliza la librería **CsvHelper** para almacenar la información en archivos CSV:

* `clientes.csv`
* `citas.csv`

Esto permite que los datos se mantengan incluso después de cerrar la aplicación.

---

## 🧱 Estructura del proyecto

```
SalonManager
│
├── Modelos
│   ├── Cliente.cs
│   ├── Servicio.cs
│   └── Cita.cs
│
├── Servicios
│   ├── ClienteServicio.cs
│   ├── ServicioServicio.cs
│   └── CitaServicio.cs
│
├── Datos
│   ├── clientes.csv
│   └── citas.csv
│
└── Program.cs
```

---

## 🧠 Diagrama UML

El sistema está compuesto por las siguientes clases:

* Cliente
* Servicio
* Cita
* ClienteServicio
* ServicioServicio
* CitaServicio

Se implementa separación entre entidades y lógica de negocio mediante clases de servicio.

---

## 🛠️ Tecnologías utilizadas

* C#
* .NET
* CsvHelper

---

## ▶️ Ejecución del programa

1. Clonar el repositorio
2. Abrir en Visual Studio o VS Code
3. Ejecutar el proyecto:

```
dotnet run
```

---

## 📌 Ejemplo de uso

1. Registrar un cliente
2. Registrar una cita
3. Consultar clientes y citas
4. Cerrar el programa
5. Volver a ejecutarlo y verificar que los datos permanecen

---

## 🏆 Conclusión

El sistema cumple con los requisitos del taller, implementando correctamente operaciones CRUD, manejo de listas, programación orientada a objetos y persistencia de datos mediante archivos CSV.

---

## 👨‍💻 Autor

Proyecto desarrollado como parte de un taller académico de programación.
