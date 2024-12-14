using System;
using API.Entities;
using Stripe;

namespace API.Services;

public class DiscountService
{
    public DiscountService(IConfiguration config)
    {
        StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];
    }

    public async Task<AppCoupon?> GetCouponFromPromoCode(string code)
    {
        var promotionService = new PromotionCodeService();

        var options = new PromotionCodeListOptions
        {
            Code = code
        };

        var promotionCodes = await promotionService.ListAsync(options);

        var promotionCode = promotionCodes.FirstOrDefault();

        if (promotionCode != null && promotionCode.Coupon != null)
        {
            return new AppCoupon
            {
                Name = promotionCode.Coupon.Name,
                AmountOff = promotionCode.Coupon.AmountOff,
                PercentOff = promotionCode.Coupon.PercentOff,
                CouponId = promotionCode.Coupon.Id,
                PromotionCode = promotionCode.Code
            };
        }

        return null;
    }

    public async Task<long> CalculateDiscountFromAmount(AppCoupon appCoupon, long amount,
        bool removeDiscount = false)
    {
        var couponService = new CouponService();

        var coupon = await couponService.GetAsync(appCoupon.CouponId);

        if (coupon.AmountOff.HasValue && !removeDiscount)
        {
            return (long)coupon.AmountOff;
        }
        else if (coupon.PercentOff.HasValue && !removeDiscount)
        {
            return (long)Math.Round(amount * (coupon.PercentOff.Value / 100), MidpointRounding.AwayFromZero);
        }

        return 0;
    }
}
