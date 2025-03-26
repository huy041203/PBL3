Folder structure
/PatientManagementSystem

│── /Controllers

│   ├── AdminController.cs

│   ├── AuthController.cs

│   ├── DoctorController.cs

│   ├── PatientController.cs

│   ├── AppointmentController.cs

│   ├── MedicalRecordController.cs

│   ├── DiagnosisController.cs

│   ├── PrescriptionController.cs

│   ├── TestResultController.cs

│   ├── DepartmentController.cs

│── /Models

│   ├── User.cs

│   ├── Department.cs

│   ├── Doctor.cs

│   ├── Patient.cs

│   ├── Appointment.cs

│   ├── MedicalRecord.cs

│   ├── ClinicalDiagnosis.cs

│   ├── Prescription.cs

│   ├── Medicine.cs

│   ├── TestResult.cs

│   ├── MedicalStaff.cs

│── /Views

│   ├── /Admin

│   │   ├── Dashboard.cshtml

│   ├── /Auth

│   │   ├── Login.cshtml

│   │   ├── Register.cshtml

│   ├── /Doctor

│   │   ├── Dashboard.cshtml

│   │   ├── Patients.cshtml

│   ├── /Patient

│   │   ├── Dashboard.cshtml

│   │   ├── Appointments.cshtml

│   │   ├── MedicalRecords.cshtml

│── /ViewModels

│   ├── RegisterViewModel.cs

│   ├── LoginViewModel.cs

│   ├── AppointmentViewModel.cs

│── /Data

│   ├── AppDbContext.cs

│   ├── DbInitializer.cs

│── /Repositories

│   ├── IGenericRepository.cs

│   ├── GenericRepository.cs

│   ├── IAppointmentRepository.cs

│   ├── AppointmentRepository.cs

│── /Services

│   ├── EmailService.cs

│── /wwwroot

│   ├── /css

│   ├── /js

│   ├── /images

│── appsettings.json

│── Program.cs

│── Startup.cs

│── PatientManagementSystem.csproj

