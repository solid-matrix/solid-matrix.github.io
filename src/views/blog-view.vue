<script setup>
import { useRoute } from 'vue-router';
import { defineAsyncComponent } from 'vue';
import blogs from '../posts/_blogs';
import NotFound from '../components/not-found.vue';

const route = useRoute();
const blog = blogs[route.params.key];
const Content = blog ? defineAsyncComponent(() => import(`../posts/${blog.component}.vue`)) : NotFound;
</script>

<template>
    <Content />
</template>