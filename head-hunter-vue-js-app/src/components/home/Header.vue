<template>
  <header class="site-header size-lg text-center">
    <div class="container">
      <div class="col-xs-12">
        <br><br>
        <h2>We offer <mark>1,259</mark> job vacancies right now!</h2>
        <h5 class="font-alt">Find your desire one in a minute</h5>
        <br><br><br>
        <form class="header-job-search">
          <div class="input-keyword">
            <input type="text" class="form-control" placeholder="Job title">
          </div>
          <div class="btn-search">
            <button class="btn btn-primary" type="submit">Find jobs</button>
            <a>Advanced Job Search</a>
          </div>
        </form>
      </div>
    </div>
  </header>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class Header extends Vue {

  }
</script>