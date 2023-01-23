namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{

  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0provider;
  private readonly IngredientsService _ingredientsService;

  public RecipesController(RecipesService recipesService, Auth0Provider auth0provider, IngredientsService ingredientsService)
  {
    _recipesService = recipesService;
    _auth0provider = auth0provider;
    _ingredientsService = ingredientsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> create([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.creatorId = userInfo.Id;
      Recipe recipe = _recipesService.Create(recipeData);
      recipe.creator = userInfo;
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet]
  public ActionResult<List<Recipe>> Get()
  {
    try
    {
      List<Recipe> recipes = _recipesService.Get();
      return recipes;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Recipe> GetOne(int id)
  {
    try
    {

      Recipe recipe = _recipesService.GetOne(id);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);

      Recipe recipe = _recipesService.EditRecipe(recipeData, userInfo?.Id, id);
      return recipe;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> RemoveRecipe(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      String message = _recipesService.RemoveRecipe(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{id}/ingredients")]
  public async Task<ActionResult<List<Ingredient>>> GetIngredientsByRecipeId(int id)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(id, userInfo?.Id);
      return Ok(ingredients);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
