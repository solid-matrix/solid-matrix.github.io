<script setup>
</script>

<style lang="scss">
</style>

<template>
  <h1>Vulkan学习笔记</h1>

  <div id="vulkan-diagram">
    <h2>Vulkan 对象之间关系图示</h2>
    <blockquote>
      Github Repo: <a
        href="https://github.com/David-DiGioia/vulkan-diagrams">https://github.com/David-DiGioia/vulkan-diagrams</a>
    </blockquote>

    <h3>Boilerplate</h3>
    <img src="@/assets/images/vulkan-notes/boiler_plate.png" />

    <h3>Render pass and swapchain</h3>
    <img src="@/assets/images/vulkan-notes/render_pass_swapchain.png" />

    <h3>Vertex buffer creation</h3>
    <img src="@/assets/images/vulkan-notes/vertex_buffer.png" />

    <h3>Vertex input and multiple bindings</h3>
    <img src="@/assets/images/vulkan-notes/vertex_input.png" />

    <h3>Descriptor sets</h3>
    <img src="@/assets/images/vulkan-notes/descriptor_sets.png" />

    <h3>Push constants</h3>
    <img src="@/assets/images/vulkan-notes/push_constants.png" />

    <h3>Pipeline barriers</h3>
    <img src="@/assets/images/vulkan-notes/barrier.png" />

    <h3>Fence Synchronization</h3>
    <img src="@/assets/images/vulkan-notes/fence_synchronization.png" />

    <h3>Render loop</h3>
    <img src="@/assets/images/vulkan-notes/render_loop.png" />
  </div>

  <div id="mvp-spaces">
    <h2>Model View Projection 空间转换</h2>

    <h3>齐次坐标与矩阵乘法</h3>
    <p>TODO</p>

    <h3>Model 模型空间</h3>
    <p>TODO</p>

    <h3>View 观察空间</h3>
    <p>TODO</p>

    <h3>Projection 投影空间</h3>
    <p>TODO</p>

  </div>

  <div id="compute-shader">
    <h2>计算着色器的应用</h2>
    <p>TODO</p>

  </div>

  <div id="vulkan-winforms-render">
    <h2>Vulkan在WinForms的渲染</h2>
    <p>TODO</p>

  </div>

  <div>
    <h2>Vulkan在C#中的实践</h2>
    <p>TODO</p>

  </div>

</template>