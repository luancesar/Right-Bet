import React from 'react';
import { Icon } from 'antd';
import imagem from './imagem'
import api from '../../../../services/api';

const style = { color: "#182795", fontFamily: "Segoe UI" }
const styleInfo = { color: "#black", fontFamily: "Segoe UI" }

class Cards extends React.Component {
  state = {
    visible: false,
    confirmLoading: false,
  };
  componentDidMount() {
    this.refresh()
  }

  refresh() {
    this.obterDados()
  }

  async obterDados() {
    let response = await api.get(`/usuario/report`)

    this.setState({
      data: response.data
    })

  }


  render() {

    let { data } = this.state;
    return (
      <div>
        <div className="mb-4">
          <div className="card">
            <div className="row">
              <div className="col-xl-4">
                <div className="card-left">
                  <img className="mb-1 mt-1 ml-1" src={imagem} />
                </div>
              </div>

              <div className="col-xl-8 mt-3" >
                <div className="card-right">
                  <span style={{ color: "#182795", fontSize: "70px", fontFamily: "Segoe UI" }} className="h25">Relatório Diário Galgos AvB</span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="mb-4">
          <div className="row">
            <div className="col-xl-3">
              <div className="number-card-v1">
                <div className="card-top mt-1">
                  <span style={style}><span className="h5">R$ </span>{data && data.bancaInicial}</span>
                </div>
                <div className="card-info">
                  <span style={style}>Banca Inicial <Icon type="arrow-up" /> <Icon type="pause" /> <Icon type="arrow-down" /> Banca Atual</span>
                </div>
                <div className="card-bottom mb-2">
                  <span style={style}><span className="h5">R$ </span>{data && data.bancaAtual}</span>
                </div>
              </div>
            </div>
            <div className="col-xl-3">
              <div className="number-card-v1">
                <div className="card-top mt-1">

                  <span style={{ color: "green", fontFamily: "Segoe UI" }}>{data && data.quantidadeGreen}</span>
                </div>
                <div className="card-info">
                  <span style={style}>Green <Icon type="arrow-up" /> <Icon type="pause" /> Entradas<Icon type="pause" /> <Icon type="arrow-down" /> Red</span>
                </div>
                <div className="card-bottom mb-2">
                  <span style={{ color: "red", fontFamily: "Segoe UI" }}>{data && data.quantidadeRed}</span>
                </div>
              </div>
            </div>
            <div className="col-xl-3">
              <div className="number-card-v1">
                <div className="card-top mt-1">
                  <span style={style}><span className="h5">R$ </span>{data && data.rentabilidadeReal}</span>
                </div>
                <div className="card-info">
                  <span style={style}>(R$) <Icon type="arrow-up" /> <Icon type="pause" /> Rentabilidade<Icon type="pause" /> <Icon type="arrow-down" /> (%)</span>
                </div>
                <div className="card-bottom mb-2">
                  <span style={style}>{data && data.rentabilidadePercentual}<span className="h5">%</span></span>
                </div>
              </div>
            </div>
            <div className="col-xl-3">
              <div className="number-card-v1">
                <div className="card-top mt-1">
                  <Icon type="rocket" theme="twoTone" twoToneColor="#182795" />
                </div>
                <div className="card-info">
                  <span style={style}>Parcial (Mês)</span>
                </div>
                <div className="card-bottom mb-2">
                  <span style={style}>{data && data.parcial}<span className="h5">%</span></span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div >
    )
  }
}

export default Cards;
