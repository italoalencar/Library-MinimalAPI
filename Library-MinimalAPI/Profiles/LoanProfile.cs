using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Profiles;

public class LoanProfile : Profile
{
    public LoanProfile() 
    {
        CreateMap<Loan, ReadLoanDTO>()
            .ForMember(loanDTO => loanDTO.Customer, options =>
                options.MapFrom(loan => loan.Customer))
            .ForMember(loanDTO => loanDTO.Book, options =>
                options.MapFrom(loan => loan.Book));
    }
}
