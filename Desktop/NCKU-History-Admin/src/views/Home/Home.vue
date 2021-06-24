<template>
  <div>
    <Row :gutter="10">
      <Col :sm="24" :lg="24" :xl="16" :style="{ marginBottom: '10px' }">
      <visit-volume />
      </Col>
      <Col :sm="24" :lg="24" :xl="8" :style="{ marginBottom: '10px' }">
      <!-- <visit-separation /> -->
      <Card>
        <p slot="title" class="card-title">
          <Icon type="md-map" style="margin-right: 5px"></Icon>熱門檢索
        </p>
        <div>
          <Table :columns="columns1" :data="data1"></Table>

        </div>
      </Card>
      </Col>
    </Row>
    <Row :gutter="10">
      <Col :sm="24" :md="12" :lg="6" :style="{ marginBottom: '10px' }">
      <cmmCard id-name="card6" :bordered="false" :end-val="68893" backgroundColor="#6993fe" title="sss" titleSize="25px"
        titleColor="#fff" icon="md-person-add" iconColor="#fff" descriptionColor="#fff" description="今日新增用户" />
      </Col>
    </Row>
  </div>
</template>

<script>
  import cmmCard from '../../components/CmmCard.vue'
  import visitVolume from "../../components/Chart/VisitChart.vue";

  export default {
    components: {
      cmmCard,
      visitVolume
    },
    data() {
      return {
        columns1: [{
            title: '排名',
            key: 'seq'
          },
          {
            title: '關鍵字',
            key: 'name'
          },
          {
            title: '次數',
            key: 'age'
          }
        ],
        data1: [{
            name: 'John Brown',
            age: 18,
            seq: '1',
            date: '2016-10-03'
          },
          {
            name: 'Jim Green',
            age: 24,
            seq: '2',
            date: '2016-10-01'
          },
          {
            name: 'Joe Black',
            age: 30,
            seq: '3',
            date: '2016-10-02'
          },
          {
            name: 'Jon Snow',
            age: 26,
            seq: '4',
            date: '2016-10-04'
          }
        ]
      }
    }
  }
</script>

<style>

</style>