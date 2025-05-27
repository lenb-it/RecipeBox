using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Migrations
{
    /// <inheritdoc />
    public partial class reciperatingsfks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorites_Recipes_RecipeId",
                table: "RecipeFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorites_Users_UserId",
                table: "RecipeFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeFavorites",
                table: "RecipeFavorites");

            migrationBuilder.RenameTable(
                name: "RecipeFavorites",
                newName: "UserRecipeFavorites");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorites_UserId",
                table: "UserRecipeFavorites",
                newName: "IX_UserRecipeFavorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorites_RecipeId",
                table: "UserRecipeFavorites",
                newName: "IX_UserRecipeFavorites_RecipeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RecipeRatings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecipeFavorites",
                table: "UserRecipeFavorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorites_Users_UserId",
                table: "UserRecipeFavorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorites_Users_UserId",
                table: "UserRecipeFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecipeFavorites",
                table: "UserRecipeFavorites");

            migrationBuilder.RenameTable(
                name: "UserRecipeFavorites",
                newName: "RecipeFavorites");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipeFavorites_UserId",
                table: "RecipeFavorites",
                newName: "IX_RecipeFavorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipeFavorites_RecipeId",
                table: "RecipeFavorites",
                newName: "IX_RecipeFavorites_RecipeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RecipeRatings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeFavorites",
                table: "RecipeFavorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorites_Recipes_RecipeId",
                table: "RecipeFavorites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorites_Users_UserId",
                table: "RecipeFavorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
