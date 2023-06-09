using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZenGarden.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Users_userId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_userId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GardenID",
                table: "Users",
                newName: "WalletId");

            migrationBuilder.RenameColumn(
                name: "GardenId",
                table: "Plants",
                newName: "GardenID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Plants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlantName",
                table: "Plants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PlantDescription",
                table: "Plants",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenId",
                table: "Plants",
                newName: "IX_Plants_GardenID");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Gardens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "GardenId",
                table: "Gardens",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "GardenID",
                table: "Plants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Plants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Gardens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Insects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    PlantId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insects_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_WalletId",
                table: "Users",
                column: "WalletId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insects_PlantId",
                table: "Insects",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Users_UserId",
                table: "Gardens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardenID",
                table: "Plants",
                column: "GardenID",
                principalTable: "Gardens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Wallets_WalletId",
                table: "Users",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Users_UserId",
                table: "Gardens");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Gardens_GardenID",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Wallets_WalletId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Insects");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Users_WalletId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_UserId",
                table: "Gardens");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Users",
                newName: "GardenID");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "GardenID",
                table: "Plants",
                newName: "GardenId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plants",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plants",
                newName: "PlantName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Plants",
                newName: "PlantDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Plants_GardenID",
                table: "Plants",
                newName: "IX_Plants_GardenId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Gardens",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gardens",
                newName: "GardenId");

            migrationBuilder.AlterColumn<long>(
                name: "GardenId",
                table: "Plants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "userId",
                table: "Gardens",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Gardens",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_userId",
                table: "Gardens",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Users_userId",
                table: "Gardens",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Gardens_GardenId",
                table: "Plants",
                column: "GardenId",
                principalTable: "Gardens",
                principalColumn: "GardenId");
        }
    }
}
