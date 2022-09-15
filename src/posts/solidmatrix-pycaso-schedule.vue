<template>
  <h2>Schedule</h2>
  <p>
    <progress max="100" value="20" />
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
      <div><del>Compression</del></div>
      <small>
        Two Options: LZ4 for faster compression, Zstd for higher compression ratio. Let users choose.
      </small>
    </li>

    <li>
      <div><del>File Encoding (PCS Format) TIFF behind or totally new?</del></div>
      <small>
        <ul>
          <li>Completed: Artwork save as => PCS format</li>
          <li>Todo: Layer export as => TIF/PNG</li>
          <li>Todo: Channel export as => TIF/PNG format</li>
        </ul>
      </small>
    </li>

    <li>
      <div><del>Research one TIFF 6.0</del></div>
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
      <div><del>Lar</del>ge Image Solution</div>
      <small>
        <ul>
          <li>Completed: Gpu, Cpu & Memory Limit Analysis</li>
          <li>Completed: Image Render, Process, Storage Methodology Analysis</li>
          <li>Todo: Dynamic Cache Implementation</li>
          <li>Todo: Adoptive Sampler Implementation</li>
          <li>Todo: Reactive Redraw Framework Implementation</li>
        </ul>
      </small>
    </li>

    <li>
      <div>Draw Tools, Selection Tools Functions on Channel and Layers both, and Libraries</div>
      <small>
      </small>
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
      <span>
        Artwork Viewer, and its desktop application viewer
      </span>
    </li>
    <li>
      <span>Pattern-based seamlesss Halftoning Algorithem</span>
    </li>
  </ol>
</template>