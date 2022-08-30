<script setup>
</script>

<template>
    <h1>SolidMatrix Pycaso</h1>

    <h2>Introduction</h2>
    <div id="introduction">
        <h3>Software Design Purpose</h3>
        <p>
            The software <b>SolidMatrix Pycase</b> is designed to improve the pattern-designing and color-separation
            procedures in textile screen printing industry. The most common softwares to create and design new
            pattern is Adobe Photoshop and Adobe Illustrator. While both of them have several inconveniences on this
            job: users cannot view the design in a tiling way; users have to handle the edge join manually; the layers
            and channels functions are not in a suitable way; these two offerred good outline-based drawing, but
            shape-based drawing relatively inadequate. Therefore, a new software, <b>Pycaso</b> is necessary to complete
            these inconveniences. Besides, the color seperation is the core function of <b>Pycaso</b>, while Photoshop
            can do but in a very redundant way. Some automation auxilliary tools also in demand to accelerate the
            designing and color-seperation job, which will be integrated into <b>Pycaso</b>.
        </p>
        <h3>Technology Stack</h3>
        <ul>
            <li>
                <span>Language & Platform: </span>
                <a href="https://docs.microsoft.com/en-us/dotnet/">.NET 6.0</a>
                <span>, </span>
                <a href="https://docs.microsoft.com/en-us/dotnet/csharp/">C#</a>
            </li>
            <li>
                <span>Graphic: </span>
                <a href="https://vulkan.org/">Vulkan 1.3</a>
                <span>, </span>
                <a href="https://github.com/dotnet/Silk.NET">Silk.NET</a>
            </li>
            <li>
                <span>Desktop: </span>
                <a href="https://docs.microsoft.com/en-us/dotnet/desktop/winforms">Windows Forms</a>
            </li>
        </ul>
        <h3>Documents & References</h3>
        <ul>
            <li>
                <span>TIFF 6.0: </span>
                <a href="https://www.itu.int/itudoc/itu-t/com16/tiff-fx/docs/tiff6.pdf">Specification</a>
            </li>
        </ul>
    </div>

    <h2>Schedule</h2>
    <div id="schedule">
        <p>
            <progress max="100" value="10" />
        </p>
        <ol>
            <li>
                <del>Single MultiChannel Layer Render: channel multiply mix method</del>
            </li>
            <li>
                <del>Photoshop Curve Tool Recreation: interpolating cubic spline</del>
                <br />
                <a href="/#/blog/photoshop-curve-implement">Check Blog</a>
            </li>
            <li>Vulkan Wrapper</li>
            <li>Channel Viewer, Layer Viewer</li>
            <li>Tile View, Scale, Transpose</li>
            <li>Draw Tools, Functions on Channel and Layers both, and Libraries</li>
            <li>Large Image Process Solution: Tiling or Dynamic Sampler?</li>
            <li>File Encoding</li>
            <li>Artwork Viewer, and its desktop application viewer</li>
        </ol>
        <p></p>
    </div>

    <h2>Architecture</h2>
    <div id="architecture">
        <h3>Subprojects</h3>
        <div>
            <ul>
                <li>
                    <b>SolidMatrix.Vulkan: </b>
                    <span>Silk.NET Vulkan wrapper</span>
                </li>
                <li>
                    <b>SolidMatrix.Pycaso.Core</b>
                    <span>Core libraries</span>
                </li>
                <li>
                    <b>SolidMatrix.Pycaso.Utility: </b>
                    <span>Common tools and utility functions</span>
                </li>

                <li>
                    <b>SolidMatrix.Pycaso.Desktop: </b>
                    <span>Desktop application</span>
                </li>

                <li>
                    <b>SolidMatrix.Pycaso.Viewer: </b>
                    <span>Artwork, layer and channel viewer to help the development</span>
                </li>
            </ul>
        </div>

        <h3>File format</h3>
        <div>
            <p>Three hierarchy: Artwork - Layer - Channel</p>

            <h4>Artwork</h4>
            <p>Artwork is a collection of Layers.</p>

            <h4>Layer</h4>
            <p>
                Layer is a single image, like Photoshop'concept of layer. But in Pycaso, each layer can have their own
                foramt, not like Photoshop, each layer all in same format. Each layer have same dimension and
                resolution.
            </p>
            <p>
                Layer types:
            </p>
            <ul>
                <li>Bilevel Layer</li>
                <li>Grayscale Layer</li>
                <li>RGB Layer</li>
                <li>RGBA Layer</li>
                <li>CMYK Layer</li>
                <li>MultiChannel Layer</li>
                <li>MultiBilevelChannel Layer</li>
            </ul>


            <h4>Channel</h4>
            <p>
                Channel is of the concept of color seperation. Like RGB layers have Red, Green, and Blue three channels;
                CMYK layers have Cyan, Magenta, Yellow and Key four channels. MultiChannel layers have 0 or more
                channels,
                no specific number. Each channel defines the color lightness(for RGB RGBA Grayscale formats) or pigment
                density(for Bilevel, CMYK, MultiChannel, MultiBilevelChannel formats).
            </p>
            <p>
                Channel types:
            </p>
            <ul>
                <li>GrayscaleChannel: for Grayscale, RGB, RGBA, CMYK, MultiChannel layers</li>
                <li>BilevelChannel: for Bilevel, MultiNBilevelChannel layers</li>
            </ul>

            <h4>Encoding</h4>
            <p>
                The Encoding of file consists of two parts: header and content. Header part includes all meta infomation
                of the file, and a preview thumbnail. Content part includes only the channel data which is compressed.
                So that software can know the file information without reading the whole file, and can also preview the
                file in a fast way.
            </p>
        </div>
    </div>

</template>