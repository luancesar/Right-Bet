import React from 'react';
import { connect } from 'react-redux';
import { changeLayout } from 'actions/settingsActions';
import List from '../../../../components/List';
import DEMO from 'constants/demoData';
import EditForm from './edit';
import api from '../../../../services/api';

const columns = [
  {
    title: 'Nome',
    dataIndex: 'nome',
    key: 'nome'
  },{
    title: 'Email ',
    dataIndex: 'email',
    key: 'email',
  }, {
    title: 'Banca Inicial ',
    dataIndex: 'bancaInicial',
    key: 'bancaInicial',
  },

];


class Page extends React.Component {

  normalScreen() {
    const { handleLayoutChange } = this.props;
    handleLayoutChange("1");
  }
  render() {
    return (
      <div>
        {this.normalScreen()}
        <List
          editComponent={EditForm}
          url="/Usuario"
          titulo="Usuários"
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
