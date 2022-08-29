<script setup>
import { ref } from 'vue';

let count = ref(0);
</script>

<template>
  <div v-mathjax>
    <h1>Test</h1>
    <p>
      When $a \ne 0$, there are two solutions to \(ax^2 + bx + c = {{ count }}\) and they are
      $$x = {-b \pm \sqrt{b^2-4ac} \over 2a}.$$
    </p>
    <button @click="count++">+</button>
  </div>
</template>