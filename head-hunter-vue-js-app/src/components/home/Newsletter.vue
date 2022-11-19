<template>
  <section class="newsletter bg-img text-center">
    <div class="container">
      <h2><strong>Subscribe</strong></h2>
      <h6 class="font-alt">Get weekly top new jobs delivered to your inbox</h6>
      <br><br>
      <form class="form-subscribe" action="#">
        <div class="input-group">
          <input type="text" class="form-control input-lg" placeholder="Your eamil address">
          <span class="input-group-btn">
            <button class="btn btn-success btn-lg" type="submit">Subscribe</button>
          </span>
        </div>
      </form>
    </div>
  </section>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class Newsletter extends Vue {

  }
</script>