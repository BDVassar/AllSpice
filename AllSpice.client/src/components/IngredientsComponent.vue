<template>
  <section v-if="ingredient" class="row">
    <div class="col-1 mdi mdi-pen"></div>
    <div class="col-8">{{ ingredient.name }}</div>
    <div class="col-1 mdi mdi-close text-danger"></div>
  </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: {
    ingredient: { type: Object, required: true }
  },
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped>

</style>