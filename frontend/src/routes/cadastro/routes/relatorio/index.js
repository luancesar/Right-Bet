import React from 'react';
import { connect } from 'react-redux';
import { changeLayout } from 'actions/settingsActions';
import List from '../../../../components/List';
import DEMO from 'constants/demoData';
import api from '../../../../services/api';
import ChartLine from './charLine';
import NumberCards from './numberCards';
import QueueAnim from 'rc-queue-anim';

class Page extends React.Component {


  fullScreen() {
    const { handleLayoutChange } = this.props;
    handleLayoutChange("4");
  }
  render() {
    return (
      <div className="container-fluid no-breadcrumb page-dashboard">
        {this.fullScreen()}
        <QueueAnim type="bottom" className="ui-animate">
          <NumberCards />
          <ChartLine />
        </QueueAnim>
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
