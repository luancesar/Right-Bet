import React from 'react';
import Table from '../Table';

class List extends React.Component {
    render() {
        return (
            <div>
                <Table {...this.props} />
            </div>
        )
    }
}

export default List;