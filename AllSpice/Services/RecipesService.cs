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

  internal Recipe GetOne(string userId,int id)
  {
    Recipe recipe = _repo.GetOne(id);
    if (recipe == null){
      throw new Exception("no recipe by that id.");
    }
    if (recipe.creatorId != userId){
      throw new Exception ("you do not have access to this Recipe.");
    }
    return recipe;
    
  }
}
