<template>
  <h2>SolidMatrix Pycaso Notes</h2>

  <div id="notes-encoding">
    <h3>Encoding Research</h3>
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
          <li>for viewing the pcs files, can also developed a viewer software besides the editor
          </li>
        </ul>
        <div>Cons</div>
        <ul>
          <li>take longer time</li>
          <li>scalability: the bad designing of the format may lead to remodeling the whole format
          </li>
        </ul>
      </li>
    </ul>
    <p>
      If Invent a new format, the format should be like:
    </p>
    <p>
      The Encoding of file consists of two parts: header and content. Header part includes all meta
      infomation of the file, and a preview thumbnail. Content part includes only the channel data
      which
      is
      compressed. So that software can know the file information without reading the whole file, and
      can
      also
      preview the file in a fast way.
    </p>
  </div>

  <div id="notes-compress">
    <h3>Compression Research</h3>

    <table>
      <tr>
        <th colspan="4"> Compression Algorithm Comparison</th>
      </tr>
      <tr>
        <th>Algorithm</th>
        <th>Ratio</th>
        <th>Compress Speed</th>
        <th>Decompress Speed</th>
      </tr>
      <tr>
        <td><a href="https://github.com/facebook/zstd">zstd</a> 1.5.1 -1</td>
        <td>2.887</td>
        <td>530 MB/s</td>
        <td>1700 MB/s</td>
      </tr>
      <tr>
        <td><a href="https://github.com/madler/zlib">zlib</a> 1.2.11 -1</td>
        <td>2.743</td>
        <td>95 MB/s</td>
        <td>400 MB/s</td>
      </tr>
      <tr>
        <td><a href="https://github.com/google/brotli">brotli</a> 1.0.9 -0</td>
        <td>2.702</td>
        <td>395 MB/s</td>
        <td>450 MB/s</td>
      </tr>
      <tr>
        <td>quicklz 1.5.0 -1</td>
        <td>2.238</td>
        <td>540 MB/s</td>
        <td>760 MB/s</td>
      </tr>
      <tr>
        <td>lzo1x 2.10 -1</td>
        <td>2.106</td>
        <td>660 MB/s</td>
        <td>845 MB/s</td>
      </tr>
      <tr>
        <td><a href="https://github.com/lz4/lz4">lz4</a> 1.9.3</td>
        <td>2.101</td>
        <td>740 MB/s</td>
        <td>4500 MB/s</td>
      </tr>
      <tr>
        <td><a href="https://github.com/nemequ/liblzf">lzf</a> 3.6 -1</td>
        <td>2.077</td>
        <td>410 MB/s</td>
        <td>830 MB/s</td>
      </tr>
      <tr>
        <td><a href="https://github.com/google/snappy">snappy</a> 1.1.9</td>
        <td>2.073</td>
        <td>550 MB/s</td>
        <td>1750 MB/s</td>
      </tr>
    </table>
    <p>
      <b><i>Remarks: </i></b>
      After practiced, for grayscale bitmap data, LZ4 have about 50% compressibility;
      and Zstd have about 25% compressibility.
      While LZ4 (<a href="https://github.com/MiloszKrajewski/K4os.Compression.LZ4">K4os.Compression.LZ4</a>)
      is about 4 times faster than Zstd (<a href="https://github.com/oleg-st/ZstdSharp">ZstdSharp.Port</a>) in
      .Net Environment. <br />
      So give users two options:
    <ul>
      <li><b>LZ4</b> for super fast IO speed</li>
      <li><b>Zstd</b> for higher compressibility</li>
    </ul>

    </p>
  </div>

  <div id="notes-limits">
    <h3>GPU, Cpu & Memory Limit Analysis</h3>
    <h4>GPU Limits</h4>
    <table>
      <tr>
        <th>Name</th>
        <th>Device</th>
        <th>Value</th>
      </tr>
      <tr>
        <th rowspan="2">MaxComputeSharedMemorySize</th>
        <td>RTX 2070</td>
        <td>49152 (48KB)</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>32768 (32KB)</td>
      </tr>
      <tr>
        <th rowspan="2">
          MaxComputeWorkGroupInvocations <br />
          local_x * local_y * local_z &lt;= limit
        </th>
        <td>RTX 2070</td>
        <td>1024</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>1024</td>
      </tr>
      <tr>
        <th rowspan="2">MaxComputeWorkGroupCount</th>
        <td>RTX 2070</td>
        <td>2147483647 * 65535 * 65535</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>65536 * 65536 * 65536</td>
      </tr>
      <tr>
        <th rowspan="2">MaxComputeWorkGroupSize</th>
        <td>RTX 2070</td>
        <td>1024 * 1024 * 64</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>1024 * 1024 * 64</td>
      </tr>
      <tr>
        <th rowspan="2">MaxImageArrayLayers</th>
        <td>RTX 2070</td>
        <td>2048</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>2048</td>
      </tr>
      <tr>
        <th rowspan="2">MaxImageDimension2D</th>
        <td>RTX 2070</td>
        <td>32768</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>16384</td>
      </tr>
      <tr>
        <th rowspan="2">MaxUniformBufferRange</th>
        <td>RTX 2070</td>
        <td>65536 (64KB)</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>134217724 (128MB)</td>
      </tr>
      <tr>
        <th rowspan="2">MaxStorageBufferRange</th>
        <td>RTX 2070</td>
        <td>4294967295 (4GB)</td>
      </tr>
      <tr>
        <td>UHD 770</td>
        <td>1073741820 (1GB)</td>
      </tr>
    </table>
    <h4>Case 1: Rotary Screen Full Width 360PPI</h4>
    <small>
      Width = 25.2 inch X 360ppi = 9072px <br />
      Height = 70 inch X 360ppi = 25200px <b>excess UHD 770 image dimension limit</b> <br />
      Channal Size = 9072px X 25200px = 228614400px = 218Mpx<br />
      Channal Raw Storage = 218Mpx X 1B/px = 218MB <br />
      <br />
      Layer Channel Count = 15 <br />
      Layer Raw Storage = 218MB X 15 = 3270MB <b>GPU Memory may not enough</b> <br />
      Layer Compressed Storage = 25% * 817.5MB = 3270MB <br />
      <br />
      Iterate One Channel Pixels = 2.3X10<sup>8</sup> <b>1S per CPU core</b>

    </small>
    <h4>Case 2: Rotary Screen Full Width 720PPI</h4>
    <small>
      Width = 25.2 inch X 720ppi = 18144px <b>excess GPU image dimension limit</b><br />
      Height = 70 inch X 720ppi = 50400px <b>excess GPU image dimension limit</b><br />
      Channal Size = 18144px X 50400px = 914457600px = 872Mpx<br />
      Channal Raw Storage = 872Mpx X 1B/px = 872MB <br />
      <br />
      Layer Channel Count = 15 <br />
      Layer Raw Storage = 872MB X 15 = 13080MB <b>GPU/CPU Memory not enough</b> <br />
      Layer Compressed Storage = 25% * 13080MB = 3270MB <br />
      <br />
      Iterate One Channel Pixels = 9.1X10<sup>8</sup> <b>4S per CPU core</b>

    </small>

    <h4>Case 3: Wide & Extra Large Rotary Screen Full Width 720PPI</h4>
    <small>
      Width = 50.4 inch X 720ppi = 36288px <b>excess GPU image dimension limit</b><br />
      Height = 120 inch X 720ppi = 86400px <b>excess GPU image dimension limit</b><br />
      Channal Size = 36288px X 86400px = 3135283200px = 2990Mpx<br />
      Channal Raw Storage = 2990Mpx X 1B/px = 2990MB <br />
      <br />
      Layer Channel Count = 32 <br />
      Layer Raw Storage = 2990MB X 32 = 95680MB <b>GPU & CPU Memory not enough</b> <br />
      Layer Compressed Storage = 25% * 95680MB = 23920MB <br />
      <br />
      Iterate One Channel Pixels = 31X10<sup>8</sup> <b>30S per CPU core</b>

    </small>
  </div>

  <div id="notes-render-process-storage-method">
    <h3>Image Render, Process, Storage Methodology Analysis</h3>

    <h4>Storage Methodology</h4>
    <p>
      From Case 3 (the extreme case), we can see,
      even store the whole layer in RAM is difficult on normal desktops.
      Only one channel can be stored in RAM, while others have to be cached in disk.
      Have to implement a cache to manipulate this.
      And cache on disk also make it handy to handle recovery from exiting.
    </p>
    <p>
      <u>Adaptive Cache</u>: Read, write and cache adaptively, according to the RAM left.
      Working in the directory of current file.
    </p>
    <h4>Process Methodology</h4>
    <p>
      Considering Case 3, iterate all pixels of one channel takes 30S (1 core, Intel i7-12700).
      if use all cores fully (8 big cores & 4 small cores), 3-4S is needed.
      For worse CPU, it will take longer. So some techniques have to be adopted.
    </p>
    <p>
      <u>Scalable Sampler</u>: the screen resolution is much smaller than limit case image size.
      So only keep a scalable sampler:
      When image pixel is smaller than screen pixel,
      only process on the sampled image for preview.
      then background do the work on raw image.
      The sampled image size is according to screen resolution.
      When image pixel actual size is equal or lager than scrren pixel,
      directly process and display on raw image, each pixel is clear.
    </p>
    <h4>Render Methodology</h4>
    <p>
      Image size will often excess the GPU image dimension limit.
      So can only transfer a sampled image to GPU for displaying.
      The <u>Scalable Sampler</u> explained above can also solve this problem.
      common display resolutions listed below.
      we can see, even on 4K or similar, only about 10Mpx will be used for displaying.
      No need to use raw image with 2990Mpx in extreme case.
    </p>

    <ul>
      <li>1080P display: 1920 X 1080.</li>
      <li>4K display: 4096 X 2160</li>
      <li>Apple iMac Retina: 4480 X 2520 </li>
    </ul>
    <p>
      <u>Reactive Redraw Framework</u>: common graphic software all redraw periodically.
      To reduce the GPU burden, we can develop a reactive redraw framework.
      Only redraw when necessary, like window resized or stage updated, no need periodically redraw.
    </p>
  </div>

</template>