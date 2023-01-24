<template>
  <section v-if="recipe" class="row cardblur m-4 rounded" :style="{ backgroundImage: `url('${recipe.img}')`, }">
    <div class="col-12">
      <section @click="SetActiveRecipe(recipe.id)" class="row p-3 cardheight selectable rounded elevation-5"
        :style="{ backgroundImage: `url('${recipe.img}')` }">
        <div class="col-12 d-flex flex-column justify-content-between">
          <section class="row justify-content-between">
            <div class="col-4 text-center text-light bluredbackground rounded-pill">
              <p class="fs-6 m-0">{{ recipe.category }}</p>
            </div>
            <div class="col-1 text-center p-0 bluredbackground "><span class="mdi mdi-heart-outline"></span>
            </div>
          </section>
          <section class="row">
            <div class="col-12 bluredbackground rounded text-white">
              <p>
                {{ recipe.title }}
              </p>
            </div>
          </section>
        </div>
      </section>
    </div>
  </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
export default {
  props: {
    recipe: { type: Object, require: true }
  },
  setup() {
    return {
      async SetActiveRecipe(recipeId){
        try {
          recipesService.SetActiveRecipe(recipeId);
        } catch (error) {
          Pop.error(error)
          logger.log(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.bluredbackground {
  background-color: rgba(53, 54, 54, 0.425);
}

.cardheight {
  height: 40vh;
  background-position: center;
  background-size: cover;
}

.cardblur {
  background-position: center;
  background-size: cover;
  backdrop-filter: blur(8px);
}
</style>