import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

  async createRecipe(recipeData) {
    const res = await api.post('api/recipes', recipeData);
    logger.log('[Recipe Created', res.data);
    AppState.recipes.push(res.data);
    AppState.activeRecipe = res.data;
  }
  async GetRecipes() {
    const res = await api.get('api/recipes')
    // logger.log('[Getting Recipes]', res.data)
    AppState.recipes = res.data
  }

  async SetActiveRecipe(recipeId) {
    const res = await api.get('api/recipes/' + recipeId)
    // logger.log('[SettingActive Recipe]', res.data)
    AppState.activeRecipe = res.data;
    await this.getIngredients(recipeId)
  }
  async getIngredients(recipeId) {
    const res = await api.get('api/recipes/' + recipeId + "/ingredients");
    // logger.log('[Getting Ingredients]', res.data);
    AppState.activeIngredients = res.data;
  }
  async RemoveRecipe(recipeId) {
    const res = await api.delete('api/recipes/' + recipeId)
    logger.log('[Deleted Recipe]', res.data)
    let index = AppState.recipes.findIndex((r) => r.id == recipeId)
    AppState.recipes.splice(index, 1)
  }
}

export const recipesService = new RecipesService();