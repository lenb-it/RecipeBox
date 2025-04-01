using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntityNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Recipes_RecipeId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategoryEntity_Categories_CategoryId",
                table: "RecipeCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategoryEntity_Recipes_RecipeId",
                table: "RecipeCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavoriteEntity_Recipes_RecipeId",
                table: "RecipeFavoriteEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavoriteEntity_Users_UserId",
                table: "RecipeFavoriteEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientEntity_Ingredients_IngredientId",
                table: "RecipeIngredientEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientEntity_Recipes_RecipeId",
                table: "RecipeIngredientEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTagEntity_Recipes_RecipeId",
                table: "RecipeTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTagEntity_Tags_TagId",
                table: "RecipeTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_Permissions_PermissionId",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionEntity_Roles_RoleId",
                table: "RolePermissionEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleEntity_Roles_RoleId",
                table: "UserRoleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleEntity_Users_UserId",
                table: "UserRoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleEntity",
                table: "UserRoleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTagEntity",
                table: "RecipeTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngredientEntity",
                table: "RecipeIngredientEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeFavoriteEntity",
                table: "RecipeFavoriteEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategoryEntity",
                table: "RecipeCategoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "UserRoleEntity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "RolePermissionEntity",
                newName: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "RecipeTagEntity",
                newName: "RecipeTags");

            migrationBuilder.RenameTable(
                name: "RecipeIngredientEntity",
                newName: "RecipeIngredients");

            migrationBuilder.RenameTable(
                name: "RecipeFavoriteEntity",
                newName: "RecipeFavorites");

            migrationBuilder.RenameTable(
                name: "RecipeCategoryEntity",
                newName: "RecipeCategories");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "RecipeRatings");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleEntity_UserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissionEntity_PermissionId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTagEntity_TagId",
                table: "RecipeTags",
                newName: "IX_RecipeTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredientEntity_RecipeId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredientEntity_IngredientId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavoriteEntity_UserId",
                table: "RecipeFavorites",
                newName: "IX_RecipeFavorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavoriteEntity_RecipeId",
                table: "RecipeFavorites",
                newName: "IX_RecipeFavorites_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategoryEntity_CategoryId",
                table: "RecipeCategories",
                newName: "IX_RecipeCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_UserId",
                table: "RecipeRatings",
                newName: "IX_RecipeRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_RecipeId",
                table: "RecipeRatings",
                newName: "IX_RecipeRatings_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngredients",
                table: "RecipeIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeFavorites",
                table: "RecipeFavorites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories",
                columns: new[] { "RecipeId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeRatings",
                table: "RecipeRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeId",
                table: "RecipeTags",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Categories_CategoryId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCategories_Recipes_RecipeId",
                table: "RecipeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorites_Recipes_RecipeId",
                table: "RecipeFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorites_Users_UserId",
                table: "RecipeFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Recipes_RecipeId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRatings_Users_UserId",
                table: "RecipeRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Recipes_RecipeId",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeTags_Tags_TagId",
                table: "RecipeTags");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissions",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeTags",
                table: "RecipeTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeRatings",
                table: "RecipeRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngredients",
                table: "RecipeIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeFavorites",
                table: "RecipeFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeCategories",
                table: "RecipeCategories");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoleEntity");

            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermissionEntity");

            migrationBuilder.RenameTable(
                name: "RecipeTags",
                newName: "RecipeTagEntity");

            migrationBuilder.RenameTable(
                name: "RecipeRatings",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "RecipeIngredients",
                newName: "RecipeIngredientEntity");

            migrationBuilder.RenameTable(
                name: "RecipeFavorites",
                newName: "RecipeFavoriteEntity");

            migrationBuilder.RenameTable(
                name: "RecipeCategories",
                newName: "RecipeCategoryEntity");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoleEntity",
                newName: "IX_UserRoleEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissionEntity",
                newName: "IX_RolePermissionEntity_PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeTags_TagId",
                table: "RecipeTagEntity",
                newName: "IX_RecipeTagEntity_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRatings_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeRatings_RecipeId",
                table: "Ratings",
                newName: "IX_Ratings_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredientEntity",
                newName: "IX_RecipeIngredientEntity_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredientEntity",
                newName: "IX_RecipeIngredientEntity_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorites_UserId",
                table: "RecipeFavoriteEntity",
                newName: "IX_RecipeFavoriteEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeFavorites_RecipeId",
                table: "RecipeFavoriteEntity",
                newName: "IX_RecipeFavoriteEntity_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategoryEntity",
                newName: "IX_RecipeCategoryEntity_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleEntity",
                table: "UserRoleEntity",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissionEntity",
                table: "RolePermissionEntity",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeTagEntity",
                table: "RecipeTagEntity",
                columns: new[] { "RecipeId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngredientEntity",
                table: "RecipeIngredientEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeFavoriteEntity",
                table: "RecipeFavoriteEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeCategoryEntity",
                table: "RecipeCategoryEntity",
                columns: new[] { "RecipeId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Recipes_RecipeId",
                table: "Ratings",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategoryEntity_Categories_CategoryId",
                table: "RecipeCategoryEntity",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCategoryEntity_Recipes_RecipeId",
                table: "RecipeCategoryEntity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavoriteEntity_Recipes_RecipeId",
                table: "RecipeFavoriteEntity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavoriteEntity_Users_UserId",
                table: "RecipeFavoriteEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientEntity_Ingredients_IngredientId",
                table: "RecipeIngredientEntity",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientEntity_Recipes_RecipeId",
                table: "RecipeIngredientEntity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTagEntity_Recipes_RecipeId",
                table: "RecipeTagEntity",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeTagEntity_Tags_TagId",
                table: "RecipeTagEntity",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_Permissions_PermissionId",
                table: "RolePermissionEntity",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionEntity_Roles_RoleId",
                table: "RolePermissionEntity",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleEntity_Roles_RoleId",
                table: "UserRoleEntity",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleEntity_Users_UserId",
                table: "UserRoleEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
