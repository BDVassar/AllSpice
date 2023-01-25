<template>
  <div class="modal-header">
    <h1 class="modal-title fs-5" id="exampleModalLabel">Edit Your Account</h1>
    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
  </div>
  <div class="modal-body container">
    <form @submit="editAccount()">
      <section class="form-floating row mb-3">
        <div class="col-12 form-floating p-1">
          <input type="text" class="form-control" id="name" placeholder="name" v-model="accountInfo.Name">
          <label for="name">Your Name Here</label>
        </div>
      </section>
      <section class="row mb-3">
        <div class="form-floating col-12 p-1">
          <input type="text" class="form-control" id="picture" placeholder="picture" v-model="accountInfo.Picture">
          <label for="picture">Upload your Picture here</label>
        </div>
      </section>
      <section class="row justify-content-end">
        <div class="col-2 text-end">
          <button type="submit" class="btn btn-primary">Save changes</button>
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
import { accountService } from "../services/AccountService.js";
export default {
  setup() {
    const accountInfo = ref({})
    return {
      accountInfo,

      async editAccount() {
        try {
          accountService.editAccount(accountInfo.value)
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

</style>