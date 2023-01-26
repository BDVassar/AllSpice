import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";
class IngredientsService {

  async createIngredient(ingredientData) {
    const res = await api.post('api/ingredients', ingredientData);
    logger.log("[Ingredient Created", res.data)
    AppState.activeIngredients.push(res.data)
  }
}

export const ingredientsService = new IngredientsService()