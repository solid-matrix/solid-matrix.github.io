import { createRouter, createWebHashHistory } from "vue-router";

const router = createRouter({
    history: createWebHashHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: "/",
            name: "home",
            component: () => import("./views/home-view.vue"),
        }, {
            path: "/blogs",
            name: "blogs",
            component: () => import("./views/blogs-view.vue"),
        }, {
            path: "/blog/:key",
            name: "blog",
            component: () => import("./views/blog-view.vue"),
        }, {
            path: "/projects",
            name: "projects",
            component: () => import("./views/projects-view.vue"),
        }, {
            path: "/project/:key",
            name: "project",
            component: () => import("./views/project-view.vue"),
        }, {
            path: "/post/:key",
            name: "post",
            component: () => import("./views/post-view.vue"),
        }, {
            path: "/resources",
            name: "resources",
            component: () => import("./views/resources-view.vue"),
        }, {
            path: "/test",
            name: "test",
            component: () => import("./views/test-view.vue"),
        },
    ],
});

export default router;
