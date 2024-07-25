using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Data;
using PriceLists.Data.Models;

namespace PriceLists.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ColumnController : ControllerBase
{
    private readonly ILogger<ColumnController> _logger;
    private readonly IPriceListsRepository _repository;
    private readonly IMapper _mapper;

    public ColumnController(ILogger<ColumnController> logger, IPriceListsRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary> Получить список всех кастомных колонок. </summary>
    [HttpGet("get-all")]
    public async Task<IEnumerable<ColumnGetAllResponse>?> GetAllAsync()
    {
        var columns = await _repository.Find<Column>().ToListAsync();
        var responseEnumerable = columns.Count != 0 ? _mapper.Map<IEnumerable<ColumnGetAllResponse>>(columns) : null;
        return responseEnumerable;
    }
}
