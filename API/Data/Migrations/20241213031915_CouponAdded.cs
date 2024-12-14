using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CouponAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Coupon_AmountOff",
                table: "Baskets",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coupon_CouponId",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coupon_Name",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Coupon_PercentOff",
                table: "Baskets",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coupon_PromotionCode",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coupon_AmountOff",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Coupon_CouponId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Coupon_Name",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Coupon_PercentOff",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Coupon_PromotionCode",
                table: "Baskets");
        }
    }
}
