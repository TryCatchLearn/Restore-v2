using System;
using API.Entities;

namespace API.DTOs;

public class BasketDto
{
    public required string BasketId { get; set; }
    public List<BasketItemDto> Items { get; set; } = [];
    public string? ClientSecret { get; set; }
    public AppCoupon? Coupon { get; set; }
}
