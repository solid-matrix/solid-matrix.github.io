<script setup>
import { useRoute } from 'vue-router';
import { defineAsyncComponent } from 'vue';
import posts from '../posts/_posts';
import NotFound from '../components/not-found.vue';

const route = useRoute();
const project = posts[route.params.key];
const Content = project ? defineAsyncComponent(() => import(`../posts/${project.component}.vue`)) : NotFound;
</script>

<template>
    <Content />
</template>