import React from 'react';
import { connect } from 'react-redux';
import classnames from 'classnames';
import DEMO from 'constants/demoData';
import { Layout, Menu, Dropdown, Icon, Avatar, Badge, Tooltip, Popover, Divider } from 'antd';
import Logo from 'components/Logo';
import { toggleCollapsedNav, toggleOffCanvasMobileNav } from 'actions/settingsActions';
const { Header } = Layout;

const avatarDropdown = (
  <Menu className="app-header-dropdown">
    <Menu.Item key="4" className="d-block d-md-none"> Signed in as <strong>{DEMO.user}</strong> </Menu.Item>
    <Menu.Divider className="d-block d-md-none" />
    <Menu.Item key="1" disabled> <Icon type="setting" />Settings </Menu.Item>
    <Menu.Item key="0"> <a href={DEMO.headerLink.about}><Icon type="info-circle-o" />About</a> </Menu.Item>
    <Menu.Item key="2"> <a href={DEMO.headerLink.help}><Icon type="question-circle-o" />Need Help?</a> </Menu.Item>
    <Menu.Divider />
    <Menu.Item key="3"> <a href={DEMO.headerLink.signOut}><Icon type="logout" />Sign out</a> </Menu.Item>
  </Menu>
);

class AppHeader extends React.Component {

  onToggleCollapsedNav = () => {
    const { handleToggleCollapsedNav, collapsedNav } = this.props;
    handleToggleCollapsedNav(!collapsedNav);
  }

  onToggleOffCanvasMobileNav = () => {
    const { handleToggleOffCanvasMobileNav, offCanvasMobileNav } = this.props;
    handleToggleOffCanvasMobileNav(!offCanvasMobileNav);
  }

  render() {
    const { collapsedNav, offCanvasMobileNav, colorOption, showLogo } = this.props;

    return (
      <Header className="app-header">
        <div
          className={classnames('app-header-inner', {
            'bg-white': ['11', '12', '13', '14', '15', '16', '21'].indexOf(colorOption) >= 0,
            'bg-dark': colorOption === '31',
            'bg-primary': ['22', '32'].indexOf(colorOption) >= 0,
            'bg-success': ['23', '33'].indexOf(colorOption) >= 0,
            'bg-info': ['24', '34'].indexOf(colorOption) >= 0,
            'bg-warning': ['25', '35'].indexOf(colorOption) >= 0,
            'bg-danger': ['26', '36'].indexOf(colorOption) >= 0
          })}
        >
          <div className="header-left">
            <div className="list-unstyled list-inline">
              {showLogo && [
                <Logo key="logo" />,
                <Divider type="vertical" key="line" />,
              ]}
            </div>
          </div>
        </div>
      </Header>
    );
  }
}

const mapStateToProps = (state) => ({
  offCanvasMobileNav: state.settings.offCanvasMobileNav,
  collapsedNav: state.settings.collapsedNav,
  colorOption: state.settings.colorOption,
});

const mapDispatchToProps = dispatch => ({
  handleToggleCollapsedNav: (isCollapsedNav) => {
    dispatch(toggleCollapsedNav(isCollapsedNav));
  },
  handleToggleOffCanvasMobileNav: (isOffCanvasMobileNav) => {
    dispatch(toggleOffCanvasMobileNav(isOffCanvasMobileNav));
  }
});

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(AppHeader);
