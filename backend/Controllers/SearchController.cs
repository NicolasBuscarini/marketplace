using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpPost("search-produto")]
    public async Task<ActionResult> SearchProduto([FromBody] SearchDto searchDto)
    {
        try
        {
            return Ok(await _searchService.SearchGenericByName<Produto>(searchDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("search-loja")]
    public async Task<ActionResult> SearchLoja([FromBody] SearchDto searchDto)
    {
        try
        {
            return Ok(await _searchService.SearchGenericByName<Loja>(searchDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("search-user")]
    public async Task<ActionResult> SearchUser([FromBody] SearchDto searchDto)
    {
        try
        {
            return Ok(await _searchService.SearchGenericByName<ApplicationUser>(searchDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}