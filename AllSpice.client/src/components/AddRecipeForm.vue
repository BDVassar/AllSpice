<template>
  <div class="modal-header">
    <h1 class="modal-title fs-5" id="exampleModalLabel">Edit Your Account</h1>
    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
  </div>
  <div class="modal-body container">
    <form @submit.prevent="createRecipe()">
      <section class="form-floating row mb-3">
        <div class="col-12 form-floating p-1">
          <input required maxlength="40" v-model="recipeData.title" type="text" class="form-control" id="title"
            placeholder="title">
          <label for="title">Recipe Title</label>
        </div>
      </section>
      <section class="row mb-3">
        <div class="form-floating col-12 p-1">
          <input required maxlength="200" v-model="recipeData.instructions" type="text" class="form-control"
            id="instructions" placeholder="instructions">
          <label for="instructions">Instructions</label>
        </div>
      </section>
      <section class="row mb-3">
        <div class="form-floating col-12 p-1">
          <input required maxlength="240" v-model="recipeData.img" type="text" class="form-control" id="img"
            placeholder="img">
          <label for="img">Recipe Picture</label>
        </div>
      </section>
      <section class="row mb-3">
        <div class="form-floating col-12 p-1">
          <select required v-model="recipeData.category" class="form-select" id="inputGroupSelect01">
            <option selected>Choose...</option>
            <option value="Soup">Soup</option>
            <option value="Cheese">Cheese</option>
            <option value="Specialty Coffee">Specialty Coffee</option>
            <option value="PIzza">Pizza</option>
          </select>
          <label for="recipe">Recipe Category</label>
        </div>
      </section>
      <section class="row justify-content-end">
        <div class="col-2 text-end">
          <button type="submit" class="btn btn-primary">Create</button>
        </div>
        <div class="col-2 text-start">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        </div>
      </section>
    </form>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { recipesService } from "../services/RecipesService.js";
import { Modal } from "bootstrap";
export default {
  setup() {
    const recipeData = ref({})
    return {
      recipeData,

      async createRecipe() {
        try {
          await recipesService.createRecipe(recipeData.value);
          recipeData.value = {}
          Modal.getOrCreateInstance('#addRecipe').hide()
          Modal.getOrCreateInstance('#recipeDetails').show()
        } catch (error) {
          Pop.error(error)
          logger.error(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>

</style>