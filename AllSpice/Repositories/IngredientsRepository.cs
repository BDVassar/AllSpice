namespace AllSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;

  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Ingredient Create(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredients
    (name, quantity, recipeId)
    VALUE
    (@name, @quantity, @recipeId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, ingredientData);
    ingredientData.id = id;
    return ingredientData;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
    SELECT *
    FROM ingredients
    Where recipeId = @recipeId;
    ";
    List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    return ingredients;
  }

  internal Ingredient GetOne(int id)
  {
    string sql = @"
    SELECT *
    FROM ingredients
    WHERE id = @id;
    ";
    Ingredient ingredient = _db.Query<Ingredient>(sql, new { id }).FirstOrDefault();
    return ingredient;
  }

  internal void Remove(int id)
  {
    string sql = @"
    DELETE FROM ingredients
    WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }
}
