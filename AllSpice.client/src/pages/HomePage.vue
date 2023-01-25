<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-5 rounded p-0 move-down" style="background-color: #f8f9fa">
        <section class="row justify-content-center p-0 m-2 gap-3">
          <button class="btn btn-light col-3"> Home</button>
          <button class="btn btn-light col-3">My Recipes</button>
          <button class="btn btn-light col-3">Favorites</button>
        </section>
      </div>
    </section>
    <section class="row">
      <div v-for="r in recipes" class="col-4" data-bs-toggle="modal" data-bs-target="#recipeDetails">
        <RecipeCard :recipe="r" />
      </div>
    </section>
  </div>
  <ModalComponent id="recipeDetails">
    <RecipeDetails />
  </ModalComponent>
</template>

<script>
import { onMounted, computed } from "vue";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { recipesService } from "../services/RecipesService.js";
import { AppState } from "../AppState.js";
export default {
  setup() {


    async function GetRecipes() {
      try {
        let recipes = recipesService.GetRecipes()
        return recipes;
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }
    onMounted(() => {
      GetRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss">
.move-down {
  transform: translateY(-3vh);
}
</style>
