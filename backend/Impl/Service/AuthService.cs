﻿using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Domain.Models.Enums;
using MarketPlace.Infrastructure.Helper;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Impl.Service;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;

        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<List<ApplicationUser>> ListUsers()
    {
        List<ApplicationUser> listUsers = await _userRepository.ListUsers();

        return listUsers;
    }

    public async Task<ApplicationUser> GetUserById(Guid userId)
    {
        ApplicationUser user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            throw new ArgumentException("Usuário não existe!");

        return user;
    }

    public async Task<int> UpdateUser(ApplicationUser user)
    {
        ApplicationUser findUser = await _userRepository.GetByIdAsync(user.Id);
        if (findUser == null)
            throw new ArgumentException("Usuário não encontrado");

        findUser.Email = user.Email;
        findUser.UserName = user.UserName;

        return await _userRepository.UpdateAsync(findUser);
    }

    public async Task<bool> DeleteUser(Guid userId)
    {
        ApplicationUser findUser = await _userRepository.GetByIdAsync(userId);
        if (findUser == null)
            throw new ArgumentException("Usuário não encontrado");

        await _userRepository.DeleteAsync(findUser);

        return true;
    }

    public async Task<bool> SignUp(SignUpDto signUpDto)
    {
        ApplicationUser? userExists = await _userManager.FindByNameAsync(signUpDto.Username);
        if (userExists != null)
            throw new ArgumentException("Username already exists!");

        userExists = await _userManager.FindByEmailAsync(signUpDto.Email);
        if (userExists != null)
            throw new ArgumentException("Email already exists!");

        signUpDto.CpfCnpj = signUpDto.CpfCnpj.Replace(".", "");
        signUpDto.CpfCnpj = signUpDto.CpfCnpj.Replace(" ", "");
        signUpDto.CpfCnpj = signUpDto.CpfCnpj.Replace("-", "");

        EnumUserType enumUserType;
        if (UtilsHelper.IsCpf(signUpDto.CpfCnpj))
        {
            enumUserType = EnumUserType.Cliente;
        }
        else if (!UtilsHelper.IsCnpj(signUpDto.CpfCnpj))
        {
            enumUserType = EnumUserType.Vendedor;
        }
        else
        {
            throw new ArgumentException("CPF/CNPJ inválido! Digite um válido");
        }

        userExists = await _userRepository.GetByCpfCnpjAsync(signUpDto.CpfCnpj);
        if (userExists != null)
            throw new ArgumentException("CPF/CNPJ already exists!");

        ApplicationUser user = new()
        {
            Email = signUpDto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = signUpDto.Username,
            CpfCnpj = signUpDto.CpfCnpj,
            Cep = signUpDto.Cep,
            Endereco = signUpDto.Endereco,
            Endereco2 = signUpDto.Endereco2,
            DataNascimento = signUpDto.DataNascimento,
            Nome = signUpDto.NomeCompleto,
            PhoneNumber = signUpDto.PhoneNumber,
            EnumUserType = enumUserType
        };

        var result = await _userManager.CreateAsync(user, signUpDto.Password);

        if (!result.Succeeded)
            if (result.Errors.ToList().Count > 0)
                throw new ArgumentException(result.Errors.ToList()[0].Description);
            else
                throw new ArgumentException("Cadastro do usuário falhou.");

        return true;
    }

    public async Task<SsoDto> SignIn(SignInDto signInDto)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(signInDto.Username);
        if (user == null)
            throw new ArgumentException("Usuário não encontrado.");

        if (!await _userManager.CheckPasswordAsync(user, signInDto.Password))
            throw new ArgumentException("Senha inválida.");

        var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new SsoDto(new JwtSecurityTokenHandler().WriteToken(token), user);
    }

    public async Task<ApplicationUser> GetCurrentUser()
    {
        ApplicationUser? user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

        return user;
    }
}