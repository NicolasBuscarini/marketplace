using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LojaController : ControllerBase
{
    private readonly ILojaService _lojaService;

    public LojaController(ILojaService lojaService)
    {
        _lojaService = lojaService;
    }

    [HttpPost("create-loja")]
    public async Task<ActionResult> CreateLoja([FromBody] LojaDto lojaDto)
    {
        try
        {
            return Ok(await _lojaService.CreateLoja(lojaDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-lojas")]
    public async Task<ActionResult> GetAllLojas()
    {
        try
        {
            List<Loja> listLoja = await _lojaService.GetAllLojas();

            return Ok(listLoja);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-loja")]
    public async Task<ActionResult> GetLojaByLojaId([FromQuery] Guid lojaId)
    {
        try
        {
            Loja loja = await _lojaService.GetLojaById(lojaId);

            return Ok(loja);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("update-loja")]
    public async Task<ActionResult> UpdateLoja([FromBody] LojaDto lojaDto)
    {
        try
        {
            return Ok(await _lojaService.UpdateLoja(lojaDto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}