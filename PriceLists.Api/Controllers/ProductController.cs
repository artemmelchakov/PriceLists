using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceLists.Api.Dto.PriceListDto.Requests;
using PriceLists.Api.Specifications.ColumnSpecs;
using PriceLists.Data;
using PriceLists.Data.Models;

namespace PriceLists.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IPriceListsRepository _repository;
    private readonly IMapper _mapper;

    public ProductController(ILogger<ProductController> logger, IPriceListsRepository repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary> Создать товар. </summary>
    /// <param name="request"> Тело запроса на создание товара. </param>
    [HttpPost]
    public async Task AddAsync(ProductAddRequest request)
    {
        // Убедимся, что пришедшие из запроса кастомные колонки существуют в прайс-листе, в который добавляется товар.
        var columnValuesIsNotNullOrEmpty = request.ColumnValues is not null && request.ColumnValues.Any();
        if (columnValuesIsNotNullOrEmpty)
        {
            var columnIds = request.ColumnValues!.Select(cv => cv.ColumnId);
            var columns = await _repository.Find(new ColumnsByIdsAndPriceListIdSpec(columnIds, request.PriceListId)).ToArrayAsync();
            if (columns.Length != columnIds.Count())
            {
                throw new ArgumentException(
                    "Количество найденных существующих в БД кастомных колонок не совпадает с количеством переданных в запросе.");
            }
        }

        // Добавление товара.
        var product = _mapper.Map<Product>(request);
        await _repository.AddAsync(product);

        await _repository.SaveChangesAsync();
    }

    /// <summary> Удалить товар по <paramref name="id"/>. </summary>
    /// <param name="id"> Id товара. </param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(uint id)
    {
        await _repository.DeleteAsync<Product>(id);
        await _repository.SaveChangesAsync();
    }
}
