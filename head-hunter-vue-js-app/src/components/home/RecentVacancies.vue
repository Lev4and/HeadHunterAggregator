<template>
  <section>
    <div class="container">
      <header class="section-header">
        <span>Latest</span>
        <h2>Recent jobs</h2>
      </header>
      <div class="row item-blocks-connected">
        <div class="col-xs-12">
          <a class="item-block">
            <header>
              <img :src="require('@/assets/img/logo-google.jpg')" alt="">
              <div class="hgroup">
                <h4>Senior front-end developer</h4>
                <h5>Google</h5>
              </div>
              <div class="header-meta">
                <span class="location">Menlo park, CA</span>
                <span class="label label-success">Full-time</span>
              </div>
            </header>
          </a>
        </div>
        <div class="col-xs-12">
          <a class="item-block">
            <header>
              <img :src="require('@/assets/img/logo-linkedin.png')" alt="">
              <div class="hgroup">
                <h4>Software Engineer (Entry or Senior)</h4>
                <h5>Linkedin</h5>
              </div>
              <div class="header-meta">
                <span class="location">Livermore, CA</span>
                <span class="label label-warning">Part-time</span>
              </div>
            </header>
          </a>
        </div>
        <div class="col-xs-12">
          <a class="item-block">
            <header>
              <img :src="require('@/assets/img/logo-envato.png')" alt="">
              <div class="hgroup">
                <h4>Full Stack Web Developer</h4>
                <h5>Envato</h5>
              </div>
              <div class="header-meta">
                <span class="location">San Francisco, CA</span>
                <span class="label label-info">Freelance</span>
              </div>
            </header>
          </a>
        </div>
        <div class="col-xs-12">
          <a class="item-block">
            <header>
              <img :src="require('@/assets/img/logo-facebook.png')" alt="">
              <div class="hgroup">
                <h4>Web Applications Developer</h4>
                <h5>Facebook</h5>
              </div>
              <div class="header-meta">
                <span class="location">Lexington, MA</span>
                <span class="label label-danger">Internship</span>
              </div>
            </header>
          </a>
        </div>
        <div class="col-xs-12">
          <a class="item-block">
            <header>
              <img :src="require('@/assets/img/logo-microsoft.jpg')" alt="">
              <div class="hgroup">
                <h4>Sr. SQL Server Developer</h4>
                <h5>Microsoft</h5>
              </div>
              <div class="header-meta">
                <span class="location">Palo Alto, CA</span>
                <span class="label label-success">Remote</span>
              </div>
            </header>
          </a>
        </div>
      </div>
      <br><br>
      <p class="text-center">
        <a class="btn btn-info">Browse all jobs</a>
      </p>
    </div>
  </section>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class RecentVacancies extends Vue {

  }
</script>