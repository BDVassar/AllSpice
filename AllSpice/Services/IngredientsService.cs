namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _ingredientsRepository;
  private readonly RecipesService _recipeService;

  public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
  {
    _ingredientsRepository = ingredientsRepository;
    _recipeService = recipesService;
  }

  internal Ingredient Create(Ingredient ingredientData)
  {
    Ingredient ingredient = _ingredientsRepository.Create(ingredientData);
    return ingredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId, string userId)
  {
    Recipe recipe = _recipeService.GetOne(recipeId);

    List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
    return ingredients;

  }

  internal string Remove(int id)
  {
    Ingredient ingredient = _ingredientsRepository.GetOne(id);
    if (ingredient == null)
    {
      throw new Exception("No Ingredient by that Id.");
    }
    _ingredientsRepository.Remove(id);
    return $"{ingredient.name} has been deleted";
  }
}
