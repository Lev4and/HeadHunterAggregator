<template>
  <div class="navbar__logo pull-left">
    <a class="navbar-toggle" href="#" data-toggle="offcanvas">
      <i class="ti-menu"></i>
    </a>
    <div class="logo-wrapper">
      <a class="logo">
        <img :src="require('@/assets/img/logo.png')" alt="logo">
      </a>
      <a class="logo-alt">
        <img :src="require('@/assets/img/logo-alt.png')" alt="logo-alt">
      </a>
    </div>
  </div>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class NavigationBarLogo extends Vue {

  }
</script>
