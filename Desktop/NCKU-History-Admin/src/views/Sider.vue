<template>
    <Menu active-name="1-2" theme="light" width="auto" :open-names="['1']">
      <Submenu name="1">
        <template slot="title">
          <Icon type="ios-navigate"></Icon>
          頁面管理
        </template>
        <MenuItem name="1-1">藏品精選管理</MenuItem>
        <MenuItem name="1-2">上方Banner管理</MenuItem>
        <!-- <MenuItem name="1-3">Option 3</MenuItem> -->
      </Submenu>
      <Submenu name="2">
        <template slot="title">
          <Icon type="ios-keypad"></Icon>
          藏品管理
        </template>
        <MenuItem name="2-1" to="Collection">藏品管理</MenuItem>
        <MenuItem name="2-2">數位藏品下載</MenuItem>
        <MenuItem name="2-3" to="Category">類表選項管理</MenuItem>
        <MenuItem name="2-4" to="Culture">文物選項管理</MenuItem>
        <MenuItem name="2-4" to="FileType">資料類型管理</MenuItem>
        <MenuItem name="2-5">浮水印</MenuItem>
      </Submenu>
      <Submenu name="3">
        <template slot="title">
          <Icon type="ios-analytics"></Icon>
          系統管理
        </template>
        <MenuItem name="3-1" to="admin">使用者設定</MenuItem>
      </Submenu>
       <Submenu name="4">
        <template slot="title">
          <Icon type="ios-analytics"></Icon>
          統計報表
        </template>
        <MenuItem name="4-1">網站訪客數</MenuItem>
        <MenuItem name="4-2">檢索統計</MenuItem>
        <MenuItem name="4-3">數位藏品下載統計</MenuItem>
        <MenuItem name="4-4">藏品點閱統計</MenuItem>
        <MenuItem name="4-5">藏品數位資料統計</MenuItem>
      </Submenu>
      <Submenu name="5">
        <template slot="title">
          <Icon type="ios-navigate"></Icon>
          熱門資料
        </template>
        <MenuItem name="5-1">熱門點閱藏品</MenuItem>
        <MenuItem name="5-2">熱門檢所字詞</MenuItem>
        <!-- <MenuItem name="1-3">Option 3</MenuItem> -->
      </Submenu>
    </Menu>
</template>

<script>
  export default {

  }
</script>

<style>

</style>