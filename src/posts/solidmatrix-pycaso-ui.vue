<template>

  <h2>SolidMatrix Pycaso User Interface</h2>
  <div id="ui">
    <h3>Interactions</h3>

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