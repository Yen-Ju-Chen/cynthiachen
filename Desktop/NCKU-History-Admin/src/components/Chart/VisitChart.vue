<template>
  <div class="visit">
    <Card>
      <p slot="title" class="card-title">
        <Icon type="md-map" style="margin-right: 5px"></Icon>每日來訪量統計
      </p>
      <div slot="extra">
        <DatePicker type="daterange" placeholder="選擇日期範圍" style="width: 250px"></DatePicker>
      </div>
      <div>
        <apexchart type="bar" height="350" :options="chartOptions" :series="series"></apexchart>

      </div>
    </Card>
  </div>
</template>

<script>
  var zh = require("../../libs/zh.json");
  export default {
    name: "visitVolume",
    data() {
      return {

        series: [{
          name: '來訪量',
          data: [44, 55, 41, 67, 22, 43]
        }, ],
        chartOptions: {
          chart: {
            type: 'bar',
            height: 350,
            stacked: true,
            toolbar: {
              show: true
            },
            zoom: {
              enabled: true
            }
          },
          responsive: [{
            breakpoint: 480,
            options: {
              legend: {
                position: 'bottom',
                offsetX: -10,
                offsetY: 0
              }
            }
          }],
          plotOptions: {
            bar: {
              horizontal: false,
              borderRadius: 10
            },
          },
          xaxis: {
            type: 'datetime',
            categories: ['01/01/2011 GMT', '01/02/2011 GMT', '01/03/2011 GMT', '01/04/2011 GMT',
              '01/05/2011 GMT', '01/06/2011 GMT'
            ],
          },
          legend: {
            position: 'right',
            offsetY: 40
          },
          fill: {
            opacity: 1
          }
        },
      };
    },
    methods: {

    },
    created() {},
  };
</script>
<style lang="less">
  .visit {
    .ivu-card-head {
      border-bottom: none !important;
    }
  }
</style>