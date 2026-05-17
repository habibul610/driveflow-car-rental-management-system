# 🚗 DriveFlow: Car Rental Management System

Welcome to **DriveFlow**! This is a complete, modern Car Rental Management System built using C# Windows Forms and Microsoft SQL Server. It has a beautiful, clean UI and even includes an AI chatbot to help customers find cars!

Whether you are a student, developer, or business owner, this guide will show you exactly how to install, set up, and use the project in simple, easy steps.

---

## ✨ Features

- **🛡️ 3 User Roles:**
  - **Admin:** Full control over the system, manage users, view earnings, and see business charts.
  - **Manager:** Manage the car fleet, approve bookings, handle returns, and manage customer bills.
  - **Customer:** Browse available cars, apply discount coupons, chat with the AI assistant, and book cars easily.
- **💳 Payment Gateway:** A clean payment screen where customers can pay using their card for instant booking approval.
- **🎟️ Discount Coupons:** Create coupon codes (like `WELCOME10` or `FREE50`) for customers to get instant discounts on their rentals.
- **🤖 AI Car Finder:** A built-in AI chatbot powered by Ollama that helps customers find the perfect car by answering their questions.
- **🎨 Beautiful Modern UI:** Clean rounded cards, beautiful colors, and a fully responsive layout.

---

## 🚀 How to Install and Run the Project

Follow these simple steps to get the project running on your computer.

### Step 1: Download the Project (Git Clone)
1. Open your terminal (Command Prompt or PowerShell) on your computer.
2. Navigate to the folder where you want to save the project.
3. Run the following command to clone the repository:
   ```bash
   git clone https://github.com/habibul610/DRIVEFLOW.git
   ```
4. Open the downloaded folder.

### Step 2: Set Up the Database in SSMS (SQL Server Management Studio)
1. Open **Microsoft SQL Server Management Studio (SSMS)** on your computer and connect to your local SQL Server (usually `localhost` or `.\SQLEXPRESS`).
2. In SSMS, click on **File > Open > File...** from the top menu.
3. Select the `database.sql` file located inside the project folder.
4. Click the **Execute** button (or press `F5`).
   - *This will automatically create a database named `CarRentingDB`, create all the necessary tables, and insert sample cars, coupons, and user accounts for you!*

### Step 3: Check the Database Connection String
1. Open the project solution (`CAR RENTAL MANAGEMENT SYSTEM.sln` or `.csproj`) in **Visual Studio 2022**.
2. In the Solution Explorer on the right, open the `DAL` folder and click on `DBConnection.cs`.
3. Look at the connection string line:
   ```csharp
   private static string connectionString = @"Server=localhost;Database=CarRentingDB;Trusted_Connection=True;TrustServerCertificate=True;";
   ```
   *(Note: If your SQL server uses a different name like `.\SQLEXPRESS`, simply change `localhost` to `.\SQLEXPRESS`).*

### Step 4: Set Up Ollama for AI Chat (Optional)
If you want to use the AI Car Finder chatbot, follow these steps:
1. Download and install **Ollama** from [https://ollama.com/download](https://ollama.com/download).
2. Open Command Prompt or PowerShell and run this command to download the fast AI model:
   ```bash
   ollama pull qwen2.5:0.5b
   ```
3. Keep Ollama running in the background while using the app.

### Step 5: Build and Run the Application
1. In Visual Studio, press `Ctrl + Shift + B` to build the project and ensure everything compiles successfully.
2. Press `F5` (or click the green **Start** button) to run the application!

---

## 🔑 Default Login Accounts

When the login screen appears, you can use any of these sample accounts created by the `database.sql` script:

### 1. Admin Account
- **Username:** `admin`
- **Password:** `Admin@123`
- *Use this to view earnings, manage users, and see system charts.*

### 2. Manager Account
- **Username:** `manager`
- **Password:** `Manager@123`
- *Use this to add/edit cars, manage discount coupons, approve bookings, and process car returns.*

### 3. Customer Account
- **Username:** `sasa`
- **Password:** `sasasasa`
- *Use this to browse cars, chat with the AI, apply coupons, and make bookings.*

*(You can also click the **Sign Up** button on the login screen to create your own new customer account!)*

---

## 📖 How to Use the System

### 🛒 Booking a Car (Customer)
1. Log in as a Customer.
2. Click on **Browse Cars & Book** from the left menu.
3. You will see a beautiful grid of available cars on the left and a **Checkout Card** on the right.
4. Click **Select** on the car you want to rent.
5. Choose your Pickup Date and Expected Return Date.
6. Select your payment method (**Card** for instant approval, or **Late Payment** for manager review).
7. If you have a coupon (like `WELCOME10`), type it in the coupon box and click **Apply** to see your price drop!
8. Click **✅ Confirm Booking**. If you selected Card payment, enter your card details in the secure popup to finish.

### 🎟️ Managing Coupons (Manager)
1. Log in as a Manager.
2. Click on **Manage Coupons** from the left menu.
3. Type a new Coupon Code (for example, `SUMMER20`) and select the discount percentage (e.g., `20%`).
4. Click **Create Coupon**. Customers can now use this code instantly!
5. You can also select any existing coupon in the table and click **Toggle Active Status** to turn it on or off.

### 🔄 Returning a Car & Billing (Manager)
1. When a customer brings a car back, log in as a Manager and click **Manage Bookings**.
2. Select the active booking from the table and click **Process Return**.
3. The system will automatically calculate the final bill, apply any coupon discounts, and check if there are any late fees!

---

## 🛠️ Built With

- **Language:** C# (.NET Windows Forms)
- **Database:** Microsoft SQL Server (ADO.NET)
- **AI Integration:** Ollama (`qwen2.5:0.5b`)
- **Security:** BCrypt password hashing

Enjoy using **DriveFlow**! If you have any questions or suggestions, feel free to explore the code and customize it to your needs.
