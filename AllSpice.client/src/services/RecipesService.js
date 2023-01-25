import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {

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


}

export const recipesService = new RecipesService();