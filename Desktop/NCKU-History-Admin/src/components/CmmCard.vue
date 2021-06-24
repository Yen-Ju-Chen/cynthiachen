<template>
  <Card :padding="0" :bordered="bordered" :style="{ backgroundColor: backgroundColor }">
    <div class="card-content card1" :style="{ backgroundImage: backgroundImage }">
      <div class="card-body">
        <Icon :type="icon" :color="iconColor" :size="iconSize" v-if="icon"></Icon>
        <img :src="image" :width="width" :height="height" v-else />
        <div>
          <div class="card-title" :style="{
              color: titleColor,
              fontSize: titleSize,
              fontWeight: titleWeight,
            }">{{title}}</div>

          <div class="card-description" :style="{
              color: descriptionColor,
              fontSize: descriptionSize,
              fontWeight: descriptionWeight,
            }">{{ description }}
            </div>
        </div>
      </div>
    </div>
  </Card>
</template>

<script>
  export default {
    name: "card1",
    components: {},
    props: {
      idName: String,
      backgroundColor: String,
      backgroundImage: String,
      bordered: {
        type: Boolean,
        default: true,
      },
      icon: String,
      iconSize: {
        type: [Number, String],
        default: 26,
      },
      iconColor: {
        type: String,
        default: "#2d8cf0",
      },
      image: String,
      width: {
        type: String,
        default: "26px",
      },
      height: {
        type: String,
        default: "26px",
      },
      title:String,
      titleColor: {
        type: String,
        default: "#fff",
      },
      titleSize: {
        type: String,
        default: "18px",
      },
      titleWeight: {
        type: Number,
        default: 500,
      },
      countSize: {
        type: String,
        default: "24px",
      },
      countWeight: {
        type: Number,
        default: 600,
      },
      description: String,
      descriptionColor: {
        type: String,
        default: "#b5b5c5",
      },
      descriptionSize: {
        type: String,
        default: "12px",
      },
      descriptionWeight: {
        type: Number,
        default: 500,
      },
    },
  };
</script>
<style lang="less" scoped>
  .card-content {
    height: 150px;
    padding: 24px 28px;
  }

  .card1 {
    background-position: right top;
    background-size: 30% auto;
    background-repeat: no-repeat;

    .card-body {
      display: flex;
      flex-direction: column;
      height: 102px;
      justify-content: space-around;
      align-items: flex-start;



      .card-data {
        display: flex;
        align-items: flex-end;

        .card-description {
          margin: 0 0 5px 5px;
        }
      }
    }
  }
</style>