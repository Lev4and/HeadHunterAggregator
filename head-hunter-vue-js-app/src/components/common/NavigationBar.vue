<template>
  <nav class="navbar">
    <div class="container">
      <NavigationBarLogo />
      <NavigationBarUserAccount />
      <NavigationBarMenu />
    </div>
  </nav>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component'
  import NavigationBarLogo from './navigationBar/NavigationBarLogo.vue'
  import NavigationBarUserAccount from './navigationBar/NavigationBarUserAccount.vue'
  import NavigationBarMenu from './navigationBar/NavigationBarMenu.vue'

  @Options({
    components: {
      NavigationBarLogo,
      NavigationBarUserAccount,
      NavigationBarMenu,
    },
  })
  export default class NavigationBar extends Vue {

  }
</script>