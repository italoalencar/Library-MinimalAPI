using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace Library_MinimalAPI.Services;

public class CustomerService
{
    private readonly UserManager<Customer> _userManager;
    private readonly SignInManager<Customer> _signInManager;
    private readonly IMapper _mapper;

    public CustomerService(UserManager<Customer> userManager, IMapper mapper, SignInManager<Customer> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUser(CreateCustomerDTO customerDTO)
    {
        var customer = _mapper.Map<Customer>(customerDTO);
        return await _userManager.CreateAsync(customer, customerDTO.Password);
    }

    public async Task<Customer> LoginUser(LoginDTO login)
    {
        var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
        if (result.Succeeded)
        {
            return _userManager.Users.FirstOrDefault(customer => customer
            .NormalizedUserName!
            .Equals(login.UserName.ToUpper()))!;
        }
        throw new ApplicationException("Login not successful.");
    }
}
