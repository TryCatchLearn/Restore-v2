using Microsoft.EntityFrameworkCore;

namespace API.Entities;

[Owned]
public class AppCoupon
{
    public required string Name { get; set; }
    public long? AmountOff { get; set; }

    [Precision(5,2)]
    public decimal? PercentOff { get; set; }
    public required string PromotionCode { get; set; }
    public required string CouponId { get; set; }
}
