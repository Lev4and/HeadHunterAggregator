<template>
  <footer class="site-footer">
    <FooterTopSection />
    <FooterBottomSection />
  </footer>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component'
  import FooterTopSection from '@/components/common/footer/FooterTopSection.vue'
  import FooterBottomSection from '@/components/common/footer/FooterBottomSection.vue'

  @Options({
    components: {
      FooterTopSection,
      FooterBottomSection,
    },
  })
  export default class Footer extends Vue {

  }
</script>