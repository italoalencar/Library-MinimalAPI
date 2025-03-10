namespace Library_MinimalAPI.Models;

public class Loan
{
    public int Id { get; set; }
    public required string CustomerId { get; set; }
    public required int BookId { get; set; }
    public DateTime LoanDate { get; set; }
    public bool IsReturned { get; set; }
    public DateTime? ReturnedDate { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Book Book { get; set; }
}
