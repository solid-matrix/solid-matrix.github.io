<script setup>
import SolidmatrixPycasoSchedule from "./solidmatrix-pycaso-schedule.vue";
import SolidmatrixPycasoArchitecture from "./solidmatrix-pycaso-architecture.vue";
import SolidmatrixPycasoUserInterface from "./solidmatrix-pycaso-user-interface.vue";
</script>

<template>
    <h1>SolidMatrix Pycaso</h1>

    <h2>Introduction</h2>
    <div id="introduction">
        <h3>Software Design Purpose</h3>
        <p>
            The software <b>SolidMatrix Pycaso</b> is designed to improve the pattern-designing and color-separation
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

    <SolidmatrixPycasoSchedule> </SolidmatrixPycasoSchedule>

    <SolidmatrixPycasoArchitecture> </SolidmatrixPycasoArchitecture>

    <SolidmatrixPycasoUserInterface> </SolidmatrixPycasoUserInterface>


</template>