<style lang="less">
  @import "@/styles/single-common.less";
</style>
<style scoped>
  .wd400 {
    width: 400px;
  }
</style>
<template>
  <div>
    <Card>
      <div slot="title">
        <div class="edit-head">
          <a @click="close" class="back-title">
            <Icon type="ios-arrow-back" />返回
          </a>
          <div class="head-name" v-if="type==='add'">新增</div>
          <div class="head-name" v-if="type==='edit'">编辑</div>
          <span></span>
          <a @click="close" class="window-close">
            <Icon type="ios-close" size="31" class="ivu-icon-ios-close" />
          </a>
        </div>
      </div>
      <Form ref="form" :model="form" :label-width="120" :rules="formValidate" style="position:relative">
        <FormItem label="資料識別碼" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="類表代碼" prop="name" class="wd400">
          <Select>
            <Option></Option>
          </Select>
        </FormItem>
         <FormItem label="文物代碼" prop="name" class="wd400">
          <Select>
            <Option></Option>
          </Select>
        </FormItem>
        <FormItem label="資料類型" prop="name" class="wd400">
          <Select>
            <Option></Option>
          </Select>
        </FormItem>
        <FormItem label="登錄號	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="中文名稱" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="原始題名" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="外文名稱	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="創作者製造者	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="來源	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="校區	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="出產地製造地	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="關鍵字	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="標題\摘要	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="內容描述	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="年代	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="景物	" >
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="人物	" >
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="主要材質	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="尺寸	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="重量	" >
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="直徑	" >
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="參考資料	" >
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="經度座標	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem label="緯度座標	" prop="name">
          <Input v-model="form.name" class="wd400" />
        </FormItem>
        <FormItem class="br">
          <Button @click="handleSubmit" :loading="submitLoading" type="primary">送出並保存</Button>
          <Button @click="handleReset">重置</Button>
          <Button type="dashed" @click="close">關閉</Button>
        </FormItem>
        <Spin size="large" fix v-if="loading"></Spin>
      </Form>
    </Card>
  </div>
</template>

<script>
  export default {
    name: "CollectionEdit",
    props: {
      type: String,
      data: Object
    },
    data() {
      return {
        loading: false, // 表单加载状态
        submitLoading: false, // 表单提交状态
        form: {
          id: "",
          name: ""
        },
        // 表单验证规则
        formValidate: {
          name: [{
            required: true,
            message: "不能为空",
            trigger: "change"
          }]
        }
      };
    },
    methods: {
      init() {
        this.handleReset();
        this.form = this.data;
      },
      handleReset() {
        this.$refs.form.resetFields();
      },
      handleSubmit() {
        this.$refs.form.validate(valid => {
          if (valid) {
            // this.postRequest("请求路径", this.form).then(res => {
            //   this.submitLoading = false;
            //   if (res.success) {
            //     this.$Message.success("编辑成功");
            //     this.submited();
            //   }
            // });
            // 模拟成功
            this.submitLoading = false;
            this.$Message.success("编辑成功");
            this.submited();
          }
        });
      },
      close() {
        this.$emit("close", true);
      },
      submited() {
        this.$emit("submited", true);
      }
    },
    mounted() {
      this.init();
    }
  };
</script>