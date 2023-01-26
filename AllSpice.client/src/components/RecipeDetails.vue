<template>
  <div v-if="recipe" class="component">
    <div class="modal-body container-fluid py-0 ps-0">
      <section class="row">
        <div class="col-4">
          <img class="img-fluid rounded-start" :src="recipe.img" alt="">
        </div>
        <div class="col-8">
          <section class="row justify-content-end">
            <div v-if="recipe.creatorId == account.id" class="col-1">
              <button @click="RemoveRecipe(recipe.id)" type="button" class="btn btn-link text-danger mdi mdi-delete"
                data-bs-dismiss="modal"></button>
            </div>
          </section>
          <section class="row">
            <h5>{{ recipe.title }}</h5>
          </section>
          <section class="row justify-content-evenly dataRow align-items-between">
            <div class="col-5 elevation-5 rounded">
              <section class="row p-3 text-center bgcolor rounded-top text-light">
                <h6>Recipe Instructions</h6>
              </section>
              <p>{{ recipe.instructions }}</p>
            </div>
            <div class="col-5 elevation-5 rounded">
              <section class="row p-3 text-center bgcolor rounded-top text-light">
                <h6>Recipe Ingredients</h6>
              </section>
              <section class="row">
                <div v-for="i in ingredients" class="col-12">
                  <IngredientsComponent :ingredient="i" />
                  <section class="row py-4">
                    <form @submit.prevent="createIngredient()" class="form-floating">
                      <div class="input-group mb-3">
                        <input v-model="ingredientData.name" type="text" class="form-control"
                          placeholder="Ingredient Name" aria-label="Ingredient" aria-describedby="button-addon2">
                      </div>
                      <div class="input-group mb-3">
                        <input v-model="ingredientData.quantity" type="text" class="form-control" placeholder="Quantity"
                          aria-label="Quantity" aria-describedby="button-addon2">
                      </div>
                      <div class="d-flex justify-content-end">
                        <button class="btn btn-outline-secondary mdi mdi-plus" type="submit"
                          id="button-addon2"></button>
                      </div>
                    </form>
                  </section>
                </div>
              </section>
            </div>
            <div class="col-12 text-end">
              <p>{{ recipe.creator.name }}</p>
            </div>
          </section>
        </div>
      </section>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
import { ingredientsService } from "../services/IngredientsService.js";
export default {
  setup() {
    const ingredientData = new ref({})

    onMounted(() => {
    })

    return {
      ingredientData,
      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.activeIngredients),
      account: computed(() => AppState.account),

      async RemoveRecipe(recipeId) {
        try {
          let message = await recipesService.RemoveRecipe(recipeId)
        } catch (error) {
          Pop.error(error);
          logger.log(error);
        }
      },
      
      async createIngredient() {
        try {
          await ingredientsService.createIngredient(ingredientData.value);
        } catch (error) {
          Pop.error(error);
          logger.error(error);
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.bgcolor {
  background-color: #527360;
}

.dataRow {
  height: 100%;
}
</style>