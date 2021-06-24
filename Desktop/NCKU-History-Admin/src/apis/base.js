import axios from 'axios';
import store from '../store/index'
import router from '../router'
import Cookies from 'js-cookie'

import {
  Spin,
  Notice
} from 'view-design';

//  設定參數路徑
const baseRequest = axios.create({
  baseURL: (process.env.NODE_ENV !== 'production') ? '' : './'
});


// 發出請求前動作
axios.interceptors.request.use(
  config => {
    Spin.show()
    if (Cookies.getJSON('auth')) {
      config.headers.common['Authorization'] = 'Bearer ' + Cookies.getJSON('auth').jwtToken
    }
    return config
  },
  function (error) {
    return Promise.reject(error)
  })

// 異常處理
axios.interceptors.response.use(
  response => {
    Spin.hide()
    return response;
  },
  err => {
    Spin.hide()
    // Cookies.remove('auth')
    if (err && err.response) {
      switch (err.response.status) {
        case 401:
          Notice.error({
            title: '通知',
            desc: '登入過期，請重新登入'
          });
          store.dispatch('Setlogout')
          router.push('/login')
          break;
        case 404:
          Notice.error({
            title: '通知',
            desc: '找不到該頁面'
          });
          break;
        case 500:
          Notice.error({
            title: '通知',
            desc: '伺服器出錯'
          });
          break;
        case 503:
          Notice.error({
            title: '通知',
            desc: '服務失效'
          });
          break;
        default:
          console.log(`連接錯誤${err.response.status}`);
      }
    } else {
      alert("連接到服務器失敗");
    }
    return Promise.resolve(err.response);
  }
)

export default axios