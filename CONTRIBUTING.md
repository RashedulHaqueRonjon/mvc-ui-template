Contributing to MVC UI Template

First off, thank you for considering contributing to this project!

The following is a set of guidelines for contributing to the MVC UI Template. These are mostly guidelines, not rules. Use your best judgment, and feel free to propose changes to this document in a pull request.

Table of Contents

- [Code of Conduct](code-of-conduct)
- [How Can I Contribute?](how-can-i-contribute)
  - [Reporting Bugs](reporting-bugs)
  - [Suggesting Enhancements](suggesting-enhancements)
  - [Pull Requests](pull-requests)
- [Development Setup](development-setup)
- [Code Style Guidelines](code-style-guidelines)
- [Commit Message Guidelines](commit-message-guidelines)
- [Testing Guidelines](testing-guidelines)

Code of Conduct

This project and everyone participating in it is governed by a simple principle: Be respectful and professional. By participating, you are expected to uphold this standard.

Our Standards

Positive behaviors include:
- Using welcoming and inclusive language
- Being respectful of differing viewpoints and experiences
- Gracefully accepting constructive criticism
- Focusing on what is best for the project and community
- Showing empathy towards other community members

Unacceptable behaviors include:
- Trolling, insulting/derogatory comments, and personal attacks
- Public or private harassment
- Publishing others' private information without permission
- Other conduct which could reasonably be considered inappropriate

How Can I Contribute?

Reporting Bugs

Before creating bug reports, please check existing issues to avoid duplicates. When creating a bug report, please include as many details as possible:

Bug Report Template:

```markdown
Description:
A clear and concise description of the bug.

Steps to Reproduce:
1. Go to '...'
2. Click on '...'
3. Scroll down to '...'
4. See error

Expected Behavior:
What you expected to happen.

Actual Behavior:
What actually happened.

Screenshots:
If applicable, add screenshots to help explain the problem.

Environment:
- OS: [e.g., Windows 10, macOS 12]
- .NET Version: [e.g., .NET 6.0]
- SQL Server Version: [e.g., SQL Server 2019]
- Browser: [e.g., Chrome 96, Firefox 95]

Additional Context:
Add any other context about the problem here.
```

Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

Enhancement Template:

```markdown
Feature Description:
A clear and concise description of what you want to happen.

Problem It Solves:
Describe the problem this feature would solve.

Proposed Solution:
Describe how you envision this feature working.

Alternatives Considered:
Describe any alternative solutions or features you've considered.

Additional Context:
Add any other context, mockups, or examples about the feature request.
```

Pull Requests

We actively welcome your pull requests!

Before Submitting a PR:
1. Fork the repository
2. Create a new branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Test your changes thoroughly
5. Commit your changes (see [Commit Message Guidelines](commit-message-guidelines))
6. Push to your branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

PR Checklist:
- [ ] Code follows the [Code Style Guidelines](code-style-guidelines)
- [ ] All tests pass
- [ ] New code has appropriate test coverage
- [ ] Documentation has been updated
- [ ] Commit messages follow guidelines
- [ ] No merge conflicts
- [ ] PR description clearly describes the changes

PR Description Template:

```markdown
Description
Brief description of what this PR does.

Type of Change
- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Breaking change (fix or feature that would cause existing functionality to not work as expected)
- [ ] Documentation update
- [ ] Code refactoring
- [ ] Performance improvement

Related Issues
Fixes (issue number)

Changes Made
- List the main changes
- Include any important details
- Mention any breaking changes

Testing
Describe how you tested these changes:
- [ ] Unit tests added/updated
- [ ] Integration tests added/updated
- [ ] Manual testing performed

Screenshots (if applicable)
Add screenshots to demonstrate the changes.

Checklist
- [ ] My code follows the style guidelines of this project
- [ ] I have performed a self-review of my code
- [ ] I have commented my code, particularly in hard-to-understand areas
- [ ] I have made corresponding changes to the documentation
- [ ] My changes generate no new warnings
- [ ] I have added tests that prove my fix is effective or that my feature works
- [ ] New and existing unit tests pass locally with my changes
```

Development Setup

Prerequisites
- .NET 6.0 SDK or higher
- SQL Server (Express/Developer/Standard)
- Visual Studio 2022 or VS Code
- Git

Setup Steps

1. Clone your fork:
   ```bash
   git clone https://github.com/YOUR_USERNAME/mvc-ui-template.git
   cd mvc-ui-template
   ```

2. Add upstream remote:
   ```bash
   git remote add upstream https://github.com/RashedulHaqueRonjon/mvc-ui-template.git
   ```

3. Install dependencies:
   ```bash
   dotnet restore
   ```

4. Configure database:
   - Update `appsettings.json` with your SQL Server connection string
   - Run the application (database will be created automatically)

5. Build the project:
   ```bash
   dotnet build
   ```

6. Run the application:
   ```bash
   dotnet run
   ```

Keeping Your Fork Updated

```bash
git fetch upstream
git checkout main
git merge upstream/main
```

Code Style Guidelines

This project uses `.editorconfig` to maintain consistent coding styles. Please ensure your IDE respects these settings.

CCoding Standards

Naming Conventions:
- PascalCase: Classes, Methods, Properties, Public Fields
  ```csharp
  public class CustomerController
  public void GetCustomerList()
  public string FirstName { get; set; }
  ```

