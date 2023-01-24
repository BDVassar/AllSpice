<template>
  <div class="container m-4 rounded p-0" id="background">
    <section class="row justify-content-end">
      <div class="col-3 p-2 d-flex justify-content-center align-items-center">
        <form action="">
          <div class="form-floating input-group">
            <input type="text" class="form-control" id="SearchInput" placeholder="">
            <button class="btn btn-light rounded-end mdi mdi-magnify fs-5 SearchInput" type="button"></button>
            <label for="floatingInput">Search...</label>
          </div>
        </form>
      </div>
      <div class=" col-1 bg-none p-2 d-flex justify-content-center align-items-center">
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>
    </section>
    <section class="row justify-content-center align-items-bottom">
      <div class="col-6 text-center text-light">
        <h2>All-Spice</h2>
        <h4>Cherish Your Family </h4>
        <h4>And Their Cooking</h4>
      </div>
    </section>
  </div>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
#background {
  height: 350px;
  background-image: url("https://s3-alpha-sig.figma.com/img/137d/d14c/aa93e0df14a805e8e10c9f1221ba5131?Expires=1675641600&Signature=Nf8-ly9zYPkUxBGJrOoGuGV1AubHpks5Rx8bm5M0lRjsr1hWttGmgnVRNvFK7K9kVCvqhMdEnuzdbEDtl2a-HDs1ttFmIfoe6SdJQh~Zny7viHvh44IAfDdrI0tz7ZObyvWSGWnsoK2WF6VZRSc6arxiLKZMB8zo86bp5HAeDQ61ZG0SWRnu3z5vWuh9bnEWY2Xm-Er8K~~5PcMct~OdWe7dMDi7ckcxgTMGPKXHyHDMFH5BGGxI1kc7-mUJFitZ~sNZJnojoLPOpm8hYMIzVoGCoogm6EcWWQIkYu5eoYM47rrR1707eCGeUIn6ymFUZi18-afC2udj0yLle-wSiw__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4");
  background-position: top;
  background-size: cover;
  box-shadow: 10px, 10px, 10px, 10px, #000000;
}

#SearchInput {
  height: 5vh;
}

.SearchInput {
  height: 5vh;
}
</style>
