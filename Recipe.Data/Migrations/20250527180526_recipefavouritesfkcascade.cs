using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Migrations
{
    /// <inheritdoc />
    public partial class recipefavouritesfkcascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipeFavorites_Recipes_RecipeId",
                table: "UserRecipeFavorites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
