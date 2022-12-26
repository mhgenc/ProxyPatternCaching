using AutoMapper;
using ProxyPatternCaching.Application.Dtos;
using ProxyPatternCaching.Application.Dtos.Requests;
using ProxyPatternCaching.Domain.Entities;

namespace ProxyPatternCaching.Application.Mapper;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Book, CreateBookRequest>().ReverseMap();
        CreateMap<Book, BookDto>().ReverseMap();
    }
}