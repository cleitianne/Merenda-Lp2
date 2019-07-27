// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'core-js/es6/promise'
import 'core-js/es6/string'
import 'core-js/es7/array'
// import cssVars from 'css-vars-ponyfill'
import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App'
import router from './router'
import 'toastr/build/toastr.css';
import money from 'v-money'
import firebase from "firebase";
let app = '';
//aaaaaaa
var config = {
  apiKey: "AIzaSyAxfhBKpjek1GRMiK561sQJ-izjVGRWYUw",
  authDomain: "merendaifce.firebaseapp.com",
  databaseURL: "https://merendaifce.firebaseio.com",
  projectId: "merendaifce",
  storageBucket: "",
  messagingSenderId: "910404201704",
  appId: "1:910404201704:web:aaa394e9282383bb"
};
// Initialize Firebase
if (!firebase.apps.length) {
  firebase.initializeApp(config);
}

//aaaaaaa
// todo
// cssVars()

Vue.use(BootstrapVue)
Vue.use(money, {precision: 4})

firebase.auth().onAuthStateChanged(() => {
  if(!app) {
    app = new Vue({
      el: '#app',
      router,
      template: '<App/>',
      components: {
        App
      }
    })
  }
})
/* eslint-disable no-new */

