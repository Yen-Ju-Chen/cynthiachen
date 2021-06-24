import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/login',
    name: 'login',
    component: () => import('../views/Login.vue')
  },
  {
    path: '/',
    name: 'home',
    component: () => import('../views/Home/Home.vue')
  },
  // 查詢收合
  {
    path: '/sample_search',
    name: 'sample_search',
    component: () => import('../views/Sample/SampleSearch.vue')
  },
  // 單頁查詢+編輯
  {
    path: '/single_window',
    name: 'single_window',
    component: () => import('../views/Sample/SingleWindow.vue')
  },
  {
    path: '/admin',
    name: 'admin',
    meta: {
      requiresAuth: true,
      title: '使用者管理',
      icon: 'md-list'
    },
    component: () => import('../views/Admin/Admin.vue')
  },
  {
    path: '/category',
    name: 'category',
    meta: {
      requiresAuth: true,
      title: '類表管理',
      icon: 'md-list'
    },
    component: () => import('../views/Category/Category.vue')
  },
  {
    path: '/FileType',
    name: 'fileType',
    meta: {
      requiresAuth: true,
      title: '資料類型管理',
      icon: 'md-list'
    },
    component: () => import('../views/FileType/FileType.vue')
  },
  {
    path: '/collection',
    name: 'collection',
    meta: {
      requiresAuth: true,
      title: '藏品管理',
      icon: 'md-list'
    },
    component: () => import('../views/Collection/Collection.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router