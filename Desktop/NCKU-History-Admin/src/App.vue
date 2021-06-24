<template>
  <div id="app" class="layout">
    <Layout>
      <Header>
        <myheader></myheader>
      </Header>
      <Layout>
        <Sider hide-trigger :style="{background: '#fff'}">
          <mysider></mysider>
        </Sider>
        <Layout :style="{padding: '0 24px 24px'}" class="content">
          <!-- <Breadcrumb :style="{margin: '24px 0'}">
            <BreadcrumbItem>Home</BreadcrumbItem>
            <BreadcrumbItem>Components</BreadcrumbItem>
            <BreadcrumbItem>Layout</BreadcrumbItem>
          </Breadcrumb> -->
          <div class="ivu-page-header">
            <div class="ivu-page-header-title">
              {{this.$route.meta.title}}
            </div>
          </div>
          <!-- <Content :style="{padding: '24px', minHeight: '280px', background: '#fff'}"> -->
          <router-view />
          <!-- </Content> -->
        </Layout>
      </Layout>
    </Layout>
  </div>
</template>
<script>
  import myheader from './views/Header.vue'
  import mysider from './views/Sider.vue'
  export default {
    components: {
      myheader,
      mysider
    }
  }
</script>
<style>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }
</style>
<style lang="less">
  html,
  body {
    width: 100%;
    height: 100%;
    background: #f0f0f0;
    /* overflow: hidden; */
  }

  .app-main {
    width: 100%;
    height: 100%;
  }

  .br button {
    margin-right: 8px;
  }

  .operation button {
    margin-right: 8px;
  }

  .operation .brr button {
    margin-right: 0px !important;
  }

  .ivu-btn-text:focus {
    box-shadow: none !important;
  }

  .ivu-tag {
    cursor: pointer;
  }

  .block-tool .ivu-tooltip,
  .block-tool .ivu-tooltip-rel {
    display: block;
  }

  .block-pop .ivu-poptip,
  .block-pop .ivu-poptip-rel {
    display: block;
  }

  .form-noheight {
    .ivu-form-item-content {
      line-height: unset !important;
    }
  }

  .modal-fullscreen {
    z-index: 1;
    position: absolute;
    right: 43px;
    top: 14px;
    overflow: hidden;
    cursor: pointer;

    .model-fullscreen-icon {
      font-size: 18px;
      color: #999;
      -webkit-transition: color 0.2s ease;
      transition: color 0.2s ease;
      position: relative;
      top: 1px;

      &:hover {
        color: #444;
      }
    }
  }

  .viewer-container {
    z-index: 2050 !important;
  }

  .ivu-page-header {
    width: 110%;
    padding: 16px 32px;
    margin-bottom: 16px;
    margin-top: 8px;
    background: #fff;
    border-bottom: 1px solid #e8eaec;
  }

  .ivu-page-header-title {
    display: inline-block;
    color: #17233d;
    font-weight: 500;
    font-size: 20px;
  }

  // 修改drawer层级 避免固定nav时遮挡
  .ivu-drawer-mask,
  .ivu-drawer-wrap {
    z-index: 1002;
  }

  .ivu-drawer-wrap-1 {
    z-index: 1003;
  }

  .ivu-drawer-wrap-2 {
    z-index: 1004;
  }

  // 修改Message层级
  .ivu-message {
    z-index: 2000 !important;
  }

  // 修改Menu层级
  .ivu-menu {
    z-index: 0;
  }

  // 暗黑
  .darkMode {
    filter: invert(1) hue-rotate(180deg);
    transition: all 300ms;

    img,
    video {
      filter: invert(1) hue-rotate(180deg);
    }
  }

  // 色弱
  .weakMode {
    touch-action: none;
    filter: invert(80%);
  }
</style>
<style scoped>
  .layout {
    border: 1px solid #d7dde4;
    background: #f5f7f9;
    position: relative;
    border-radius: 4px;
    overflow: hidden;
  }

  .layout-logo {
    width: 100px;
    height: 30px;
    background: #5b6270;
    border-radius: 3px;
    float: left;
    position: relative;
    top: 15px;
    left: 20px;
  }

  .layout-nav {
    width: 420px;
    margin: 0 auto;
    margin-right: 20px;
  }

  .content {
    text-align: left;
    min-height: 650px;
  }
</style>