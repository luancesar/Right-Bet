import React from 'react';
import { Table, Button, Row, Col } from 'antd';
import api from '../../services/api';




class Tabela extends React.Component {
  static defaultProps = {
    titulo: "Lista",
    columns: []
  };

  state = {
    visible: false,
    confirmLoading: false,
  };

  componentDidMount() {
    var teste = {
      title: 'Action',
      key: 'action',
      render: (text, record) => (
        <span>

          <span className="ant-divider" />
          <a onClick={this.Delete.bind(this, record)}>Delete</a>
          <span className="ant-divider" />

        </span>
      ),
    }

    var action = this.props.columns.find((c) => c.title == "Action");
    if (!action) {
      this.props.columns.push(teste)
    }

    this.refresh();
  }

  refresh() {
    this.setState({
      visible: false,
    });
    this.obterUsuarios();
  }

  async Delete(user) {
    var response = await api.post(`${this.props.url}/delete`, { id: user.id })
    if (response.data) {
      this.refresh()
    }

  }

  async obterUsuarios() {
    let response = await api.get(`${this.props.url}`)

    this.setState({
      data: response.data
    })
  }

  renderEdit = () => {
    this.setState({
      visible: true,
    });
  };

  render() {
    const { visible, confirmLoading, data} = this.state;
    return (
      <div className="container-fluid no-breadcrumb page-dashboard">
        <h3 className="article-title">{this.props.titulo}</h3>
        <Row>

          <Button onClick={this.renderEdit.bind(this)} type="primary" style={{ marginBottom: 16 ,marginRight: 8 }}>
            Add
            {visible && <this.props.editComponent refresh={this.refresh.bind(this)} />}
          </Button>
          {this.props.otherButton }
        </Row>
        <Table columns={this.props.columns} dataSource={data} className="ant-table-v1" />
      </div>
    )
  }
}

export default Tabela;