MVC UI Template - ASP.NET Core Customer Management System

A production-ready ASP.NET Core MVC template demonstrating enterprise-grade CRUD operations with advanced features including sorting, searching, pagination, and responsive Bootstrap UI.

Features

- Complete CRUD Operations - Create, Read, Update, Delete customer records
- Advanced Search - Multi-field search across customer attributes
- Dynamic Sorting - Click-to-sort on all table columns (ascending/descending)
- Pagination - Efficient data loading with configurable page size
- Responsive Design - Bootstrap 5 mobile-first interface
- Database Seeding - Automatic initialization with sample data
- Entity Framework Core - Code-first approach with SQL Server
- Form Validation - Client and server-side validation
- Success Notifications - User feedback with TempData alerts

Prerequisites

- .NET 6.0 SDK or higher
- SQL Server (Express/Developer/Standard)
- Visual Studio 2022 or VS Code
- Basic knowledge of C# and ASP.NET Core MVC

Technology Stack

- Framework: ASP.NET Core MVC
- ORM: Entity Framework Core
- Database: Microsoft SQL Server
- Frontend: Bootstrap 5, jQuery
- Validation: jQuery Validation & Unobtrusive Validation
- Architecture: MVC Pattern with Repository-like DbContext

Installation & Setup

 1. Clone the Repository

```bash
git clone https://github.com/RashedulHaqueRonjon/mvc-ui-template.git
cd mvc-ui-template
```

 2. Configure Database Connection

Update `appsettings.json` with your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MVCUITemplateDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

 3. Restore Dependencies

```bash
dotnet restore
```

 4. Run the Application

```bash
dotnet run
```

The application will automatically:
- Create the database if it doesn't exist
- Seed initial customer data
- Launch at https://localhost:5001


Project Structure

```
MVCUITemplate/
├── Controllers/
│   └── CustomerController.cs      # Main CRUD logic with sorting/filtering
├── Data/
│   ├── AppDbContext.cs            # EF Core DbContext
│   └── DbInitializer.cs           # Database seeding logic
├── Models/
│   └── Customer.cs                # Customer entity model
├── Views/
│   ├── Customer/
│   │   ├── Index.cshtml           # List view with search/sort/pagination
│   │   ├── Create.cshtml          # Create form
│   │   ├── Edit.cshtml            # Edit form
│   │   ├── Details.cshtml         # Details view
│   │   └── Delete.cshtml          # Delete confirmation
│   └── Shared/
│       ├── _Layout.cshtml         # Master layout
│       ├── _Navbar.cshtml         # Navigation partial
│       ├── _Pagination.cshtml     # Pagination partial
│       └── _SortableColumn.cshtml # Sortable column partial
├── wwwroot/
│   ├── css/
│   └── js/
├── appsettings.json
└── Program.cs                     # Application entry point
```


Key Implementation Highlights

 Pagination Logic

```csharp
int totalRecords = await customers.CountAsync();
int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

var paginatedList = await customers
    .Skip((pageNumber - 1) * PageSize)
    .Take(PageSize)
    .ToListAsync();
```

 Multi-Column Search

```csharp
customers = customers.Where(c =>
    (c.FirstName != null && c.FirstName.ToLower().Contains(lowerSearch)) ||
    (c.LastName != null && c.LastName.ToLower().Contains(lowerSearch)) ||
    (c.EmailAddress != null && c.EmailAddress.ToLower().Contains(lowerSearch)) ||
    (c.CompanyName != null && c.CompanyName.ToLower().Contains(lowerSearch))
);
```

 Dynamic Sorting

```csharp
customers = sortOrder switch
{
    "FirstName" => customers.OrderBy(c => c.FirstName),
    "FirstName_desc" => customers.OrderByDescending(c => c.FirstName),
    "LastName" => customers.OrderBy(c => c.LastName),
    // ... additional sort options
    _ => customers.OrderBy(c => c.FirstName)
};
```


Customization

 Change Page Size

In `CustomerController.cs`:

```csharp
private const int PageSize = 5; // Modify this value
```

 Add New Fields

1. Update `Customer.cs` model
2. Create migration: `dotnet ef migrations add AddNewField`
3. Update database: `dotnet ef database update`
4. Update views to display new fields

 Change Database Provider

Replace SQL Server with PostgreSQL, MySQL, or SQLite by updating:
- NuGet packages
- Connection string in `appsettings.json`
- `UseSqlServer()` in `Program.cs`


Screenshots
Feature			Preview
Customer List		Sortable table with search and pagination (Screenshots\customer-list.png)[Index.cshtml]
Customer Details Form	Populated fields with detail information  (Screenshots\details-form.png)[Details.cshtml]
Create Form		Validated form with Bootstrap styling (Screenshots\create-form.png)[Create.cshtml]
Edit Form			Pre-populated fields with update functionality (Screenshots\edit-form.png)[Edit.cshtml]
Delete Confirmation		Safe deletion with confirmation dialog (Screenshots\delete-confirmation-form.png)[Delete.cshtml]


Testing

 Manual Testing Checklist

- [ ] Create new customer record
- [ ] Edit existing customer
- [ ] Delete customer with confirmation
- [ ] Search by name, email, company
- [ ] Sort by each column (asc/desc)
- [ ] Navigate through pagination
- [ ] Validate form inputs
- [ ] Test responsive layout on mobile


Learning Outcomes

This project demonstrates proficiency in:

- ASP.NET Core MVC architecture
- Entity Framework Core ORM
- LINQ query optimization
- Asynchronous programming (async/await)
- Bootstrap responsive design
- Client-side and server-side validation
- Partial views and view components
- TempData for cross-request messaging
- Database initialization and seeding


Contributing

Contributions are welcome! Please feel free to submit a Pull Request.


License

This project is open source and available under the [MIT License].


Author

Rashedul Haque Ronjon

- LinkedIn: https://linkedin.com/in/rashedul-haque-ronjon
- Email: rashedul.haque.ronjon@outlook.com


Acknowledgments

- Bootstrap team for the excellent CSS framework
- Microsoft for ASP.NET Core and Entity Framework Core
- The open-source community


Need Custom Development?

If you need a similar system customized for your business needs, feel free to reach out!