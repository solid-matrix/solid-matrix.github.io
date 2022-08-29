<script setup>
import { RouterLink } from "vue-router";
import blogs from '@/posts/_blogs';

</script>

<template>
    <h1>日志</h1>
    <ul v-for="[key, blog] in Object.entries(blogs)">
        <li :key="key">
            <RouterLink :to="{ name: 'blog', params: { key } }">{{ blog.title }}</RouterLink>
        </li>
    </ul>
</template>