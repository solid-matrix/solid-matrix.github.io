<template>
  <h2>SolidMatrix Pycaso Specification</h2>

  <div id="spec-subprojects">
    <h3>Subprojects</h3>
    <ul>
      <li>
        <b>SolidMatrix.Groundwork: </b>
        <span>Basic auxilliary libraries</span>
      </li>
      <li>
        <b>SolidMatrix.Vulkan: </b>
        <span>Silk.NET Vulkan wrapper</span>
      </li>
      <li>
        <b>SolidMatrix.Pycaso.Core: </b>
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
        <b>SolidMatrix.Pycaso.Utility: </b>
        <span>Utilities to help the development</span>
      </li>
    </ul>
  </div>

  <div id="spec-data-structure">
    <h3>Data Structure</h3>

    <p>Three hierarchy: <b>Artwork</b> - <b>Layer</b> - <b>Channel</b></p>

    <h4>Artwork</h4>
    <p>Artwork is a collection of Layers.</p>
    <table>
      <tr>
        <th colspan="2">Artwork Types</th>
      </tr>
      <tr>
        <th>Type</th>
        <th>Remarks</th>
      </tr>
      <tr>
        <td>Base</td>
        <td>Normal Type Artwork</td>
      </tr>
    </table>


    <h4>Layer</h4>
    <p>
      Layer is a single image, like Photoshop'concept of layer. But in Pycaso, each layer can have their own
      mode (not like Photoshop, each layer all in same mode). Each layer have same dimension and
      resolution.
    </p>
    <table>
      <tr>
        <th colspan="5">Layer Types</th>
      </tr>
      <tr>
        <th>Type</th>
        <th>Channel Count</th>
        <th>Channel Type</th>
        <th>Channel Color Blend Mode</th>
        <th>Channel White Black Mode</th>
      </tr>
      <tr>
        <td>Bilevel Layer</td>
        <td>1</td>
        <td>Bilevel Channel</td>
        <td>Subtractive</td>
        <td>Zero-Is-White</td>
      </tr>
      <tr>
        <td>Grayscale Layer</td>
        <td>1</td>
        <td>Grayscale Channel</td>
        <td>Subtractive</td>
        <td>Zero-Is-Black</td>
      </tr>
      <tr>
        <td>RGB Layer</td>
        <td>3 (RGB)</td>
        <td>Grayscale Channel</td>
        <td>Additive</td>
        <td>Zero-Is-Black</td>
      </tr>
      <tr>
        <td>RGBA Layer</td>
        <td>4 (RGBA)</td>
        <td>Grayscale Channel</td>
        <td>Additive</td>
        <td>Zero-Is-Black</td>
      </tr>
      <tr>
        <td>CMYK Layer</td>
        <td>4 (CMYK)</td>
        <td>Grayscale Channel</td>
        <td>Subtractive</td>
        <td>Zero-Is-White</td>
      </tr>
      <tr>
        <td>MultiChannel Layer</td>
        <td>0 or more</td>
        <td>Grayscale Channel</td>
        <td>Subtractive</td>
        <td>Zero-Is-White</td>
      </tr>
      <tr>
        <td>MultiBilevelChannel Layer</td>
        <td>0 or more</td>
        <td>Bilevel Channel</td>
        <td>Subtractive</td>
        <td>Zero-Is-White</td>
      </tr>
    </table>

    <h4>Channel</h4>
    <p>
      Channel is of the concept of color seperation.
      Like RGB layers have Red, Green, and Blue three channels;
      CMYK layers have Cyan, Magenta, Yellow and Key four channels.
      MultiChannel layers have 0 or more channels, no specific number.
      Each channel defines the color lightness(for RGB RGBA Grayscale formats)
      or pigment density(for Bilevel, CMYK, MultiChannel, MultiBilevelChannel formats).
    </p>
    <table>
      <tr>
        <th colspan="2">Channel Types</th>
      </tr>
      <tr>
        <th>Type</th>
        <th>Bits Per Sample</th>
      </tr>
      <tr>
        <td>Bilevel Channel</td>
        <td>1</td>
      </tr>
      <tr>
        <td>Grayscale Channel</td>
        <td>8</td>
      </tr>
    </table>

  </div>

  <div id="spec-file-encoding">
    <h3>File Encoding (.PCS Format)</h3>

    <p>Format Codec Encoding Structure</p>

    <table>
      <tr>
        <th colspan="5">PCS Format</th>
      </tr>
      <tr>
        <th>Name</th>
        <th>Offset</th>
        <th>Size</th>
        <th>Type</th>
        <th>Usage</th>
      </tr>
      <tr>
        <td>Header Block</td>
        <td>0</td>
        <td>4KB</td>
        <td> - </td>
        <td>contain the identifier, and offsets and sizes of following blocks</td>
      </tr>
      <tr>
        <td>Meta Block</td>
        <td>4KB</td>
        <td>512KB</td>
        <td>UTF-8 JSON </td>
        <td>Contain the meta data of the file</td>
      </tr>
      <tr>
        <td>Thumbnail Block</td>
        <td>516KB</td>
        <td>192KB</td>
        <td>raw RGB bitmap</td>
        <td>Contain one raw bitmap data</td>
      </tr>

      <tr>
        <td>Data Block #0</td>
        <td>708KB</td>
        <td> - </td>
        <td>raw Grayscale/Bilevel Bitmap</td>
        <td>Contain data of one channel</td>
      </tr>
      <tr>
        <td colspan="5" style="text-align:center;">. . . Other Data Blocks . . .</td>
      </tr>

    </table>
    <table>
      <tr>
        <th colspan="3">Header Block</th>
      </tr>
      <tr>
        <th>Size</th>
        <th>Type</th>
        <th>Usage</th>
      </tr>
      <tr>
        <td>8B</td>
        <td>ASCII String</td>
        <td>Identifier</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>4 ushort</td>
        <td>Software Version (major.minor.build.platform)</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>4 ushort</td>
        <td>Format Version (major.minor.build.platform)</td>
      </tr>

      <tr>
        <td>8B</td>
        <td>long</td>
        <td>offset of meta block</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>size of meta block</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>offset of thumbnail block</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>size of thumbnail block</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>number of data blocks</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>offset of data block 0</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>size of data block 0</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>offset of data block 1</td>
      </tr>
      <tr>
        <td>8B</td>
        <td>long</td>
        <td>size of data block 1</td>
      </tr>
      <tr>
        <td colspan="3" style="text-align:center;">. . . Other Data Offsets and Sizes . . .</td>
      </tr>
    </table>

    <p>
      <b><i>Remark: </i></b>
      Maximum 252 data blocks are supported
    </p>

    <table>
      <tr>
        <th colspan="3">Meta Block</th>
      </tr>
      <tr>
        <th>Size</th>
        <th>Type</th>
        <th>Usage</th>
      </tr>
      <tr>
        <td>512KB</td>
        <td>utf-8 string</td>
        <td>Json format meta infomation</td>
      </tr>
    </table>

    <p>
      <b><i>Remark:</i></b>
      keep 512KB, amending the meta infomation no need to rewrite the whole file
    </p>

    <table>
      <tr>
        <th colspan="3">Thumbnail Block</th>
      </tr>
      <tr>
        <th>Size</th>
        <th>Type</th>
        <th>Usage</th>
      </tr>
      <tr>
        <td>192KB</td>
        <td>bytes array</td>
        <td>256px*256px size thumnail RGB bitmap</td>
      </tr>
    </table>

    <table>
      <tr>
        <th>Data Block</th>
        <th>Offset = 708KB</th>
        <th>Size = Unlimited</th>
      </tr>
      <tr>
        <th>Size</th>
        <th>Type</th>
        <th>Usage</th>
      </tr>
      <tr>
        <td>Unlimited</td>
        <td>bytes array</td>
        <td>compressed channel bitmap</td>
      </tr>
    </table>
  </div>

  <div id="spec-dynamic-sampler">
    <h3>Dynamic Sampler</h3>
    <p>
      To render huge image which exceed the GPU image dimension limits,
      the dynamic sampler is display-resolution-based sampler.
      The sampler do sampling and render in a constant time, is display resolution related.
    </p>
  </div>

  <div id="spec-reactive-render">
    <h3>Reactive Render Framework</h3>
    <p>
      A general vulkan render framework. Register shader variables and run automatically.
    </p>
    <ul class="small">
      <li>Register uniform buffer;</li>
      <li>Register uniform image;</li>
      <li>Register vertex inputs;</li>
      <li>Register vertex attributes;</li>
      <li>Register constants push;</li>
    </ul>
  </div>

  <div id="spec-tools-select">
    <h3>Select Tools</h3>

    <p>Selection is a grayscale image format</p>
  </div>

  <div id="spec-tools-draw">
    <h3>Draw Tools</h3>

    <p></p>
  </div>

</template>