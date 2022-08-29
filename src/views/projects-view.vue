<script setup>
import { RouterLink } from "vue-router";
import projects from '@/posts/_projects';
</script>

<template>
    <h1>项目</h1>
    <ul v-for="[key, project] in Object.entries(projects)">
        <li :key="key">
            <RouterLink :to="{ name: 'project', params: { key } }">{{ project.title }}</RouterLink>
        </li>
    </ul>
</template>