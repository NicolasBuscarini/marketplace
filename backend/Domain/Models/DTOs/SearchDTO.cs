﻿namespace MarketPlace.Domain.Models.DTOs;

public class SearchDto
{
    public string SearchString { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}