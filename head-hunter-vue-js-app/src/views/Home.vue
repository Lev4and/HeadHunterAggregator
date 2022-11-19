<template>
  <div class="home">
    <Header />
    <main>
      <RecentVacancies />
      <Facts />
      <HowItWorks />
      <Categories />
      <Newsletter />
    </main>
  </div>
</template>

<script lang="ts">
  import { Options, Vue } from 'vue-class-component'
  import Header from '@/components/home/Header.vue'
  import RecentVacancies from '@/components/home/RecentVacancies.vue'
  import Facts from '@/components/home/Facts.vue'
  import HowItWorks from '@/components/home/HowItWorks.vue'
  import Categories from '@/components/home/Categories.vue'
  import Newsletter from '@/components/home/Newsletter.vue'

  @Options({
    components: {
      Header,
      RecentVacancies,
      Facts,
      HowItWorks,
      Categories,
      Newsletter,
    },
  })
  export default class Home extends Vue {}
</script>
