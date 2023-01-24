<template>
  <section class="row" >
    {{ recipe.title }}
  </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: {
    recipe: { type: Object, require: true }
  },
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped>

</style>