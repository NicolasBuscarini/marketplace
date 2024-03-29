﻿using MarketPlace.Domain.Models;
using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Impl.Repository;

public class LojaRepository : GenericRepository<Loja, Guid>, ILojaRepository
{
    private readonly MySqlContext _context;

    public LojaRepository(MySqlContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Loja>> ListLojas()
    {
        List<Loja> list = await _context.Loja.Include(x => x.Produtos).ToListAsync();

        return list;
    }
}