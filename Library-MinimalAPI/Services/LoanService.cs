using AutoMapper;
using Library_MinimalAPI.DAL;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Services;

public class LoanService
{
    private readonly DAL<Loan> dal;
    private readonly IMapper _mapper;

    public LoanService(DAL<Loan> dal, IMapper mapper)
    {
        this.dal = dal;
        _mapper = mapper;
    }

    public bool Create(string userId, CreateLoanDTO loanDTO)
    {
        Loan loan = new()
        {
            CustomerId = userId,
            BookId = loanDTO.BookId,
            LoanDate = DateTime.UtcNow,
            IsReturned = false // default
        };

        var created = dal.Create(loan);
        if (created is not null) return true;
        return false;
    }

    public ICollection<ReadLoanDTO> ReadByUser(string? userId)
    {
        var loans = dal.ListBy(loan => loan.CustomerId == userId);
        return _mapper.Map<List<ReadLoanDTO>>(loans);
    }

    public ICollection<ReadLoanDTO> ReadAll()
    {
        var loans = dal.Read();
        return _mapper.Map<List<ReadLoanDTO>>(loans);
    }

    public bool UpdateStatus(int id, UpdateLoanDTO loanDTO)
    {
        var loan = dal.ReadBy(l => l.Id == id);
        if (loan is null) return false;
        loan.IsReturned = loanDTO.IsReturned;
        loan.ReturnedDate = DateTime.UtcNow;
        return dal.Update(loan, l => l.Id == id);
    }
}
