<script setup>
import { RouterLink } from "vue-router";
import blogs from '@/posts/_blogs';

</script>

<template>
    <h1>日志</h1>
    <ul>
        <li v-for="[key, blog] in Object.entries(blogs)" :key="key" class="post">
            <span class="title">
                <RouterLink :to="{ name: 'blog', params: { key } }"> {{  blog.title  }} </RouterLink>
            </span>
            <span class="auther">by {{  blog.author  }}</span>
            <div></div>
            <span class="tags">
                <span v-for="tag in blog.tags" :key="tag" class="tag"> {{  tag  }} </span>
            </span>
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

    .auther {
        font-size: 1em;
        font-style: italic;
        padding-left: 1em;
        color: gray;
    }

    .tags {
        font-size: 1em;
        color: white;

        .tag {
            display: inline-block;
            margin: 2px 2px;
            padding: 0 4px;
            border-radius: 4px;
            background-color: gray;
        }
    }
}
</style>