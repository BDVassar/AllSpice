<template>
  <div v-if="recipe" class="component">
    <div class="modal-body container-fluid py-0 ps-0">
      <section class="row">
        <div class="col-4">
          <img class="img-fluid rounded-start" :src="recipe.img" alt="">
        </div>
        <div class="col-8">
          <section class="row justify-content-end">
            <div class="col-1">
              <button type="button" class="btn btn-link text-danger mdi mdi-close" data-bs-dismiss="modal"></button>
            </div>
          </section>
          <section class="row">
            <h5>{{ recipe.title }}</h5>
          </section>
          <section class="row justify-content-evenly">
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
                <div class="col-12">
                  <IngredientsComponent />
                </div>
              </section>
            </div>
          </section>
        </div>
      </section>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
export default {
  setup() {

    async function getIngredients(){
      try {
        
      } catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }

    return {
      recipe: computed(() => AppState.activeRecipe)
    }
  }
};
</script>


<style lang="scss" scoped>
.bgcolor {
  background-color: #527360;
}
</style>