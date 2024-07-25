using Microsoft.AspNetCore.Mvc;
using PriceLists.Data.Models;
using PriceLists.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PriceLists.Api.Dto.PriceListDto.Responses;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Specifications;
using PriceLists.Api.Specifications.PriceListSpecs;

namespace PriceLists.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PriceListController : ControllerBase
{
    private readonly ILogger<PriceListController> _logger;
    private readonly IPriceListsRepository _repository;
    private readonly IMapper _mapper;

    public PriceListController(ILogger<PriceListController> logger, IPriceListsRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }
    
    /// <summary> Получить список всех прайс-листов. </summary>
    [HttpGet("get-all")]
    public async Task<IEnumerable<PriceListGetAllResponse>?> GetAllAsync()
    {
        var priceLists = await _repository.Find<PriceList>().ToListAsync();
        var responseEnumerable = priceLists.Count != 0 ? _mapper.Map<IEnumerable<PriceListGetAllResponse>>(priceLists) : null;
        return responseEnumerable;
    }

    /// <summary> Получить прайс-лист по <paramref name="id"/>. </summary>
    /// <param name="id"> Id прайс-листа. </param>
    [HttpGet("{id}")]
    public async Task<PriceListGetResponse> GetAsync(uint id)
    {
        var priceList = await _repository.GetAsync(new PriceListWithIncludedSpec(id))
            ?? throw new ArgumentException("Прайс-листа по указанному id не существует.");
        var response = _mapper.Map<PriceListGetResponse>(priceList);
        return response;
    }

    /// <summary> Создать прайст-лист. </summary>
    /// <param name="request"> Тело запроса на создание прайс-листа. </param>
    [HttpPost]
    public async Task AddAsync(PriceListAddRequest request)
    {
        // Проверка, что указанные в запросе существующие колонки действительно существуют.
        var existingColumnsIds = request.Columns.Where(c => c.Id.HasValue).Select(c => c.Id!.Value);
        var existingColumns = await _repository.Find(new EntitiesByIdsSpec<Column>(existingColumnsIds)).ToArrayAsync();
        if (existingColumns.Length != existingColumnsIds.Count())
        {
            throw new ArgumentException("Количество найденных существующих в БД кастомных колонок не совпадает с количеством переданных в запросе.");
        }

        // Добавление прайс-листа.
        var priceList = _mapper.Map<PriceList>(request);
        await _repository.AddAsync(priceList);

        // Добавление связей прайс-листа с новыми колонками.
        var newColumnsRequestData = request.Columns.Where(c => !c.Id.HasValue);
        var newColumns = _mapper.Map<IEnumerable<Column>>(newColumnsRequestData);
        await _repository.AddRangeAsync(newColumns);
        priceList.Columns = existingColumns.Union(newColumns).ToArray();

        await _repository.SaveChangesAsync();
    }
}
