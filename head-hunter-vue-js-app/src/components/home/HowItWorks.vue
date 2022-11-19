<template>
  <section>
    <div class="container">
      <div class="col-sm-12 col-md-6">
        <header class="section-header text-left">
          <span>Workflow</span>
          <h2>How it works</h2>
        </header>
        <p class="lead">Pellentesque et pulvinar orci. Suspendisse sed euismod purus. Pellentesque nunc ex, ultrices eu enim non, consectetur interdum nisl. Nam congue interdum mauris, sed ultrices augue lacinia in. Praesent turpis purus, faucibus in tempor vel, dictum ac eros.</p>
        <p>Nulla quis felis et orci luctus semper sit amet id dui. Aenean ultricies lectus nunc, vel rhoncus odio sagittis eu. Sed at felis eu tortor mattis imperdiet et sed tortor. Nullam ac porttitor arcu. Vivamus tristique elit id tempor lacinia. Donec auctor at nibh eget tincidunt. Nulla facilisi. Nunc condimentum dictum mattis.</p>
        <br><br>
        <a class="btn btn-primary">Learn more</a>
      </div>
      <div class="col-sm-12 col-md-6 hidden-xs hidden-sm">
        <br>
        <img class="center-block" :src="require('@/assets/img/how-it-works.png')" alt="how it works">
      </div>
    </div>
  </section>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class HowItWorks extends Vue {

  }
</script>