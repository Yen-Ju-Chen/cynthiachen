<style lang="less">
  @import "@/styles/table-common.less";
</style>
<template>
  <div class="search">

    <!-- 新增/編輯 -->
    <CollectionEdit v-if="currView == 'add'||currView == 'edit'" @close="currView = 'index'" @submited="submited"
      :type="currView" :data="formData" />
    <!-- 圖檔資料上傳 -->
    <CollectionFileEdit></CollectionFileEdit>

    <!-- 查詢 -->
    <Card v-show="currView == 'index'">
      <Row v-show="openSearch" @keydown.enter.native="handleSearch">
        <Form ref="searchForm" :model="searchForm" inline :label-width="70">
          <FormItem label="用户名" prop="nickname">
            <Input type="text" v-model="searchForm.nickname" clearable placeholder="请输入用户名" style="width: 200px" />
          </FormItem>
          <FormItem label="部门" prop="department">
            <Select style="width: 200px">
              <Option>男</Option>
              <Option>女</Option>
            </Select>
          </FormItem>

          <FormItem label="手机号" prop="mobile">
            <Input type="text" v-model="searchForm.mobile" clearable placeholder="请输入手机号" style="width: 200px" />
          </FormItem>
          <FormItem label="邮箱" prop="email">
            <Input type="text" v-model="searchForm.email" clearable placeholder="请输入邮箱" style="width: 200px" />
          </FormItem>
          <span v-if="drop">
            <FormItem label="性别" prop="sex">
              <Select style="width: 200px">
                <Option>男</Option>
                <Option>女</Option>
              </Select>
            </FormItem>
            <FormItem label="登录账号" prop="username">
              <Input type="text" v-model="searchForm.username" clearable placeholder="请输入登录账号" style="width: 200px" />
            </FormItem>
            <FormItem label="用户ID" prop="id">
              <Input type="text" v-model="searchForm.id" clearable placeholder="请输入用户ID" style="width: 200px" />
            </FormItem>
          </span>
          <FormItem style="margin-left: -35px" class="br">
            <Button @click="handleSearch" type="primary" icon="ios-search">搜尋</Button>
            <Button @click="handleReset">重置</Button>
            <a class="drop-down" @click="dropDown">
              展开
              <Icon type="ios-arrow-down"></Icon>
            </a>
          </FormItem>
        </Form>
      </Row>
      <Row class="operation">
        <Button @click="add" type="primary" icon="md-add">新增</Button>
        <Button @click="delAll" icon="md-trash">批量删除</Button>
        <Button type="dashed" icon="md-cloud-upload">下載JSON</Button>
        <Button type="dashed" icon="md-cloud-upload">下載XLSX</Button>
        <Button type="dashed" icon="md-cloud-upload">下載CSV</Button>
        <!-- <Button @click="getDataList" icon="md-refresh">更新</Button>
        <Button type="dashed" @click="openTip = !openTip">{{
          openTip ? "關閉提示" : "開啟提示"
        }}</Button> -->
      </Row>
      <Alert show-icon v-show="openTip">
        已選擇
        <span class="select-count">{{ selectList.length }}</span> 项
        <a class="select-clear" @click="clearSelectAll">清空</a>
      </Alert>
      <Table :loading="loading" border :columns="columns" :data="data" ref="table" sortable="custom"
        @on-sort-change="changeSort" @on-selection-change="changeSelect"></Table>
      <Row type="flex" justify="end" class="page">
        <Page :current="searchForm.pageNumber" :total="total" :page-size="searchForm.pageSize" @on-change="changePage"
          @on-page-size-change="changePageSize" :page-size-opts="[10, 20, 50]" size="small" show-total show-elevator
          show-sizer></Page>
      </Row>
    </Card>
  </div>
</template>

