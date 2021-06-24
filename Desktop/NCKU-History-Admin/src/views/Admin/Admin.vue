<style lang="less">
  @import "@/styles/table-common.less";
</style>
<template>
  <div class="search">

    <!-- 新增/編輯 -->
    <AdminEdit v-if="currView == 'add'||currView == 'edit'" @close="currView = 'index'" @submited="submited"
      :type="currView" :data="formData" />

    <!-- 查詢 -->
    <Card v-show="currView == 'index'">
      <Row v-show="openSearch" @keydown.enter.native="handleSearch">
        <Form ref="searchForm" :model="searchForm" inline :label-width="70">
          <FormItem label="帳號" prop="nickname">
            <Input type="text" v-model="searchForm.nickname" clearable placeholder="請輸入帳號" style="width: 200px" />
          </FormItem>
          <FormItem label="狀態" prop="department">
            <Select style="width: 200px">
              <Option value="1">啟用</Option>
              <Option value="0">停用</Option>
            </Select>
          </FormItem>

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
        <Button @click="delAll" icon="md-trash">批量停用</Button>

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
  import AdminEdit from "./AdminEdit.vue";
  export default {
    name: "Admin",
    components: {
      AdminEdit,
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
            title: "項次",
            align: "center",
          },
          {
            title: "姓名",
            key: "name",
          },
          {
            title: "帳號",
            key: "name",
          },
          {
            title: "密碼",
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
                      text: "啟用",
                    },
                  }),
                ]);
              } else if (params.row.status == -1) {
                return h("div", [
                  h("Badge", {
                    props: {
                      status: "error",
                      text: "停用",
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
            title: "更新時間",
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
                  "停用"
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
                  "啟用"
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
                  "編輯"
                )
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
            name: "Admin",
            status: '0',
            createTime: "2018-08-08 00:08:00",
            updateTime: "2018-08-08 00:08:00",
          },
          {
            id: "2",
            name: "Test",
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