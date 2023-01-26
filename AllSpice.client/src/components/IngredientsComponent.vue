<template>
  <section v-if="ingredient" class="row">
    <div v-if="account.id == recipe.creatorId" class="col-1">
      <span class="mdi mdi-pen selectable"></span>
    </div>
    <div class="col-8">{{ ingredient.quantity }} {{ ingredient.name }}</div>
    <div v-if="account.id == recipe.creatorId" class="col-1">
      <span class="mdi mdi-delete text-danger selectable"></span>
    </div>
  </section>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';

export default {
  props: {
    ingredient: { type: Object, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account),
      recipe: computed(() => AppState.activeRecipe),

    }
  }
};
</script>


<style lang="scss" scoped>

</style>