<template>
  <div id="app">
    <Menu></Menu>
    <Header></Header>
    <Content></Content>
  </div>
</template>

<script>
import Header from "./components/layout/TheHeader.vue";
import Menu from "./components/layout/TheMenu.vue";
import Content from "./components/layout/TheContent.vue";
export default {
  name: "App",
  components: {
    Header,
    Menu,
    Content,
  },
};
</script>

<style>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
  }
  
  body {
    font-family: "notosans-regular";
    font-size: 13px;
    background: #f4f5f8;
    color: #111;
    overflow: hidden;
  }
  
  ::-webkit-scrollbar-track {
    background: #fff;
  }
  
  ::-webkit-scrollbar-thumb {
    background: #888;
  }
  
  ::-webkit-scrollbar-thumb:hover {
    background: #555;
  }
  
  ::-webkit-scrollbar {
    height: 4px;
    width: 4px;
    border: 1px solid #888;
  }
  
  @font-face {
    font-family: "notosans-regular";
    src: url("./assets/fonts/notosans-regular.2cb88a13.woff2");
  }
  
  @font-face {
    font-family: "notosans-bold";
    src: url("./assets/fonts/notosans-bold.3ede5aff.woff2");
  }
  
  @font-face {
    font-family: "notosans-italic";
    src: url("./assets/fonts/notosans-italic.1c1aaac9.woff2");
  }
  
  @font-face {
    font-family: "notosans-semibold";
    src: url("./assets/fonts/notosans-semibold.df3e6dc4.woff2");
  }
</style>
