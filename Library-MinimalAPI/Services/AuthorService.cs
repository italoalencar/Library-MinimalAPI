using AutoMapper;
using Library_MinimalAPI.DAL;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Library_MinimalAPI.Services;

public class AuthorService
{
    private readonly DAL<Author> dal;
    private readonly IMapper _mapper;

    public AuthorService(DAL<Author> dal, IMapper mapper)
    {
        this.dal = dal;
        _mapper = mapper;
    }

    public ReadAuthorDTO Create(CreateAuthorDTO authorDTO)
    {
        var author = _mapper.Map<Author>(authorDTO);
        var authorCreated = dal.Create(author);
        return _mapper.Map<ReadAuthorDTO>(authorCreated);
    }

    public ICollection<ReadAuthorDTO> GetAll()
    {
        return _mapper.Map<List<ReadAuthorDTO>>(dal.Read());
    }

    public ReadAuthorDTO? GetById(int id)
    {
        var author = dal.ReadBy(a => a.Id == id);
        return _mapper.Map<ReadAuthorDTO>(author);
    }

    public bool Update(ReadAuthorDTO authorDTO)
    {
        var author = _mapper.Map<Author>(authorDTO);
        return dal.Update(author, a => a.Id == authorDTO.Id);
    }

    public bool Delete(int id)
    {
        return dal.Delete(author => author.Id == id);
    }
}
