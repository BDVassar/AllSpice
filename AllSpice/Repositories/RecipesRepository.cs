namespace AllSpice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db;

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe Create(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
      (title, instructions, img, category, creatorId)
    VALUES
      (@title, @instructions, @img, @category, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, recipeData);
    recipeData.id = id;
    return recipeData;
  }


  internal List<Recipe> Get()
  {
    string sql = @"
    SELECT
    re.*,
    ac.*
    FROM recipes re
    JOIN accounts ac ON ac.id = re.creatorId;
    ";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.creator = account;
      return recipe;
    }
    ).ToList();
    return recipes;
  }

  internal Recipe GetOne(int id)
  {
    string sql = @"
    SELECT
    re.*,
    ac.*
    FROM recipes re
    JOIN accounts ac ON ac.id = re.creatorId
    WHERE re.id = @id;
    ";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
    {
      recipe.creator = account;
      return recipe;
    }, new { id }).FirstOrDefault();
    return recipe;
  }
  internal bool EditRecipe(Recipe originalRecipe)
  {
    string sql = @"
    UPDATE recipes
      SET
      title = @title,
      instructions= @instructions,
      img= @img,
      category = @category
    WHERE id = @id;
      ";
    int rows = _db.Execute(sql, originalRecipe);
    return rows > 0;
  }
}
