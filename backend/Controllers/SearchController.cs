using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
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

    [AllowAnonymous]
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