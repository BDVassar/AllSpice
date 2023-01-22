namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe Create(Recipe recipeData)
  {
    Recipe recipe = _repo.Create(recipeData);
    return recipe;
  }


  internal List<Recipe> Get()
  {
    List<Recipe> recipes = _repo.Get();
    return recipes;
  }

  internal Recipe GetOne(int id)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null)
    {
      throw new Exception("no recipe by that id.");
    }

    return recipe;

  }
  internal Recipe EditRecipe(Recipe recipeData, string userId, int id)
  {
    Recipe originalRecipe = this.GetOne(id);
    if (originalRecipe.creatorId != userId)
    {
      throw new Exception("you do not have access to this Recipe.");
    }
    originalRecipe.title = recipeData.title ?? originalRecipe.title;
    originalRecipe.instructions = recipeData.instructions ?? originalRecipe.instructions;
    originalRecipe.img = recipeData.img ?? originalRecipe.img;
    originalRecipe.category = recipeData.category ?? originalRecipe.category;

    Boolean updated = _repo.EditRecipe(originalRecipe);
    if (updated == false)
    {
      throw new Exception("The recipe was not updated");
    }
    return originalRecipe;
  }

  internal string RemoveRecipe(int recipeId, string userId)
  {
    Recipe original = this.GetOne(recipeId);
    if (original.creatorId != userId)
    {
      throw new Exception("you do not have access to this Recipe.");
    }
    _repo.RemoveRecipe(recipeId);
    return $"{original.title} was deleted";
  }
}
