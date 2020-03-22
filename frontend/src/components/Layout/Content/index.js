import React from 'react';
import { Route } from 'react-router-dom';
import { withRouter } from 'react-router'
import loadable from 'react-loadable';
import LoadingComponent from 'components/Loading';
import { Layout } from 'antd';
const { Content } = Layout;

let AsyncCadastro = loadable({
  loader: () => import('routes/cadastro/'),
  loading: LoadingComponent
})
let AsyncException = loadable({
  loader: () => import('routes/exception/'),
  loading: LoadingComponent
})



class AppContent extends React.Component {
  render() {
    const { match } = this.props;

    return (
      <Content id='app-content'>
        <Route path={`${match.url}/cadastro`} component={AsyncCadastro} />
        <Route path={`${match.url}/exception`} component={AsyncException} />
      </Content>
    );
  }
}

export default withRouter(AppContent);
