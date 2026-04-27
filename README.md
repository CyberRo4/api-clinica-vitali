 API Gestión de Clínica Médica Vitali

Sistema desarrollado en .NET  para la gestión de una clínica médica, permitiendo administrar:

-  Pacientes  
-  Médicos  
-  Citas  
-  Historial clínico  

---

##  Características del API

- API REST completa (CRUD)  
- Autenticación con JWT 
- Documentación con Swagger 
- Login personalizado (HTML/CSS)  
- Arquitectura en capas (Controllers, Services, Models)  

---

##  Credenciales de acceso
Las credenciales se dan en el PDF entregado

---


---

##  Tecnologías utilizadas

- .NET 8  
- Entity Framework Core  
- MySQL  
- JWT (Json Web Token)  
- Swagger (OpenAPI)  
- HTML / CSS (Login)  

---

##  Ejecución del proyecto

Ejecuta el proyecto y abre en el navegador:

http://localhost:5000/swagger

---


---

##  Autenticación

1. Ir a `/index.html`  
2. Iniciar sesión  
3. El sistema guarda el token automáticamente  
4. Swagger se autentica sin necesidad de pegar token  

---

##  Endpoints principales

###  Paciente
- `GET /api/Paciente`  
- `GET /api/Paciente/{id}`  
- `POST /api/Paciente`  
- `PUT /api/Paciente/{id}`  
- `DELETE /api/Paciente/{id}`  

---

###  Médico
- `GET /api/Medico`  
- `POST /api/Medico`  
- `PUT /api/Medico/{id}`  
- `DELETE /api/Medico/{id}`  

---

###  Citas
- `GET /api/Cita`  
- `POST /api/Cita`  
- `PUT /api/Cita/{id}`  
- `DELETE /api/Cita/{id}`  

---

###  Historial Clínico
- `GET /api/Historial`  
- `POST /api/Historial`  

---

##  Arquitectura del proyecto

El proyecto está organizado en capas para una mejor estructura:

- **Controllers** → Manejan las peticiones HTTP  
- **Services** → Contienen la lógica de negocio  
- **Models** → Representan las entidades de la base de datos  
- **Data (DbContext)** → Conexión con la base de datos  

---

##  Seguridad

La API utiliza autenticación mediante **JWT**, protegiendo los endpoints y garantizando que solo usuarios autenticados puedan acceder a los servicios.

---

##  Autores

- Ronaldo Villalobos Fonseca  
- Melany Sofía Carvajal Gómez  

---

##  Estado del proyecto

 Proyecto finalizado  
 Base lista para futuras mejoras  
