function loadMathJax() {
    if (window.MathJaxLoaded) {
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
                return window.MathJax.startup.defaultPageReady().then(() => {
                    window.MathJaxLoaded = true;
                });
            }
        }
    };

    (function () {
        var script = document.createElement('script');
        script.src = 'https://unpkg.com/mathjax@3/es5/tex-mml-chtml.js';
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