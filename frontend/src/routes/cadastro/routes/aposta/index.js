import React from 'react';
import List from '../../../../components/List';
import DEMO from 'constants/demoData';
import EditForm from './edit';
import api from '../../../../services/api';
import moment from 'moment';
import { DatePicker, Icon, Button } from 'antd';
import { connect } from 'react-redux';
import { changeLayout } from 'actions/settingsActions';

const columns = [
  {
    title: 'Data',
    render: (e) =>
      <span>{moment(e.date).locale('pt-Br').format('DD/MM')}</span>,
    key: 'date'
  }, {
    title: 'Stake',
    dataIndex: 'stake',
    key: 'stake',
  }, {
    title: 'ODD',
    dataIndex: 'odd',
    key: 'odd',
  }, {
    title: 'Green',
    render: (g) =>
      <span>{g.green == true ? <Icon type="smile" style={{ fontSize: '20px' }} theme="twoTone" twoToneColor="#52c41a" /> : <Icon type="frown" style={{ fontSize: '20px' }} theme="twoTone" twoToneColor="#FF0000" />}</span>,
    key: 'green',
  }, {
    title: 'Faturamento',
    dataIndex: 'lucro',
    key: 'lucro',
  }, {
    title: 'SaldoAtual',
    dataIndex: 'saldoAtual',
    key: 'saldoAtual',
  }, {
    title: '( % )',
    dataIndex: 'porcentagem',
    key: 'porcentagem',
  },

];

const DownloadFileUrl = (url, nomeArquivo) => {

  // Caso não passou nome do Arquivo, Tenta recuperar o nome do arquivo da URL
  if (!nomeArquivo) {
    nomeArquivo = "download";
    let index = url.indexOf("nomeArquivo=");
    if (index > -1) {
      nomeArquivo = url.substring(index + 12)
    }
  }

}
class Page extends React.Component {
  state = {
    loading: false
  }
  normalScreen() {
    const { handleLayoutChange } = this.props;
    handleLayoutChange("1");
  }



  async downloadReport() {

    this.setState({
      loading: true
    })
    let response = await api.post(`/bet/downloadReport`, { endereco: window.location.origin })


    this.setState({
      loading: false
    })
    window.location.href = 'data:application/octet-stream;base64,' + response.data;
  }


  render() {
    let button = <Button loading={this.state.loading} onClick={this, this.downloadReport.bind(this)} type="primary" style={{ marginBottom: 16 }}>
      Gerar Relatório
                </Button>
    return (
      <div>
        {this.normalScreen()}
        <List
          editComponent={EditForm}
          url="/Bet"
          titulo="Apostas"
          otherButton={button}
          columns={columns} />
      </div>
    );
  }
}
const mapDispatchToProps = dispatch => ({
  handleLayoutChange: (layoutOption) => {
    dispatch(changeLayout(layoutOption));
  }
});

export default connect(
  null,
  mapDispatchToProps
)(Page);
