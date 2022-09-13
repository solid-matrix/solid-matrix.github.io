<script setup>
import IconPhotoshop from "../assets/icons/icon-photoshop.vue";
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
            <progress max="100" value="14" />
        </p>
        <ol>
            <li>
                <del>Single MultiChannel Layer Render: channel multiply mix method</del>
            </li>
            <li>
                <del>Photoshop Curve Tool Recreation: interpolating cubic spline</del>
                <br />
                <small><a href="/#/blog/photoshop-curve-implement">Check Blog</a></small>

            </li>
            <li>
                <span><del>Vulkan Wrap</del>per</span>
                <br />
                <small>
                    Almost completed <br />
                    need encapsulating more so that user no need to using Silk.Net package
                </small>
            </li>
            <li>
                <span><del>Tile View, Scale, Translate, and Interactions</del></span>
                <br />
                <small>Completed: Mouse and Keyboard Interaction to Scale and Translate</small>
                <br />
                <small>Completed: Repeat Tiling display</small>
                <br />
                <small><a href="/#/blog/image-display-coordinate">Check Blog</a></small>
            </li>

            <li>
                <span><del>Channel Viewer, Layer Vie</del>wer,Artwork Viewer</span>
                <br />
                <small>Completed: Channel Viewer</small>
                <br />
                <small>Completed: Layer Viewer for bilevel, grayscale, rgb, rgba, cmyk</small>
            </li>

            <li>
                <div>Compression</div>
            </li>

            <li>
                <div>File Encoding (PCS Format) TIFF behind or totally new?</div>
                <small>
                    <ul>
                        <li>Artwork save as => PCS format</li>
                        <li>Layer export as => TIF/PNG</li>
                        <li>Channel export as => TIF/PNG format</li>
                    </ul>
                </small>
            </li>

            <li>
                <div>Research one TIFF 6.0</div>
                <small>
                    <ul>
                        <li><a href="https://www.itu.int/itudoc/itu-t/com16/tiff-fx/docs/tiff6.pdf">Tiff 6.0
                                Specification</a>
                        </li>
                        <li>C# Library: <a href="https://github.com/BitMiracle/libtiff.net">LibTiff.NET</a></li>
                    </ul>
                </small>
            </li>

            <li>
                <span>Draw Tools, Functions on Channel and Layers both, and Libraries</span>
            </li>

            <li>
                <span>Tool Interaction: Mouse (Drag, Wheel, Click ), Keyboard (Key Combinations)</span>
            </li>

            <li>
                <span>Transform Functions: Enlarge, Shrink, Clip Canvas, Change Resolution</span>
            </li>

            <li>
                <span>Font Rendering </span>
            </li>

            <li>
                <span>Large Image Process Solution: Tiling or Dynamic Sampler?</span>
            </li>
            <li>
                <span>
                    Artwork Viewer, and its desktop application viewer
                </span>
            </li>
            <li>
                <span>Pattern-based seamlesss Halftoning Algorithem</span>
            </li>
        </ol>
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
                <li>
                    <span>GrayscaleChannel</span>
                    <p>
                        For Grayscale, RGB, RGBA, CMYK, MultiChannel layers; <br />
                        8 bits per sample; <br />
                    </p>
                </li>
                <li><span>BilevelChannel</span>
                    <p>
                        For Bilevel, MultiNBilevelChannel layers; <br />
                        1 bit per sample; <br />
                    </p>
                </li>
            </ul>

            <h4>Encoding (.PCS Format)</h4>
            <p>Encoding considering two methods:</p>
            <ul>
                <li>
                    <div>Tiff behind</div>
                    <div>Pros</div>
                    <ul>
                        <li>relatively flexible</li>
                        <li>if with *.tif/*.tiff suffix, with thumbnail, can open with other image
                            viewer software</li>
                        <li>time saving, no need to create a new encoder library</li>
                    </ul>
                    <div>Cons</div>
                    <ul>
                        <li>not toally flexible</li>
                        <li>if with *.tif suffix and opened with other software, file may be corrupted</li>
                    </ul>
                </li>
                <li>
                    <div>Invent new</div>
                    <div>Pros</div>
                    <ul>
                        <li>totally flexible</li>
                        <li>for viewing the pcs files, can also developed a viewer software besides the editor</li>
                    </ul>
                    <div>Cons</div>
                    <ul>
                        <li>take longer time</li>
                        <li>scalability: the bad designing of the format may lead to remodeling the whole format</li>
                    </ul>
                </li>
            </ul>
            <p>
                If Invent a new format, the format should be like: <br />
                The Encoding of file consists of two parts: header and content. Header part includes all meta
                infomation of the file, and a preview thumbnail. Content part includes only the channel data which is
                compressed. So that software can know the file information without reading the whole file, and can also
                preview the file in a fast way.
            </p>

            <h4>Compression</h4>
            <ul>
                <li>
                    <div>LZ4 Algorithm</div>
                    <p>Very high speed, faster than hard disk speed; about 50% compression ratio</p>
                </li>
                <li>
                    <div>Zip Algorithm</div>
                    <p>Raletiva slow speed; about 25% compression ratio; is file based.</p>
                </li>
                <li>
                    <div>Zstd Algorithm</div>
                    <p></p>
                </li>
            </ul>
        </div>
    </div>

    <h2>Interactions</h2>
    <div id="interactions">
        <h3>User Interface</h3>

        <h3>Mouse Events</h3>
        <ul>
            <li>Wheel Down</li>
            <li>Wheel Up</li>
            <li>Mouse Down</li>
            <li>Mouse Up</li>
            <li>Mouse Move</li>
        </ul>
        <h3>Keyboard Events</h3>
        <ul>
            <li>Key Down</li>
            <li>Key Up</li>
        </ul>
        <h3>Tools & Actions</h3>
        <div>Global</div>
        <ul>
            <li>Vertical Shifting: Wheel Down/Up </li>
            <li>Horizontal Shifting: Shift + Wheel Down / Up </li>
            <li>Zoom Out / In: Ctrl + Wheel Down / Up</li>
            <li>[100% View]</li>
            <li>[Window Fit]</li>
            <li>[Vertial Fit]</li>
            <li>[Horizontal Fit]</li>
        </ul>
        <div>Tools</div>
        <ul>
            <li>
                <span>Hand (H)</span>
                <ul>
                    <li>Shifting: Mouse Drag</li>
                </ul>
            </li>
            <li>
                <span>Zoom (Z)</span>
                <ul>
                    <li>Zoom In: Left Click</li>
                    <li>Zoom Out: Right Click</li>
                </ul>
            </li>
            <li>
                <span>Selection (M)</span>
                <ul>
                    <li>
                        <span>Rectangular/Elliptical Marquee</span>
                        <ul>
                            <li>New Selection: Mouse Drag</li>
                            <li>Plus Selection: Shift + Mouse Drag</li>
                            <li>Minus Selection: Alt + Mouse Drag</li>
                            <li>Intersect Selection: Shift + Alt + Mouse Drag</li>
                        </ul>
                    </li>
                    <li>
                        <span>Polygonal Lasso</span>
                        <ul>
                            <li>New Selection Start: Mouse Click</li>
                            <li>New Selection End: Mouse Click to be a Loop</li>
                            <li>Plus Selection: Shift + Mouse Click When Start</li>
                            <li>Minus Selection: Alt + Mouse Click When Start</li>
                            <li>Intersect Selection: Shift + Alt + Mouse Click When Start</li>
                        </ul>
                    </li>
                    <li>
                        <span>Bezier Curve Lasso</span>
                        <ul>
                            <li>New Selection Start: Mouse Click</li>
                            <li>New Selection End: Mouse Click to be a Loop</li>
                            <li>Curve Adjust: Mouse Drag Twice</li>
                            <li>Plus Selection: Shift + Mouse Click When Start</li>
                            <li>Minus Selection: Alt + Mouse Click When Start</li>
                            <li>Intersect Selection: Shift + Alt + Mouse Click When Start</li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li>
                <span>Shape</span>
                <ul></ul>
            </li>

        </ul>


    </div>

</template>