- camelCase: Private fields, local variables, parameters
  ```csharp
  private readonly AppDbContext _context;
  int pageNumber = 1;
  ```

- Interfaces: Prefix with 'I'
  ```csharp
  public interface ICustomerService
  ```

Code Organization:
- One class per file
- Order: Fields → Constructor → Properties → Public Methods → Private Methods
- Keep methods focused and short (ideally under 20 lines)
- Use meaningful variable names

Example:
```csharp
public class CustomerController : Controller
{
    // 1. Private fields
    private readonly AppDbContext _context;
    private const int PageSize = 5;

    // 2. Constructor
    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    // 3. Public methods
    public async Task<IActionResult> Index(string sortOrder, string searchString)
    {
        // Implementation
    }

    // 4. Private helper methods
    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.CustomerID == id);
    }
}
```

Comments:
- Use XML documentation for public methods
  ```csharp
  /// <summary>
  /// Retrieves a paginated list of customers with optional search and sort.
  /// </summary>
  /// <param name="sortOrder">Column to sort by</param>
  /// <param name="searchString">Search term</param>
  /// <returns>View with customer list</returns>
  public async Task<IActionResult> Index(string sortOrder, string searchString)
  ```

- Use inline comments sparingly for complex logic
  ```csharp
  // Calculate total pages, rounding up for partial pages
  int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
  ```

Async/Await:
- Always use async/await for database operations
- Suffix async methods with 'Async' when appropriate
  ```csharp
  public async Task<Customer> GetCustomerAsync(int id)
  {
      return await _context.Customers.FindAsync(id);
  }
  ```

LINQ Queries:
- Use method syntax for simple queries
- Use query syntax for complex multi-step queries
- Always use meaningful variable names

Error Handling:
- Use try-catch for expected exceptions
- Log errors appropriately
- Return user-friendly error messages

Razor View Guidelines

Naming:
- Use PascalCase for view files: `Index.cshtml`, `Create.cshtml`

Structure:
```razor
@model MVCUITemplate.Models.Customer

@{
    ViewData["Title"] = "Customer Details";
}

<!-- Main content -->
<div class="container">
    <!-- View content here -->
</div>

@section Scripts {
    <!-- Page-specific scripts -->
}
```

Best Practices:
- Keep views simple, avoid complex logic
- Use partial views for reusable components
- Use view models instead of ViewBag/ViewData when possible
- Always encode user input: `@Html.DisplayFor()`, `@Html.Raw()` only for trusted content

CSS/JavaScript Guidelines

CSS:
- Use Bootstrap utility classes when possible
- Custom CSS should be in separate files in `wwwroot/css/`
- Use meaningful class names (BEM methodology preferred)

JavaScript:
- Place scripts at the bottom or in `@section Scripts`
- Use jQuery for consistency with the project
- Comment complex logic

Commit Message Guidelines

We follow the [Conventional Commits](https://www.conventionalcommits.org/) specification.

Format:
```
<type>(<scope>): <subject>

<body>

<footer>
```

Types:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, missing semi-colons, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

Examples:

```
feat(customer): add export to Excel functionality

Added a new button on the customer list page that allows users
to export the current customer list to an Excel file.

Closes 45
```

```
fix(edit): resolve RowGuid constraint violation

Fixed the unique constraint error on RowGuid when editing customers
by adding hidden field to preserve the existing GUID value.

Fixes 23
```

```
docs(readme): add installation troubleshooting section

Added common installation issues and their solutions to help
new contributors get started more easily.
```

Guidelines:
- Use present tense ("add feature" not "added feature")
- Use imperative mood ("move cursor to..." not "moves cursor to...")
- First line should be 50 characters or less
- Reference issues and pull requests in the footer
- Explain *what* and *why*, not *how*

Testing Guidelines

Before Submitting:
- [ ] All existing tests pass
- [ ] New features have tests
- [ ] Bug fixes have regression tests
- [ ] Manual testing completed

Manual Testing Checklist:
1. Create a new customer
2. Edit the customer
3. View customer details
4. Delete the customer
5. Test search functionality
6. Test sorting (ascending and descending)
7. Test pagination
8. Test form validation
9. Test on different browsers (Chrome, Firefox, Edge)
10. Test responsive design on mobile

Writing Tests (Future Enhancement):
```csharp
[Fact]
public async Task Create_ValidCustomer_ReturnsRedirectToIndex()
{
    // Arrange
    var customer = new Customer { FirstName = "Test", LastName = "User" };
    
    // Act
    var result = await _controller.Create(customer);
    
    // Assert
    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
    Assert.Equal("Index", redirectResult.ActionName);
}
```

Branch Naming Convention

- `feature/description` - New features
- `fix/description` - Bug fixes
- `docs/description` - Documentation updates
- `refactor/description` - Code refactoring
- `test/description` - Test additions/modifications

Examples:
- `feature/excel-export`
- `fix/rowguid-constraint`
- `docs/update-readme`

Getting Help

- Email: rashedul.haque.ronjon@outlook.com
- GitHub Issues: For bugs and feature requests
- LinkedIn: [Connect with the author](https://linkedin.com/in/rashedul-haque-ronjon)

Recognition

Contributors will be recognized in the project README. Significant contributions may result in being added as a project maintainer.

Questions?

If you have questions about contributing, feel free to:
1. Open an issue with the question label
2. Reach out to the maintainer directly

---

Thank you for contributing to making this project better!