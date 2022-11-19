<template>
  <section class="bg-alt">
    <div class="container">
      <header class="section-header">
        <span>Categories</span>
        <h2>Popular categories</h2>
        <p>Here's the most popular categories</p>
      </header>
      <div class="category-grid">
        <a>
          <!-- <i class="fa fa-laptop"></i> -->
          <h6>Technology</h6>
          <p>Designer, Developer, IT Service, Front-end developer, Project management</p>
        </a>
        <a>
          <!-- <i class="fa fa-line-chart"></i> -->
          <h6>Accounting</h6>
          <p>Finance, Tax service, Payroll manager, Book keeper, Human resource</p>
        </a>
        <a>
          <!-- <i class="fa fa-medkit"></i> -->
          <h6>Medical</h6>
          <p>Doctor, Nurse, Hospotal, Dental service, Massagist</p>
        </a>
        <a>
          <!-- <i class="fa fa-cutlery"></i> -->
          <h6>Food</h6>
          <p>Restaurant, Food service, Coffe shop, Cashier, Waitress</p>
        </a>
        <a>
          <!-- <i class="fa fa-newspaper-o"></i> -->
          <h6>Media</h6>
          <p>Journalism, Newspaper, Reporter, Writer, Cameraman</p>
        </a>
        <a>
          <!-- <i class="fa fa-institution"></i> -->
          <h6>Government</h6>
          <p>Federal, Law, Human resource, Manager, Biologist</p>
        </a> 
      </div>
    </div>
  </section>
</template>

<script lang="ts">
  import { Vue } from 'vue-class-component'

  export default class Categories extends Vue {

  }
</script>