<script>
  import CollectionEdit from "./CollectionEdit.vue";
  import CollectionFileEdit from "./CollectionFileEdit.vue";
  export default {
    name: "Collection",
    components: {
      CollectionEdit,
      CollectionFileEdit
    },
    data() {
      return {
        openSearch: true, // 顯示查詢視窗
        drop: false, // 搜尋視窗收合
        openTip: true, // 顯示提示
        formData: {},
        currView: "index",
        loading: true, // 表單加載狀態
        searchForm: {
          // 搜索框對應的資料
          id: "",
          nickname: "",
          username: "",
          departmentId: "",
          mobile: "",
          email: "",
          sex: "",
          type: "",
          status: "",
          pageNumber: 1, // 當前頁數
          pageSize: 10, // 每頁筆數
          sort: "createTime", // 默认排序字段
          order: "desc", // 默认排序方式
        },
        selectList: [], // 多選數據
        columns: [
          // 表投
          {
            type: "selection",
            width: 60,
            align: "center",
          },
          {
            type: "index",
            width: 60,
            align: "center",
          },
          {
            title: "資料類型",
            key: "name",
          },
          {
            title: "典藏號",
            key: "name",
          },
          {
            title: "典藏名稱",
            key: "name",
          },
          {
            title: "出版者/創作者",
            key: "name",
          },
          {
            title: "狀態",
            key: "status",
            render: (h, params) => {
              if (params.row.status == 0) {
                return h("div", [
                  h("Badge", {
                    props: {
                      status: "success",
                      text: "上架",
                    },
                  }),
                ]);
              } else if (params.row.status == -1) {
                return h("div", [
                  h("Badge", {
                    props: {
                      status: "error",
                      text: "下架",
                    },
                  }),
                ]);
              }
            }
          },
          {
            title: "建立時間",
            key: "createTime",
          },
          {
            title: "更新时间",
            key: "updateTime",
          },
          {
            title: "操作",
            key: "action",
            align: "center",
            width: 160,
            render: (h, params) => {
              let enableOrDisable = "";
              if (params.row.status == 0) {
                enableOrDisable = h(
                  "a", {
                    on: {
                      click: () => {
                        this.disable(params.row);
                      },
                    },
                  },
                  "下架"
                );
              } else {
                enableOrDisable = h(
                  "a", {
                    on: {
                      click: () => {
                        this.enable(params.row);
                      },
                    },
                  },
                  "上架"
                );
              }
              return h("div", [
                enableOrDisable,
                h("Divider", {
                  props: {
                    type: "vertical",
                  },
                }),
                h(
                  "a", {
                    on: {
                      click: () => {
                        this.edit(params.row);
                      },
                    },
                  },
                  "資料編輯"
                ),
                h("Divider", {
                  props: {
                    type: "vertical",
                  },
                }),
                h(
                  "a", {
                    on: {
                      click: () => {
                        this.edit(params.row);
                      },
                    },
                  },
                  "檔案編輯"
                ),
                h("Divider", {
                  props: {
                    type: "vertical",
                  },
                }),
                h(
                  "a", {
                    on: {
                      click: () => {
                        this.remove(params.row);
                      },
                    },
                  },
                  "删除"
                ),
              ]);
            },
          },
        ],
        data: [], // 表单数据
        total: 0, // 表单数据总数
      };
    },
    methods: {
      init() {
        this.getDataList();
      },
      submited() {
        this.currView = "index";
        this.getDataList();
      },
      changePage(v) {
        this.searchForm.pageNumber = v;
        this.getDataList();
        this.clearSelectAll();
      },
      changePageSize(v) {
        this.searchForm.pageSize = v;
        this.getDataList();
      },
      changeSort(e) {
        this.searchForm.sort = e.key;
        this.searchForm.order = e.order;
        if (e.order == "normal") {
          this.searchForm.order = "";
        }
        this.getDataList();
      },
      clearSelectAll() {
        this.$refs.table.selectAll(false);
      },
      changeSelect(e) {
        this.selectList = e;
      },
      handleSearch() {
        this.searchForm.pageNumber = 1;
        this.searchForm.pageSize = 10;
        this.getDataList();
      },
      handleReset() {
        this.$refs.searchForm.resetFields();
        this.searchForm.pageNumber = 1;
        this.searchForm.pageSize = 10;
        // 重新加载數據
        this.getDataList();
      },
      dropDown() {
        if (this.drop) {
          this.dropDownContent = "展开";
          this.dropDownIcon = "ios-arrow-down";
        } else {
          this.dropDownContent = "收起";
          this.dropDownIcon = "ios-arrow-up";
        }
        this.drop = !this.drop;
      },
      getDataList() {
        this.loading = true;
        // 请求后端获取表单数据 请自行修改接口
        // this.getRequest("请求路径", this.searchForm).then(res => {
        //   this.loading = false;
        //   if (res.success) {
        //     this.data = res.result.content;
        //     this.total = res.result.totalElements;
        //     if (this.data.length == 0 && this.searchForm.pageNumber > 1) {
        //       this.searchForm.pageNumber -= 1;
        //       this.getDataList();
        //     }
        //   }
        // });
        // 以下为模拟数据
        this.data = [{
            id: "1",
            name: "",
            status: '0',
            createTime: "2018-08-08 00:08:00",
            updateTime: "2018-08-08 00:08:00",
          },
          {
            id: "2",
            name: "",
            status: '-1',
            createTime: "2018-08-08 00:08:00",
            updateTime: "2018-08-08 00:08:00",
          },
        ];
        this.total = this.data.length;
        this.loading = false;
      },
      add() {
        this.currView = "add";
      },
      edit(v) {
        // 转换null为""
        for (let attr in v) {
          if (v[attr] == null) {
            v[attr] = "";
          }
        }
        let str = JSON.stringify(v);
        let data = JSON.parse(str);
        this.formData = data;
        this.currView = "edit";
      },
      remove(v) {
        this.$Modal.confirm({
          title: "確認删除",
          // 记得确认修改此处
          content: "您確認要删除 " + v.name + " ?",
          loading: true,
          onOk: () => {
            // 删除
            // this.deleteRequest("请求地址，如/deleteByIds/" + v.id).then(res => {
            //   this.$Modal.remove();
            //   if (res.success) {
            //     this.$Message.success("操作成功");
            //     this.clearSelectAll();
            //     this.getDataList();
            //   }
            // });
            // 模拟请求成功
            this.$Message.success("操作成功");
            this.clearSelectAll();
            this.$Modal.remove();
            this.getDataList();
          },
        });
      },
      delAll() {
        if (this.selectList.length <= 0) {
          this.$Message.warning("您还未选择要删除的数据");
          return;
        }
        this.$Modal.confirm({
          title: "确认删除",
          content: "您确认要删除所选的 " + this.selectList.length + " 条数据?",
          loading: true,
          onOk: () => {
            let ids = "";
            this.selectList.forEach(function (e) {
              ids += e.id + ",";
            });
            ids = ids.substring(0, ids.length - 1);
            // 批量删除
            // this.deleteRequest("请求地址，如/deleteByIds/" + ids).then(res => {
            //   this.$Modal.remove();
            //   if (res.success) {
            //     this.$Message.success("操作成功");
            //     this.clearSelectAll();
            //     this.getDataList();
            //   }
            // });
            // 模拟请求成功
            this.$Message.success("操作成功");
            this.$Modal.remove();
            this.clearSelectAll();
            this.getDataList();
          },
        });
      },
    },
    mounted() {
      this.init();
    },
  };
</script>