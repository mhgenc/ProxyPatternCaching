using AutoMapper;
using ProxyPatternCaching.Application.Dtos;
using ProxyPatternCaching.Application.Dtos.Requests;
using ProxyPatternCaching.Application.Services.Interfaces;
using ProxyPatternCaching.Domain.Entities;
using ProxyPatternCaching.Infrastructure.Repositories.Interfaces;

namespace ProxyPatternCaching.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<BookDto?> AddBook(CreateBookRequest request)
    {
        var book = _mapper.Map<Book>(request);
        
        await _bookRepository.AddAsync(book);

        var response = _mapper.Map<BookDto>(book);
        
        return response;
    }

    public async Task<BookDto?> GetBook(string id)
    {
        var book =await _bookRepository.GetByIdAsync(id);
        
        var response = _mapper.Map<BookDto>(book);
        
        return response;
    }
}