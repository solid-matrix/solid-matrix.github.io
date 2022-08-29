<script setup>
import { RouterLink } from "vue-router";
import projects from '@/posts/_projects';
</script>

<template>
    <h1>项目</h1>
    <ul>
        <li v-for="[key, project] in Object.entries(projects)" :key="key" class="post">
            <span class="title">
                <RouterLink :to="{ name: 'project', params: { key } }">{{ project.title }}</RouterLink>
            </span>
            <div></div>
            <span class="description">{{ project.description }}</span>
        </li>
    </ul>
</template>


<style scoped lang="scss">
.post {
    font-size: 1em;
    line-height: 1.6em;
    padding: 0.4em 0;

    .title {
        font-size: 1em;
    }

    .description {
        font-size: 1em;
        font-style: italic;
        color: gray;
    }
}
</style>