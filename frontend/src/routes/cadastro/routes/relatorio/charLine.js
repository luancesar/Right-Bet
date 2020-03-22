import React from 'react';
import ReactEcharts from 'echarts-for-react';
import 'echarts/theme/macarons';
import CHARTCONFIG from 'constants/chartConfig';
import api from '../../../../services/api';
import moment from 'moment';
import { DatePicker, Icon } from 'antd';

class Chart extends React.Component {
  static defaultProps = {
    titulo: "Lista"
  };

  state = {
    visible: false,
    confirmLoading: false,
  };

  componentDidMount() {
    this.refresh()
  }

  refresh() {
    this.obterApostas()
  }

  async obterApostas() {
    let response = await api.get(`/Chart/chartPercentage`)

    this.setState({
      data: response.data
    })

    this.gerarGrafico();
  }

  gerarGrafico() {

    let { data } = this.state;

    let datas = [];

    let faturamentos = []

    data && data.bets.map((m) => {
      faturamentos.push({
        value: m.faturamento,
        itemStyle: {
          color: m.green ? 'green' : 'red'
        }
      })
    })

    // data && data.dates.map((m) => datas.push(moment(m).locale('pt-Br').format('DD/MM')))

    let option =
    {
      tooltip: {
        trigger: 'axis'
      },
      legend: {
        data: ['Porcentagem de Faturamento'],
      },
      toolbox: {
        show: true,
        feature: {
          saveAsImage: { show: true, title: 'save' }
        }
      },
      xAxis: [
        {
          type: 'category',
          boundaryGap: false,
          data: data && data.odds,
        }
      ],
      yAxis: [
        {
          type: 'value',
          axisLabel: {
            formatter: '{value} %',
          }
        }
      ],
      series: [
        {
          name: 'Lucro ( % ) ',
          type: 'line',
          data: faturamentos,
          symbolSize: 10,
          markPoint: {
            data: [
              { symbol: 'circle', name: 'teste' }
            ]
          },
          markLine: {
            data: [
              { type: 'average', name: 'Average' }
            ]
          }
        }

      ]
    }
    this.setState({
      option: option
    })

  }


  render() {
    let { option } = this.state;
    return (
      <div className="box box-default mb-4">
        <div style={{color: "#182795", fontFamily:"Segoe UI", fontSize:"30px"}} className="box-header">Lucro</div>
        <div className="box-body">
          {
            option && <ReactEcharts option={option} theme={"macarons"} />

          }
        </div>
      </div>
    )
  }

}

export default Chart;