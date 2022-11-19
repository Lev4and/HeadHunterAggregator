<template>
  <NavigationBar />
  <router-view />
  <Footer />
  <a-back-top>
    <div class="ant-back-top-inner">
      <font-awesome-icon icon="fa-solid fa-arrow-up" />
    </div>
  </a-back-top>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component'
  import NavigationBar from '@/components/common/NavigationBar.vue'
  import Footer from '@/components/common/Footer.vue'

  @Options({
    components: {
      NavigationBar,
      Footer,
    },
  })
  export default class App extends Vue {}
</script>
