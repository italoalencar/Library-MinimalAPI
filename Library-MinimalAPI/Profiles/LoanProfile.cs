using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Profiles;

public class LoanProfile : Profile
{
    public LoanProfile() 
    {
        CreateMap<Loan, ReadLoanDTO>();
    }
}
