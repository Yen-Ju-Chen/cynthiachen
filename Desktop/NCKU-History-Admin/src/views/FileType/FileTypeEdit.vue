<style lang="less">
@import "@/styles/single-common.less";
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
      <Form
        ref="form"
        :model="form"
        :label-width="90"
        :rules="formValidate"
        style="position:relative"
      >
        <FormItem label="類表名稱" prop="name">
          <Input v-model="form.name" style="width: 400px" />
        </FormItem>
        <FormItem label="類表代碼" prop="name">
          <Input v-model="form.name" style="width: 400px" />
        </FormItem>
        <FormItem class="br">
          <Button
            @click="handleSubmit"
            :loading="submitLoading"
            type="primary"
          >送出並保存</Button>
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
  name: "FileTypeEdit",
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
        name: [{ required: true, message: "不能为空", trigger: "change" }]
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