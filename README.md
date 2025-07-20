# e-Shift Household Goods Shifting System

The **e-Shift Household Goods Shifting System** is a desktop application developed using **C#** and **Windows Forms**, designed to automate and streamline the workflow of a modern logistics and transport company. It manages customer job requests, resource allocation (trucks, drivers, assistants, and containers), and generates professional reports and invoices.

---

## **Features**
- **Customer & Job Management**: Create, edit, and track customer information and job requests.
- **Resource Allocation**: Assign trucks, employees, and other transport resources.
- **Report Generation**: Generate PDF reports (customers, jobs, resources, revenue) using QuestPDF.
- **Invoice Management**: Automatically generate detailed PDF invoices for completed jobs.
- **Authentication & Security**:
  - Secure password storage using **BCrypt**.
  - Configurable **SMTP email notifications**.
- **Modern UI**: Built with **MaterialSkin.2** for a modern, responsive look.
- **Layered Architecture**: Clean separation of UI, business logic, and data access.

---

## **System Architecture**

The system follows a **Layered Architecture**:

1. **Presentation Layer (UI)**  
   - Built with Windows Forms (`EShift.Forms`).
   - Provides dashboards (Admin, Customer) and interactive user controls.

2. **Business Logic Layer (BLL)**  
   - Located in `/Business/Services/` and `/Business/Interfaces/`.
   - Handles all core business logic and rules.
   - Interacts with repositories for data persistence.

3. **Repository Layer (DAL)**  
   - Located in `/Repositories/Services/` and `/Repositories/Interfaces/`.
   - Implements CRUD operations using **Dapper** for high-performance database access.

4. **Models Layer**  
   - Contains all POCOs (e.g., `Job`, `CustomerModel`, `Employee`, `Truck`) in `/Models/`.

5. **Utilities and Helpers**  
   - `DbExecutor` for database queries.
   - `PasswordHelper` for password hashing and verification.
   - `PdfReportGenerator` for professional PDF generation.

---

## **Technologies & Libraries**
- **.NET 6.0 (C#)**
- **Windows Forms**
- **Dapper** (micro-ORM)
- **MySQL / SQL Server** (database)
- **BCrypt.Net** (password hashing)
- **QuestPDF** (PDF generation)
- **MaterialSkin.2** (modern UI components)
- **FluentValidation** (model validation)

---

## **Installation & Setup**

### **Prerequisites**
- **Visual Studio 2022** (with .NET Desktop Development workload).
- **.NET 6.0 SDK** or newer.
- **XAMPP** (MySQL server) or equivalent SQL database.
- **NuGet** (for dependency restoration).

### **Steps to Run**
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/username/eshift-management-system.git
   ```

2. **Open the Project**:  
   Launch Visual Studio and open the `.sln` file.

3. **Restore Dependencies**:  
   Visual Studio will automatically restore NuGet packages. If not, right-click the solution and select **Restore NuGet Packages**.

4. **Configure the Database**:
   - Start MySQL (via XAMPP).
   - Create a schema (e.g., `eshift_db`).
   - Execute the `E-Shift Database Creation Script.sql`.
   - Update `App.config` connection string:
     ```xml
     <connectionStrings>
       <add name="DefaultConnection"
            connectionString="Server=localhost;Database=eshift_db;Uid=root;Pwd=;"
            providerName="MySql.Data.MySqlClient" />
     </connectionStrings>
     ```

5. **Email Configuration**:  
   Update the `<appSettings>` section in `App.config` with SMTP credentials:
   ```xml
   <appSettings>
     <add key="SmtpHost" value="smtp.gmail.com" />
     <add key="SmtpPort" value="587" />
     <add key="SmtpUser" value="youremail@example.com" />
     <add key="SmtpPass" value="your-app-password" />
   </appSettings>
   ```

6. **Build & Run**:
   - Set **platform target** to **x64** (Project → Properties → Build).
   - Press **F5** to build and launch the application.

---

## **Key Components**

- **`DbExecutor`**: Provides asynchronous methods (`QueryAsync`, `ExecuteAsync`) for executing SQL commands using Dapper.
- **`PasswordHelper`**: Uses BCrypt for secure password hashing and verification.
- **`PdfReportGenerator`**: Generates customer reports, resource lists, revenue reports, and invoices with branding and styling.
- **Repositories & Services**:
  - **`IRepository<T>`** defines standard CRUD operations.
  - Entity-specific repositories and services extend these interfaces for custom logic.

---

## **Challenges & Resolutions**
- **Cross-Platform Development**: Visual Studio is not available on macOS.  
  Initially tried **VMWare Fusion**, which was too slow. Resolved by using **Parallels Desktop** (student license), enabling smooth Windows virtualization and seamless Visual Studio integration.

- **QuestPDF Native Dependency**: Resolved platform mismatches by enforcing **x64 build target** and initializing QuestPDF at the application startup.

- **UI Workflow Bug**: Fixed duplicate job creation by refactoring `PlaceJobForm` to follow the Single Responsibility Principle, delegating persistence to the parent pane.

---

## **License**
This project is released under the MIT License.

---

## **Repository**
**Source Code:** [https://github.com/DewminaUdayashan/eshift-management](https://github.com/DewminaUdayashan/eshift-management)

---

## **Author**
Developed by **[Dewmina Udayashan](https://github.com/DewminaUdayashan)** (2025).
