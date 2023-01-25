<template>
  <div class="container-fluid">
    <section class="row justify-content-center">
      <div class="col-3 rounded p-0 move-up" style="background-color: #f8f9fa">
        <section class="row justify-content-evenly p-0 m-2 gap-3">
          <router-link :to="{ name: 'Home' }" class="col-3">
            <button class="btn btn-white"> Home</button>
          </router-link>
          <button class="btn btn-light col-3">Edit</button>
        </section>
      </div>
    </section>
    <div class="about text-center">
      <h1>Welcome {{ account.name }}</h1>
      <img class="rounded" :src="account.picture" alt="" />
      <p>{{ account.email }}</p>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.move-up {
  transform: translateY(-3vh);
}
</style>
