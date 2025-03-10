using Microsoft.AspNetCore.Identity;

namespace Library_MinimalAPI.Models;

public class Customer : IdentityUser
{
    public string FirstName { get; set; }   
    public string LastName { get; set; }

    public virtual ICollection<Loan>? Loans { get; set; }
}
