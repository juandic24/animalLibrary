# 🐾 Animal Library API

RESTful API built with ASP.NET for managing an animal library, including classification by groups and habitats.

---

## 🚀 Tech Stack

- **Backend:** ASP.NET Web API
- **Database:** PostgreSQL
- **Architecture:** Layered (Controllers, Services, Repositories, DTOs)

---

## 📊 Database Design

The API is based on a relational database with the following entities:

- **Animals**
- **Groups**
- **Habitats**

### Relationships

- Each **Animal** belongs to:
  - One **Group**
  - One **Habitat**

---

## 🧩 Entity Overview

### 🐶 Animals
- Id
- Name
- ScientificName
- Description
- ImageUrl
- GroupId
- HabitatId

### 🧬 Groups
- Id
- Name

### 🌍 Habitats
- Id
- Name

---

## 📌 Features

- CRUD operations for:
  - Animals
  - Groups
  - Habitats
- Clean separation of concerns (Controllers / Services / Repositories)
- DTO-based data transfer
- PostgreSQL integration
- Async programming
- EntityFrameworkCore


---

## 🔗 API Endpoints

### Animals endpoints
- `GET /api/animals` get all animals
- `GET /api/animals/{id}` get one specific animal
- `POST /api/animals` create new animal
- `PUT /api/animals/{id}` update an animal
- `DELETE /api/animals/{id}` delete an animal

### Groups endpoints
- `GET /api/groups` get all groups
- `GET /api/groups/{id}` get one specific group
- `POST /api/groups` create new group
- `PUT /api/groups/{id}` update a group
- `DELETE /api/groups/{id}` delete a group
- `GET /api/groups/{id}/animals` get all the animals in one group
  
### Habitats

- `GET /api/habitats` get all habitats
- `GET /api/habitats/{id}` get one specific habitat
- `POST /api/habitats` create new habitat
- `PUT /api/habitas/{id}` update a habitat
- `DELETE /api/habitats/{id}` delete a habitat
- `GET /api/habitats/{id}/animals` get all the animals in one habitat


---

## 🗄️ Entity-Relationship Diagram

> <img width="746" height="328" alt="ERDiagram" src="https://github.com/user-attachments/assets/f6bbb350-8680-4558-8289-9bdd44fdd9c4" />

