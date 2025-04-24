# 🩺 Doctor Appointment System

A **full-stack** application for scheduling and managing doctor–patient appointments.  
- **Backend:** ASP.NET Core Web API  
- **Frontend:** Angular SPA  

---

## 🚀 Features

- **User Management**  
  - View user profile  
  - List a user’s appointments  

- **Doctor Management**  
  - CRUD doctors  
  - Search by name or specialization  

- **Appointment Management**  
  - Book, update, cancel, approve, reject  
  - Enforce “no changes” within 2 days of the appointment  
  - Appointment codes for reference  

- **Reviews**  
  - Patients can leave a rating & comment  

---

## 🛠️ Technologies

| Layer     | Framework / Library          |
|-----------|------------------------------|
| Backend   | .NET 7, ASP.NET Core Web API |
| Data      | EF Core, SQL Server          |
| Frontend  | Angular 14, TypeScript       |
| Security  | Hashids (ID obfuscation)     |
| Patterns  | Repository & Service layers  |

---

## 📂 Solution Structure


---

## 🔌 API Endpoints (Backend)

### AppointmentController (`/api/appointment`)
| Verb   | Route                           | Description                                    |
|--------|---------------------------------|------------------------------------------------|
| `GET`  | `/api/appointment/user/{userId}/appointments`  | List appointments for a user       |
| `GET`  | `/api/appointment/doctor/{doctorId}/appointments` | List appointments for a doctor     |
| `GET`  | `/api/appointment/{id}`         | Get one appointment by its ID                   |
| `POST` | `/api/appointment`              | Book a new appointment                          |
| `PUT`  | `/api/appointment/{id}`         | Update appointment details                      |
| `PUT`  | `/api/appointment/{id}/approve` | Doctor approves an appointment                  |
| `PUT`  | `/api/appointment/{id}/reject`  | Doctor rejects an appointment                   |
| `PUT`  | `/api/appointment/{id}/cancel`  | User cancels an appointment                     |
| `DELETE` | `/api/appointment/{id}`       | Admin deletes an appointment                    |

### DoctorController (`/api/doctor`)
| Verb   | Route                         | Description               |
|--------|-------------------------------|---------------------------|
| `GET`  | `/api/doctor`                 | List all doctors          |
| `GET`  | `/api/doctor/{id}`            | Get one doctor by ID      |
| `POST` | `/api/doctor`                 | Add a new doctor          |
| `PUT`  | `/api/doctor/{id}`            | Update doctor info        |
| `DELETE` | `/api/doctor/{id}`          | Delete a doctor           |
| `GET`  | `/api/doctor/search?name=…`           | Search by name       |
| `GET`  | `/api/doctor/search?specialization=…` | Search by specialization |

### ReviewController (`/api/review`)
| Verb   | Route                         | Description               |
|--------|-------------------------------|---------------------------|
| `GET`  | `/api/review/doctor/{id}`     | List reviews for a doctor |
| `POST` | `/api/review`                 | Add a review (user)       |
| `DELETE` | `/api/review/{id}`          | Delete a review (admin)   |

---

## 🎨 Frontend (Angular) (To DO)

1. **Prerequisites**  
   - Node.js ≥ 14  
   - Angular CLI  

2. **Setup & Run**

   ```bash
   cd doctor-appointment-angular
   npm install
   ng serve --open
