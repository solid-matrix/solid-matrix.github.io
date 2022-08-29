<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <nav>
      <span class="title">SolidMatrix</span>
      <RouterLink to="/">主页</RouterLink>
      <RouterLink to="/blogs">日志</RouterLink>
      <RouterLink to="/projects">项目</RouterLink>
      <RouterLink to="/resources">资源</RouterLink>
    </nav>
  </header>
  <main>
    <RouterView></RouterView>
  </main>
  <footer>
  </footer>
</template>

<style scoped lang="scss">
@media print {
  header a {
    display: none;
  }
}

header {
  margin: 0 auto;
  padding: 16px 16px;

  nav {
    .title {
      font-weight: bold;
      padding-right: 8px;
    }

    a {
      padding: 0 8px;
    }
  }
}

main {
  margin: 0 auto;
  padding: 0 16px;
}

footer {
  margin: 0 auto;
  padding: 0 16px;
}
</style>
