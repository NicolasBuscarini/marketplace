﻿using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<ActionResult> SignUp([FromBody] SignUpDto signUpDto)
    {
        try
        {
            bool ret = await _authService.SignUp(signUpDto);

            return Ok(ret);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<ActionResult> SignIn([FromBody] SignInDto signInDTO)
    {
        try
        {
            SsoDto ssoDTO = await _authService.SignIn(signInDTO);

            return Ok(ssoDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-current-user")]
    public async Task<ActionResult> GetCurrentUser()
    {
        try
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            return Ok(currentUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("list-users")]
    public async Task<ActionResult> ListUsers()
    {
        try
        {
            List<ApplicationUser> list = await _authService.ListUsers();

            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}