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

 ---

 Imagenes del Swagger
 
<img width="576" height="741" alt="s1" src="https://github.com/user-attachments/assets/50d6b59f-483a-40b9-b789-ee5f39097423" />
<img width="576" height="303" alt="s2" src="https://github.com/user-attachments/assets/345fa0c0-5718-4bab-8619-29b4efd3fc80" />
<img width="576" height="279" alt="s3" src="https://github.com/user-attachments/assets/09bdb1c0-112d-496d-9356-ad446f1b1c2b" />
<img width="576" height="259" alt="s4" src="https://github.com/user-attachments/assets/511f9167-934e-4276-a0ed-04def9e1e4cf" />

![Uploading s4.png…]()

<img width="576" height="276" alt="s5" src="https://github.com/user-attachments/assets/bfaa29eb-24cb-4289-be06-c5d189d7a01b" />


<img width="576" height="306" alt="s6" src="https://github.com/user-attachments/assets/f6e60cb8-14d6-40c0-9cae-afad15dc6095" />


<img width="576" height="257" alt="s7" src="https://github.com/user-attachments/assets/d90aedc4-e1dc-4f1e-b9a2-979d36db7ffc" />


<img width="576" height="287" alt="s8" src="https://github.com/user-attachments/assets/41c2c0de-1120-4cb9-a66c-62d8b71b2fe9" />


<img width="576" height="264" alt="s9" src="https://github.com/user-attachments/assets/7ea7ede4-168d-4f26-b0f8-7087b8951043" />


<img width="576" height="398" alt="s10" src="https://github.com/user-attachments/assets/c22bd3ad-0623-48fe-b7fc-af12f65b357a" />







