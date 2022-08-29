import { createApp } from "vue";

import app from "./app.vue";
import router from "./router";
import mathjax from "./plugins/mathjax";

import "./assets/styles/main.scss";

createApp(app)
    .use(router)
    .use(mathjax)
    .mount("#app");