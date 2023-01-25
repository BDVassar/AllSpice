<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-5 rounded p-0 move-up" style="background-color: #f8f9fa">
        <section class="row justify-content-center p-0 m-2 gap-3">
          <button class="btn btn-light col-3" @click="GetRecipes()"> Home</button>
          <button class="btn btn-light col-3" @click="GetMyRecipes()">My Recipes</button>
          <button class="btn btn-light col-3" @click="GetMyFavorites()">Favorites</button>
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
import { accountService } from "../services/AccountService.js";
export default {
  setup() {


    async function GetRecipes() {
      try {
        let recipes = recipesService.GetRecipes()
        return recipes
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }
    onMounted(() => {
      GetRecipes()
    })
    return {
      GetRecipes,
      recipes: computed(() => AppState.recipes),

      async GetMyRecipes() {
        try {
          await recipesService.GetRecipes()
          AppState.recipes = AppState.recipes.filter((r) => r.creatorId == AppState.account.id)
        } catch (error) {
          Pop.error(error)
          logger.log(error)
        }
      },

      async GetMyFavorites(){
        try {
          await accountService.GetMyFavorites()
        } catch (error) {
          Pop.error(error)
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
.move-up {
  transform: translateY(-3vh);
}
</style>
