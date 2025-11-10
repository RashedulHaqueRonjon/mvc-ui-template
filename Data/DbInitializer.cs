using MVCUITemplate.Models;

namespace MVCUITemplate.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Customers.Any()) return; // already seeded

            var customers = new List<Customer>
            {
                new Customer{ Title="Mr", FirstName="John", LastName="Doe", CompanyName="ORG001", EmailAddress="john.doe@org001.com", Phone="0123456789", ModifiedDate=DateTime.ParseExact("01-12-2020", "dd-MM-yyyy", null)},
                new Customer{ Title="Ms", FirstName="Jane", LastName="Smith", CompanyName="ORG002", EmailAddress="jane.smith@org002.com", Phone="0123456790", ModifiedDate=DateTime.ParseExact("15-03-2023", "dd-MM-yyyy", null)},
                new Customer{ Title="Mr", FirstName="Ali", LastName="Khan", CompanyName="ORG003", EmailAddress="ali.khan@org003.com", Phone="0123456791", ModifiedDate=DateTime.ParseExact("22-08-2021", "dd-MM-yyyy", null)},
                new Customer{ Title="Ms", FirstName="Maria", LastName="Gomez", CompanyName="ORG004", EmailAddress="maria.gomez@org004.com", Phone="0123456792", ModifiedDate=DateTime.ParseExact("09-11-2024", "dd-MM-yyyy", null)},
                new Customer{ Title="Mr", FirstName="David", LastName="Brown", CompanyName="ORG005", EmailAddress="david.brown@org005.com", Phone="0123456793", ModifiedDate=DateTime.ParseExact("30-06-2022", "dd-MM-yyyy", null)},
                new Customer{ Title="Mr", FirstName="Wei", LastName="Li", CompanyName="ORG006", EmailAddress="wei.li@org006.com", Phone="0123456794", ModifiedDate=DateTime.ParseExact("17-01-2025", "dd-MM-yyyy", null)},
                new Customer{ Title="Ms", FirstName="Aisha", LastName="Ahmed", CompanyName="ORG007", EmailAddress="aisha.ahmed@org007.com", Phone="0123456795", ModifiedDate=DateTime.ParseExact("05-05-2019", "dd-MM-yyyy", null)},
                new Customer{ Title="Mr", FirstName="Carlos", LastName="Santos", CompanyName="ORG008", EmailAddress="carlos.santos@org008.com", Phone="0123456796", ModifiedDate=DateTime.ParseExact("12-09-2020", "dd-MM-yyyy", null)},
                new Customer{ Title="Ms", FirstName="Anna", LastName="Kowalski", CompanyName="ORG009", EmailAddress="anna.kowalski@org009.com", Phone="0123456797", ModifiedDate=DateTime.ParseExact("28-02-2023", "dd-MM-yyyy", null)},
                new Customer{ Title="Mr", FirstName="Mohamed", LastName="Hassan", CompanyName="ORG010", EmailAddress="mohamed.hassan@org010.com", Phone="0123456798", ModifiedDate=DateTime.ParseExact("19-07-2021", "dd-MM-yyyy", null)}
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
