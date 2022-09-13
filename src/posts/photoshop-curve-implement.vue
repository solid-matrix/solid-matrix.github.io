<script setup>
</script>

<style lang="scss">
</style>

<template>
    <h1>Photoshop曲线工具的实现</h1>

    <div v-mathjax>
        <h2>基础</h2>
        <h3>Polynomial Interpolation 多项式插值</h3>
        <p>
            给定 $n+1$ 组数据点， $(x_0,y_0), ..., (x_n,y_n)$ , $x_i$ 两两不相等。<br />
            多项式函数 $p(x)$ 被称之为以上 $n+1$ 个数据点的插值函数当 $ p(x_i) = y_i, \text{ for each } i\in \{0,1,...,n\} $ <br />
            常见的多项式插值函数算法：Lagrange polynomial 拉格朗日多项式与 Newton polynomial 牛顿多项式。
        </p>
        <h3>Spline Interpolation 样条曲线插值</h3>
        <p>
            样条曲线插值基于多项式插值，给定 $n+1$ 组控制点，$(x_0,y_0), ..., (x_n,y_n)$ 。
            把曲线分成 $n$ 小段 $(x_0,y_0) \text{ to } (x_1,y_1), ... , (x_{n-1},y_{n-1}) \text{ to } (x_n,y_n)$。
            与多项式插值不同，寻找一个高次数的多项式通过所有的控制点，Spline插值分成 $n$ 小段，每一段都是低次数的多项式。
            通过Spline 插值，同时也避免了龙格现象（Runge's phenomenon），即高次数曲线在边界情况是误差很大的现象。
        </p>
        <h3>Cubic Spline Interpolation 立方样条曲线插值</h3>
        <p>
            定义曲线 $y=q_i(x)$ 为相邻两个控制点 $(x_{i-1},y_{i-1})$ 到 $(x_i,y_i)$ 之间的曲线。<br />
            定义曲线 $y=y(x)$ 的曲率 $\kappa$ 为
            $$
            \kappa = \frac{y''}{ (1+y'^2 )^{3/2} }
            $$
            其中 $y'$ 与 $y''$ 分别为一次与二次导数。<br />
            因为我们需要的曲线时连续且平滑的。因此需要满足以下要求：
            $$
            \bigg\{ {
            \displaylines{
            q'_i(x_i) = q'_{i+1}(x_i) \\
            q''_i(x_i) = q''_{i+1}(x_i)
            } }, 1 \le i \le n-1
            $$

            需满足此要求，$q_i(x)$ 多项式次数需在3次及以上。<br />
            我们便使用其最低即3次的形式：Cubic Spline Interpolation 立方样条曲线插值。
        </p>

        <h2>算法</h2>
        <h3>阶段一</h3>
        <p>
            先考虑曲线 $(x_1,y_1)$ 到 $(x_2,y_2)$ 之间的曲线 $q(x)$ ，使
            $$
            \displaylines{
            q(x_1) = y_1, \\
            q(x_2) = y_2, \\
            q'(x_1) = k_1, \\
            q'(x_2) = k_2, \\
            }
            $$
            $k_1$ 和 $k_2$ 为两个端点的斜率。<br />
            可得 $q(x)$ 的对称形式：
            $$
            q(x) = (1-t(x))y_1 + t(x)y_2 + t(x)(1-t(x))((1-t(x))a+t(x)b)
            $$
            其中
            $$
            \displaylines{
            t(x) = \frac{x-x_1}{x_2-x_1}, \\
            a = k1(x_2-x_1) - (y_2-y_1), \\
            b = -k_2(x_2-x_1) + (y_2-y_1).
            }
            $$
            有
            $$
            \displaylines{
            q' = \frac{dq}{dx}=\frac{dq}{dt} \frac{dt}{dx} = \frac{dq}{dt} \frac{1}{x_2-x_1},\\
            q' = \frac{y_2-y_1}{x_2-x_1} + (1-2t)\frac{a(1-t)+bt}{x_2-x_1} + t(1-t)\frac{b-a}{x_2-x_1},\\
            q'' =2\frac{b-2a+(a-b)3t}{(x_2-x_1)^2}
            }
            $$
            当 $t(x)$ $x$ 取值 $x_1$ 和 $x_2$ 时，可得 $t(x_1) = 0$ 和 $t(x_2) = 1$，因此
            $$
            \displaylines{
            q''(x_1) = 2\frac{b-2a}{(x_2-x_1)^2}\\
            q''(x_2) = 2\frac{a-2b}{(x_2-x_1)^2}\\
            }
            $$
            当代入 $(x_i,y_i), i=0,1,...,n$ $n+1$ 个点后
            $$
            \displaylines{
            q_i = (1-t)y_{i-1} + ty_i+t(1-t)((1-t)a_i+tb_i),\\
            t=\frac{x-x_{i-1} }{x_i-x_{i-1} },\\
            a_i = k_{i-1}(x_i-x_{i-1}) - (y_i-y_{i-1}),\\
            b_i = -k_i(x_i-x_{i-1}) + (y_i-y_{i-1})
            }
            $$
            当 $i=1,...,n$，可得
            $$
            \displaylines{
            k_0 = q'_1(x_0),\\
            k_i = q'_i(x_i) = q'_{i+1}(x_i),\\
            k_n = q'_n(x_n).
            }
            $$
            因有 $q''_i(x_i) = q''_{i+1}(x_i)$，可得
            $$
            \displaylines{
            \frac{k_{i-1} }{x_i-x_{i-1} } + (\frac{1}{x_i-x_{i-1} } + \frac{1}{ x_{i+1}-x_i })2k_i+\frac{k_{i+1}
            }{x_{i+1} -x_i} \\
            = \\
            3(\frac{y_i-y_{i-1} }{(x_i-x_{i-1})^2} + \frac{y_{i+1} -y_i}{(x_{i+1}-x_i)^2})
            }
            $$
            因有
            $$
            \displaylines{
            q''_1(x_0) = 0,
            q''_n(x_n) = 0,
            }
            $$
            可得
            $$
            \displaylines{
            \frac{2}{x_1-x_0}k_0+\frac{1}{x_1-x_0}k_1= 3\frac{y_1-y_0}{(x_1-x_0)^2},\\
            \frac{1}{x_n-x_{n-1} }k_{n-1}+\frac{2}{x_n-x_{n-1} }k_n= 3\frac{y_n-y_{n-1} }{(x_n-x_{n-1} )^2}.
            }
            $$
            另外我们定义，在 $x_1$ 和 $x_{n-1}$ 三次导数依然连续。即
            $$
            \displaylines{
            q'''_1(x_1) = q'''_2(x_1),\\
            q'''_{n-1}(x_{n-1}) = q'''_n(x_{n-1})
            }
            $$
            即可得
            $$
            \displaylines{
            \frac{1}{\Delta x_1^2}k_0 + (\frac{1}{\Delta x_1^2}-\frac{1}{\Delta x_2^2})k_1 - \frac{1}{\Delta x_2^2}k_2 =
            2(\frac{\Delta y_1}{\Delta x_1^3}-\frac{\Delta y_2}{\Delta x_2^3}),\\

            \frac{1}{\Delta x_{n-1}^2}k_{n-2} +
            (\frac{1}{\Delta x_{n-1}^2}-\frac{1}{\Delta x_n^2})k_{n-1} - \frac{1}{\Delta x_n^2}k_n =
            2(\frac{\Delta y_{n-1} }{\Delta x_{n-1} ^3}-\frac{\Delta y_n}{\Delta x_n^3}).
            }
            $$
            其中 $\Delta x_i = x_i - x_{i-1}, \Delta y_i = y_i-y_{i-1}$
        </p>

        <h3>阶段二</h3>
        <p>
            综上，我们要求得 $k_0,...,k_n$，即需求解
            $$
            \left[
            \begin{array}{ccc}
            a_{11} & a_{12} & 0 & & 0 & \ldots & 0 \\
            a_{21} & a_{22} & a_{23} & 0 &0 & \ldots & 0 \\
            0 & a_{32} & a_{33} & a_{34} & 0 & \ldots & 0 \\
            0 & 0 & a_{43} & a_{44} & a_{45} & \ldots & 0 \\
            0 & 0 & 0 & a_{54} & a_{55} & \ldots & 0 \\
            \vdots & \vdots & \vdots & \vdots & \vdots & \ddots & a_{n-1,n} \\
            0 &0 &0 &0 &0 & a_{n,n-1} & a_{n,n} \\
            \end{array}

            \right]

            \left[
            \begin{array}{ccc}
            k_0 \\
            k_1 \\
            k_2 \\
            k_3 \\
            k_4 \\
            \vdots \\
            k_{n-1}
            \end{array}

            \right]

            =
            \left[
            \begin{array}{ccc}
            b_1 \\
            b_2 \\
            b_3 \\
            b_4 \\
            b_5 \\
            \vdots \\
            b_n
            \end{array}

            \right]
            $$

            其中
            $$
            \displaylines{
            a_{11} = \frac{2}{x_1-x_0} \\
            a_{22} = 2(\frac{1}{x_1-x_0}+\frac{1}{x_2-x_1}) \\
            \vdots \\
            a_{n,n} =\frac{2}{x_n-x_{n-1} } \\


            a_{n-1,n} = \frac{1}{x_{n-1}-x_{n-2} } \\


            a_{n,n-1} = \frac{1}{x_{n-1}-x_{n-2} } \\
            \vdots
            }
            $$
            和
            $$
            \displaylines{
            b_{1} = 3\frac{y_1-y_0}{(x_1-x_0)^2} \\
            b_{2} = 3(\frac{y_1-y_0}{(x_1-x_0)^2}+\frac{y_2-y_1}{(x_2-x_1)^2}) \\
            \vdots \\
            b_{n} = 3\frac{y_n-y_{n-1} }{(x_n-x_{n-1} )^2}
            \vdots
            }
            $$

            这是一个 tridiagonal linear equation system 三对角线性方程组。
        </p>

        <h3>Thomas algorithm 汤姆斯算法</h3>
        <p>
            上一阶段的三对角线线性方程组，如果视作普通的线性方程组，用通用的高斯消元法得解是可行的。
            但是 $O(n^3)$ 的算法复杂度，当 $n$ 比较大时，速度非常慢。 <br />

            可以通过 Thomas algorithm 汤姆斯算法，只有线性复杂度 $O(n)$ 。<br />
            详细可见 <a href="/files/thomas-algorithm-wikipedia.pdf">Thomas algorithm - Wikipedia</a>
        </p>

        <h2>验证</h2>

        <p>
            代码：<a href="/files/cubic-spline.cs"> Attachment: cubic-spline.cs</a>

            <br />
            控制点选择：$(0.0,0.0)$ $(0.2,0.5)$ $(0.5,0.2)$ $(0.7,0.9)$ $(1.0,1.0)$ <br />

            曲线生成效果，实际的曲线生成和Photoshop基本完全一致：
            <img src="@/assets/images/photoshop-curve-implement/photoshop-curve.jpg" />
            <br />
        </p>
    </div>
</template>

