function loadMathJax() {
    if (window.MathJax) {
        window.MathJax.typeset();
        return;
    }

    window.MathJax = {
        tex: {
            inlineMath: [['$', '$'], ['\\(', '\\)']]
        },
        svg: {
            fontCache: 'global'
        },
        startup: {
            pageReady: () => {
                return window.MathJax.startup.defaultPageReady().then();
            }
        }
    };

    (function () {
        var script = document.createElement('script');
        script.src = 'https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-svg.js';
        script.async = true;
        document.head.appendChild(script);
    })();
}

export default {
    install: (app, options) => {
        app.directive('mathjax', {
            mounted(el, binding, vnode, prevVnode) {
                loadMathJax();
            },
            updated(el, binding, vnode, prevVnode) {
                loadMathJax();
            }
        });
    }
}