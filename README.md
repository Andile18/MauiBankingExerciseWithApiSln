# Banking API - Educational Assignment

## 📚 Project Overview

This is an educational project designed for learning ASP.NET Core Web API development, Entity Framework Core, and modern banking system concepts. This project simulates a banking system with comprehensive customer, account, and transaction management capabilities.

**Note:** This project is for educational purposes only and should not be used in production environments.

## 🎯 Learning Objectives

- Understanding ASP.NET Core Web API architecture
- Working with Entity Framework Core and Code-First migrations
- Implementing RESTful API endpoints
- Database design for financial applications
- Working with complex relationships between entities
- Understanding banking domain concepts

## 🏗️ Architecture

The project follows a clean architecture pattern with the following structure:

```
BankingApi/
├── Controllers/          # API endpoints
├── Data/                # Database context and migrations
├── Models/              # Entity models and DTOs
├── Migrations/          # EF Core database migrations
└── Properties/          # Application configuration
```

## 🗄️ Database Schema

The system manages the following core entities:

### Primary Entities
- **Customers**: Personal and business customer information
- **Banks**: Bank institution details
- **Accounts**: Customer bank accounts with balances
- **Transactions**: Financial transaction records
- **Assets**: Customer asset tracking
- **Auth**: Authentication and authorization records

### Lookup Tables
- **CustomerType**: Individual, Business, etc.
- **AccountType**: Checking, Savings, Credit, etc.
- **TransactionType**: Deposit, Withdrawal, Transfer, etc.
- **AuthType**: Various authentication methods
- **AssetType**: Property, Vehicle, Investment, etc.

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- SQL Server LocalDB or SQL Server instance
- Visual Studio 2022 or VS Code
- Postman or similar API testing tool (optional)

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone [repository-url]
   cd MauiBankingExerciseVNextSln
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update database connection string** (if needed)
   - Open `appsettings.json`
   - Modify the `DefaultConnection` string if using a different SQL Server instance

4. **Run the application**
   ```bash
   cd BankingApi
   dotnet run
   ```

5. **Access the API**
   - HTTP: `http://localhost:5224`
   - HTTPS: `https://localhost:7258`
   - Swagger UI: `https://localhost:7258/swagger`

## 🔌 API Endpoints

### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Create new customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer

### Accounts
- `GET /api/accounts` - Get all accounts
- `GET /api/accounts/{id}` - Get account by ID
- `POST /api/accounts` - Create new account
- `PUT /api/accounts/{id}` - Update account
- `DELETE /api/accounts/{id}` - Delete account

### Transactions
- `GET /api/transactions` - Get all transactions
- `GET /api/transactions/{id}` - Get transaction by ID
- `POST /api/transactions` - Create new transaction
- `PUT /api/transactions/{id}` - Update transaction
- `DELETE /api/transactions/{id}` - Delete transaction

### Banks
- `GET /api/banks` - Get all banks
- `GET /api/banks/{id}` - Get bank by ID
- `POST /api/banks` - Create new bank
- `PUT /api/banks/{id}` - Update bank
- `DELETE /api/banks/{id}` - Delete bank

### Lookup Data
- `GET /api/lookup/customertypes` - Get customer types
- `GET /api/lookup/accounttypes` - Get account types
- `GET /api/lookup/transactiontypes` - Get transaction types

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with LocalDB
- **ORM**: Entity Framework Core 9.0.8
- **API Documentation**: Swagger/OpenAPI
- **Serialization**: System.Text.Json with reference handling

## 📊 Key Features

1. **Database First Approach**: Uses Entity Framework Code-First migrations
2. **Auto-Migration**: Database is automatically created and seeded on startup
3. **Reference Cycle Handling**: JSON serialization configured to handle circular references
4. **Swagger Documentation**: Interactive API documentation available
5. **Comprehensive Models**: Rich domain models with proper relationships
6. **Seed Data**: Database is populated with sample data for testing

## 🎓 Assignment Instructions

### Create a .NET MAUI application to connect to the Banking Class Exercise API

This project uses WebAPI as a REST API and EntityFramework as the ORM to SQLServer.

1) This assignment will use the same banking application created in Assignment 9

2) Clone the provided solution.

3) Create a new repository for this assignment

4) Copy the provided solution into the new repository (without the .git folder)

5) Copy your existing Banking Application from Assignment 9 (or create a new solution if not complete) to the new repository. (without the .git folder)

6) Open the Visual Studio solution. Ensure both the BankingAPI project and the MAUI Banking app is included in the same project.

7) The project uses EF Migrations to create the database. Use your EF knowledge to create the database.

8) Run the BankingAPI project and study the Swagger Page to Learn the Operations from the API. Also test the API to see if it works correctly and the results are as expected.

9) Use the same application you built in Assignment 9 - MAUI Banking Application and change the application to use the provided API, instead of SQLite. The MAUI app should use the HttpClient class to communicate via Http to the BankingApi.

Create a visual user experience of the data in MAUI using ONLY the provided BankingAPI.

**Submission:**
- Commit the changes
- Push to the Remote Git Repository
- Submit the GitHub Repository URL as the assignment.

## 🧪 Testing

### Manual Testing
- Use Swagger UI at `https://localhost:7258/swagger`
- Test all CRUD operations for each entity
- Verify database relationships and data integrity

### Sample API Calls
```bash
# Get all customers
GET https://localhost:7258/api/customers

# Create a new customer
POST https://localhost:7258/api/customers
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@email.com",
  "phoneNumber": "1234567890",
  "customerTypeId": 1,
  "bankId": 1
}
```

## 📝 Database Migrations

The project uses Entity Framework Core migrations:

```bash
# Add new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## ⚠️ Important Notes

- **Educational Use Only**: This project is designed for learning purposes
- **No Security**: Authentication and authorization are not implemented
- **Sample Data**: The database is seeded with sample data for testing
- **LocalDB**: Uses SQL Server LocalDB by default
- **Development Mode**: Configured for development environment

## 📚 Learning Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [RESTful API Design Best Practices](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)

## 🤝 Contributing

This is an educational project. Students are encouraged to:
- Experiment with the code
- Add new features
- Improve existing functionality
- Share learning experiences

## 📄 License

This project is for educational purposes only. Please refer to your course materials for specific usage guidelines.

---

**Happy Learning! 🎓**

*Remember: The best way to learn is by doing. Explore the code, experiment with the APIs, and don't be afraid to break things - that's how we learn!*