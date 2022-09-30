<template>
    <h1>SolidMatrix Pycaso</h1>

    <div id="introduction">
        <h2>Introduction</h2>

        <div id="introduction-purpose">
            <h3>Software Design Purpose</h3>
            <p>
                The software <b>SolidMatrix Pycaso</b> is designed to improve the pattern-designing and color-separation
                procedures in textile screen printing industry. The most common softwares to create and design new
                pattern is Adobe Photoshop and Adobe Illustrator. While both of them have several inconveniences on this
                job: users cannot view the design in a tiling way; users have to handle the edge join manually; the
                layers
                and channels functions are not in a suitable way; these two offerred good outline-based drawing, but
                shape-based drawing relatively inadequate. Therefore, a new software, <b>Pycaso</b> is necessary to
                complete
                these inconveniences. Besides, the color seperation is the core function of <b>Pycaso</b>, while
                Photoshop
                can do but in a very redundant way. Some automation auxilliary tools also in demand to accelerate the
                designing and color-seperation job, which will be integrated into <b>Pycaso</b>.
            </p>
        </div>

        <div id="introduction-tech-stack">
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
        </div>

        <div id="introduction-dev-docs">
            <h3>Development Documents</h3>
            <ul>
                <li>
                    <RouterLink to="/post/solidmatrix-pycaso-notes">Notes</RouterLink>
                </li>
                <li>
                    <RouterLink to="/post/solidmatrix-pycaso-spec">Specification</RouterLink>
                </li>
                <li>
                    <RouterLink to="/post/solidmatrix-pycaso-ui">User Interface Design</RouterLink>
                </li>
            </ul>
        </div>
    </div>

    <div id="schedule">
        <h2>Schedule [<progress max="100" value="20"></progress>]</h2>

        <h3>Todo</h3>
        <ul id="schedule-todo">
            <li>
                <div>Reactive Render Framework Implementation</div>
                <ul class="small">
                    <li>render only on uniform buffer update or framebuffer resize</li>
                </ul>
            </li>

            <li>
                <div>Dynamic Sampler Implementation</div>
                <ul class="small">
                    <li>Display-resolution-based sampler</li>
                </ul>
            </li>

            <li>
                <div>File Encoding (PCS Format).</div>
                <ul class="small">
                    <li>Research: Tiff bihind or a totally new format.
                        <RouterLink to="/post/solidmatrix-pycaso-notes">Check Notes</RouterLink>.
                    </li>
                    <li>Completed: Artwork save as => PCS format</li>
                    <li>Todo: Layer export as => TIF/PNG</li>
                    <li>Todo: Channel export as => TIF/PNG format</li>
                </ul>
            </li>

            <li>
                <div>Draw Tools, Selection Tools Functions on Channel and Layers both, and Libraries</div>
            </li>

            <li>
                <div>Tool Interaction: Mouse (Drag, Wheel, Click ), Keyboard (Key Combinations)</div>
            </li>

            <li>
                <div>Action Handler Chain: to handle actions by chain and their priorities</div>
                <ul class="small">
                    <li>like Chain of Responsibility Pattern</li>
                </ul>
            </li>

            <li>
                <div>Transform Functions: Enlarge, Shrink, Clip Canvas, Change Resolution</div>
            </li>

            <li>
                <div>Font Rendering </div>
            </li>

            <li>
                <div>Pattern-based seamlesss Halftoning Algorithem</div>
            </li>

            <li>
                <div>Research: Vulkan Multiple Subpass rendering</div>
            </li>

            <li>
                <div>Analysis: Parallel Computation</div>
                <ul class="small">
                    <li>Seperate the application into several threads to improve the performance.</li>
                </ul>
            </li>
        </ul>

        <h3>Pending</h3>
        <ul id="schedule-pending">
            <li>
                <div>Photoshop Curve Tool Recreation: interpolating cubic spline</div>
                <ul class="small">
                    <li>
                        <RouterLink to="/blog/photoshop-curve-implement">Check Blog</RouterLink>
                    </li>
                    <li>Todo: Integrate into software</li>
                </ul>
            </li>
            <li>
                <div>Vulkan Wrapper</div>
                <ul class="small">
                    <li>Completed: necessary wrapper</li>
                    <li>Completed: IDisposable for all</li>
                    <li>Todo: encapsulate more so that user no need to using Silk.Net package.</li>
                    <li>Todo: Create a new wheel: skip Silk.Net and remap functions directly.</li>
                </ul>
            </li>
            <li>
                <div>Artwork Viewer, and its desktop application viewer</div>
            </li>
        </ul>

        <h3>Archived</h3>
        <ul id="schedule-archived">
            <li>
                <div><del>Single MultiChannel Layer Render: channel multiply mix method</del></div>
            </li>
            <li>
                <div><del>Tile View, Scale, Translate, and Interactions</del></div>
                <ul class="small">
                    <li>Completed: Mouse and Keyboard Interaction to Scale and Translate.</li>
                    <li>Completed: Repeat Tiling display.</li>
                    <li>
                        <RouterLink to="/blog/image-display-coordinate">Check Blog</RouterLink>
                    </li>
                </ul>
            </li>
            <li>
                <div><del>Channel Viewer, Layer Vie</del>wer,Artwork Viewer</div>
                <ul class="small">
                    <li>Completed: Channel Viewer</li>
                    <li>Completed: Layer Viewer for bilevel, grayscale, rgb, rgba, cmyk, multichannel</li>
                </ul>
            </li>
            <li>
                <div><del>Compression Research</del></div>
                <ul class="small">
                    <li>
                        <RouterLink to="/post/solidmatrix-pycaso-notes">Check Notes</RouterLink>.
                    </li>
                    <li>
                        <del>Two Options: LZ4 for faster compression, Zstd for higher compression ratio. Let users
                            choose.</del>
                    </li>
                    <li>
                        Only one option needL zstd, zstd is fast enough.
                    </li>
                </ul>
            </li>
            <li>
                <div><del>Research one TIFF 6.0</del></div>
                <ul class="small">
                    <li><a href="https://www.itu.int/itudoc/itu-t/com16/tiff-fx/docs/tiff6.pdf">TIFF 6.0
                            Specification</a></li>
                    <li>C# Library: <a href="https://github.com/BitMiracle/libtiff.net">LibTiff.NET</a></li>
                </ul>
            </li>
            <li>
                <div><del>Large Image Solution Research</del></div>
                <ul class="small">
                    <li>
                        Completed: Gpu, Cpu & Memory Limit Analysis.
                        <RouterLink to="/post/solidmatrix-pycaso-notes">Check Notes</RouterLink>.
                    </li>
                    <li>
                        Completed: Image Render, Process, Storage Methodology Analysis.
                        <RouterLink to="/post/solidmatrix-pycaso-notes">Check Notes</RouterLink>.
                    </li>
                </ul>
            </li>
            <li>
                <div><del>Adaptive Cache Implementation</del></div>
                <ul class="small">
                    <li>
                        C# have a good implemention:
                        <a
                            href="https://learn.microsoft.com/en-us/dotnet/standard/io/memory-mapped-files">MemoryMappedFile</a>.
                        Good for huge file operation.
                    </li>
                </ul>
            </li>
        </ul>
    </div>
</template>