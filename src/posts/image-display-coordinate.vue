<script setup>
</script>

<style lang="scss">
</style>

<template>
  <h1>Vulkan渲染图片：坐标变换与Repeat Tiling实现</h1>
  <h2>坐标变化</h2>
  <div v-mathjax>
    <p>
      <b>目标</b>：实现类似Photoshop的图片渲染，保持原有图片宽高比例，并且可以缩放，平移。<br />
      一般的渲染区域(宽 $R_w$ 高 $R_h$ )，坐标系从左上角 $(0,0)$ 到右下角 $(R_w,R_h)$ 。 <br />
      一般的图片文件( 宽 $I_w$ 高 $I_h$ )，坐标系统为左上角 $(0,0)$ 到右下角 $(I_w,I_h)$ 。<br />
      Vulkan着色器中，坐标系从左上角 $(-1,-1)$ 到右下角 $(1,1)$ 。<br />
      所幸，和OpenGL不同，Vulkan让这三个坐标系 $x$ 轴 和 $y$ 轴的方向一致，降低了复杂性。<br />
      因此需要找到Vulkan坐标系( $\mathbb{V}$ )和图片坐标系( $\mathbb{I}$ )的一个对应关系。
      <img src="@/assets/images/image-display-coordinate/vulkan-coord.jpg" />
    </p>
    <h3>原始大小渲染</h3>
    <p>
      保留图片的宽高比例，不考虑缩放，即渲染区域和图片的像素一一对应<br />

      设 $$\alpha_w = \frac{I_w}{R_w}, \alpha_h = \frac{I_h}{R_h}$$<br />

      定义映射：
      $$
      i_x = (\frac{v_x}{2\alpha_w}+\frac{1}{2}) \cdot I_w
      $$

      $$
      i_y = (\frac{v_y}{2\alpha_w}+\frac{1}{2}) \cdot I_h
      $$

      $$
      \text{ where } v \in \mathbb{V}, i \in \mathbb{I}
      $$

      可以简写为：
      $$
      i = (\frac{v}{2\alpha}+\frac{1}{2}) \cdot I
      $$

      其中图片区域在Vulkan坐标系中为：
      $$
      i \in [-\alpha_w, \alpha_w] \times [-\alpha_h, \alpha_h]
      $$

      在图片渲染不到的地方，可以在片元着色器<code>discard</code>，露出底色。
      <br />

      渲染效果为：

      <img src="@/assets/images/image-display-coordinate/stage-1.png" />
    </p>

    <h3>缩放 Scale</h3>
    <p>
      加入缩放，则在原来的双摄关系上，加上 $\text{scale} \in (0,\infty)$ , 当其值为 $1$ 的时候，代表无缩放。<br />
      映射关系为：
      $$
      i = (\frac{v}{2\alpha \cdot \text{scale} }+\frac{1}{2})\cdot I
      $$
      其中图片区域在Vulkan坐标系中为：
      $$
      i \in [-\alpha_w\cdot\text{scale}, \alpha_w\cdot\text{scale}]
      \times
      [-\alpha_h\cdot\text{scale},\alpha_h\cdot\text{scale}]
      $$
    </p>

    <h3>位移 Translate</h3>
    <p>
      加入位移的支持，加入 $ \text{translate} \in (-\infty, \infty)$ ，当其值为 $(0,0)$ 时，代表无位移。<br />
      映射关系为：
      $$
      i = (\frac{v-\text{translate} }{2\alpha \cdot \text{scale} }+\frac{1}{2})\cdot I
      $$
      其中图片区域在Vulkan坐标系中为：
      $$

      i \in
      \displaylines{
      [-\alpha_w\cdot\text{scale}\cdot \text{translate}_x, \alpha_w\cdot\text{scale}\cdot \text{translate}_y] \\
      \times\\
      [-\alpha_h\cdot\text{scale}\cdot \text{translate}_x, \alpha_h\cdot\text{scale}\cdot \text{translate}_y]
      }
      $$

      至此，渲染效果为

      <img src="@/assets/images/image-display-coordinate/stage-3.png" />
    </p>
  </div>
  <h2>Repeat Tiling</h2>
  <div>
    <p>
      Repeat Tiling渲染，即为重复平铺同一张图片，并且可以支持在横向或者纵向的错位平铺，效果为：
      <img src="@/assets/images/image-display-coordinate/repeat.png" />
    </p>
    <h3>平铺</h3>
    <p>
      在上一阶段，在图片区域之外，片元着色器会<code>discard</code>。<br />
      为实现平铺，则需要在整个Vulkan坐标系都重复填充图片，通过取余即可。
      映射关系为：
      $$
      i = (\frac{v-\text{translate} }{2\alpha \cdot \text{scale} }+\frac{1}{2})\cdot I \text{ mod } I
      $$

      渲染效果为：
      <img src="@/assets/images/image-display-coordinate/stage-4.png" />
    </p>

    <h3>错位</h3>
    <p>
      错位会在每一行/列错位 $1/f, f\in\mathbb{Z}$ ,即在 $f$ 行/列后，回复到不错位的状态。<br />
      如图所示，首先给每张图片标上他们的位置，记为 $d$ ，中心为 $(0,0)$ 。
      $$
      i_{\text{normal} } = \frac{v-\text{translate} }{2\alpha \cdot \text{scale} }+\frac{1}{2}
      $$

      $$
      d = \text{floor}(i_{\text{normal} })
      $$

      <img src="@/assets/images/image-display-coordinate/stage-5.jpg" />

      如果在 $x$ 轴方向进行错位。可见，错位的大小为 $d_y \cdot 1/f$。 <br />

      即可得到，如果是 $x$ 轴方向错位 $1/f, f\in\mathbb{Z}$
      $$
      i = (i_{\text{normal} } + (1/f,0)\cdot(d_y,d_x)) \cdot I \text{ mod } I
      $$

      同理，如果使 $y$ 轴方向错位：
      $$
      i = (i_{\text{normal} } + (0,1/f)\cdot(d_y,d_x)) \cdot I \text{ mod } I
      $$
    </p>
  </div>
</template>

