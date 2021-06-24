module.exports = {
  lintOnSave: false,
  devServer: {
    port: 8080, // 端口号
    host: 'localhost',
    https: false, // https:{type:Boolean}
    open: true, // 配置自动启动浏览器
    proxy: 'http://localhost:45329' // 配置跨域处理,只有一个代理
    // proxy: {
    //   '/api': {
    //     target: '<url>',
    //     ws: true,
    //     changeOrigin: true
    //   }
    // } // 配置多个代理
  }
}
