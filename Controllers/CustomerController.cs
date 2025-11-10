using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCUITemplate.Data;
using MVCUITemplate.Models;
using System;
using System.Linq; 
using System.Threading.Tasks;

namespace MVCUITemplate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private const int PageSize = 5; // Number of records per page

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // INDEX (List View with Sorting, Searching, Pagination)
        public async Task<IActionResult> Index(string? sortOrder, string? searchString, int pageNumber = 1)
        {
            // Preserve sort & filter values in ViewData for the UI
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;

            // Default sorting by FirstName
            IQueryable<Customer> customers = _context.Customers.AsQueryable();

            // ---------------------------------------------
            // SEARCH FILTER
            // ---------------------------------------------
            if (!string.IsNullOrEmpty(searchString))
            {
                string lowerSearch = searchString.ToLower();

                customers = customers.Where(c =>
                    (c.FirstName != null && c.FirstName.ToLower().Contains(lowerSearch)) ||
                    (c.LastName != null && c.LastName.ToLower().Contains(lowerSearch)) ||
                    (c.EmailAddress != null && c.EmailAddress.ToLower().Contains(lowerSearch)) ||
                    (c.CompanyName != null && c.CompanyName.ToLower().Contains(lowerSearch))
                );
            }

            // ---------------------------------------------
            // SORTING LOGIC
            // ---------------------------------------------
            ViewData["TitleSortParam"] = sortOrder == "Title" ? "Title_desc" : "Title";
            ViewData["FirstNameSortParam"] = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewData["LastNameSortParam"] = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            ViewData["CompanySortParam"] = sortOrder == "CompanyName" ? "CompanyName_desc" : "CompanyName";
            ViewData["EmailSortParam"] = sortOrder == "EmailAddress" ? "EmailAddress_desc" : "EmailAddress";
            ViewData["DateSortParam"] = sortOrder == "ModifiedDate" ? "ModifiedDate_desc" : "ModifiedDate";

            customers = sortOrder switch
            {
                "Title" => customers.OrderBy(c => c.Title),
                "Title_desc" => customers.OrderByDescending(c => c.Title),
                "FirstName" => customers.OrderBy(c => c.FirstName),
                "FirstName_desc" => customers.OrderByDescending(c => c.FirstName),
                "LastName" => customers.OrderBy(c => c.LastName),
                "LastName_desc" => customers.OrderByDescending(c => c.LastName),
                "CompanyName" => customers.OrderBy(c => c.CompanyName),
                "CompanyName_desc" => customers.OrderByDescending(c => c.CompanyName),
                "EmailAddress" => customers.OrderBy(c => c.EmailAddress),
                "EmailAddress_desc" => customers.OrderByDescending(c => c.EmailAddress),
                "ModifiedDate" => customers.OrderBy(c => c.ModifiedDate),
                "ModifiedDate_desc" => customers.OrderByDescending(c => c.ModifiedDate),
                _ => customers.OrderBy(c => c.FirstName)
            };

            // ---------------------------------------------
            // PAGINATION LOGIC
            // ---------------------------------------------
            int totalRecords = await customers.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

            var paginatedList = await customers
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = totalPages;

            return View(paginatedList);
        }

        // ======================================================
        // DETAILS
        // ======================================================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // ======================================================
        // CREATE (GET)
        // ======================================================
        public IActionResult Create()
        {
            return View();
        }

        // ======================================================
        // CREATE (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,FirstName,LastName,CompanyName,EmailAddress,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ModifiedDate = DateTime.Now;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Customer added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // ======================================================
        // EDIT (GET)
        // ======================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // ======================================================
        // EDIT (POST)
        // ======================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Title,FirstName,LastName,CompanyName,EmailAddress,Phone,RowGuid,ModifiedDate")] Customer customer)
        {
            if (id != customer.CustomerID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    customer.ModifiedDate = DateTime.Now;
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Customer updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // ======================================================
        // DELETE (GET)
        // ======================================================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerID == id);
            if (customer == null) return NotFound();

            return View(customer);
        }

        // ======================================================
        // DELETE (POST)
        // ======================================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Customer deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        // ======================================================
        // HELPER: Check if exists
        // ======================================================
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
