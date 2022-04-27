using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost("create-produto")]
    public async Task<ActionResult> CreateProduto([FromBody] ProdutoDto produtoDto)
    {
        try
        {
            return Ok(await _produtoService.CreateProduto(produtoDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-produtos")]
    public async Task<ActionResult> GetAllProdutos()
    {
        try
        {
            List<Produto> listProduto = await _produtoService.GetAllProdutos();

            return Ok(listProduto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-produto")]
    public async Task<ActionResult> GetProdutoByProdutoId([FromQuery] Guid produtoId)
    {
        try
        {
            Produto produto = await _produtoService.GetProdutoById(produtoId);

            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("desativar-produto")]
    public async Task<ActionResult> DesativarProduto([FromBody] Guid produtoId)
    {
        try
        {
            return Ok(await _produtoService.DesativarProduto(produtoId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("update-produto")]
    public async Task<ActionResult> UpdateProduto([FromBody] ProdutoDto produtoDto)
    {
        try
        {
            return Ok(await _produtoService.UpdateProduto(produtoDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}