namespace Library_MinimalAPI.DTOs;

public record ReadLoanDTO(int BookId, DateTime LoanDate, bool IsReturned, DateTime? ReturnedDate);
