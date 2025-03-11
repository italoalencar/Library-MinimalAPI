namespace Library_MinimalAPI.DTOs;

public record ReadLoanDTO(int Id, ReadCustomerDTO Customer, ReadBookDTO Book, DateTime LoanDate,
    bool IsReturned, DateTime? ReturnedDate);
