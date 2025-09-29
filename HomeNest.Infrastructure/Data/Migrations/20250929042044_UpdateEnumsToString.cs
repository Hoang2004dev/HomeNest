using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeNest.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnumsToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ===== USERS =====
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "'customer'::character varying");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            // ===== ORDERS =====
            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "orders",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "'pending'::character varying");

            // ===== PAYMENTS =====
            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "payments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "payments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "'pending'::character varying");

            // ===== VOUCHERS =====
            migrationBuilder.AlterColumn<string>(
                name: "discount_type",
                table: "vouchers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "vouchers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            // ===== PROMOTIONS =====
            migrationBuilder.AlterColumn<string>(
                name: "discount_type",
                table: "promotions",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "promotions",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            // ===== BLOG_POSTS =====
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "blog_posts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValueSql: "'draft'::character varying");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // ===== USERS =====
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "users",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "'customer'::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // ===== ORDERS =====
            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "orders",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "orders",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "'pending'::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // ===== PAYMENTS =====
            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "payments",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "payments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "'pending'::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // ===== VOUCHERS =====
            migrationBuilder.AlterColumn<string>(
                name: "discount_type",
                table: "vouchers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "vouchers",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // ===== PROMOTIONS =====
            migrationBuilder.AlterColumn<string>(
                name: "discount_type",
                table: "promotions",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "promotions",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            // ===== BLOG_POSTS =====
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "blog_posts",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                defaultValueSql: "'draft'::character varying",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }
    }
}
