import React from 'react';
import {  Icon, Row, Col, Form, Input, Modal, Checkbox} from 'antd';
import { withRouter } from "react-router-dom";
import api from '../../../../services/api';

const FormItem = Form.Item;

class EditForm extends React.Component {

    state = {
       
        confirmLoading: false,
        visible: true,
        checked: true,
      };


    handleSave = (e) => {
        e.preventDefault();
        this.props.form.validateFields((err, values) => {
          if (!err) {
            this.handleClick(); 
          }
        });
    }
    
    onChange = (e) => {
        console.log('checked = ', e.target.checked);
        this.setState({
          checked: e.target.checked,
        });
    }

    async handleClick () {
        this.setState({
            confirmLoading: true,
        });

        let response = await api.post('/Bet', {
            stake: this.props.form.getFieldValue("stake"),
            odd: this.props.form.getFieldValue("odd"),
            green: this.props.form.getFieldValue("green"),

        })

        if(response.data){

            this.setState({
                confirmLoading: false,
                visible: false
            });
            this.props.refresh();
        }else{
            this.setState({
                confirmLoading: false,
                visible: false
            });
            this.props.refresh();
        }
    }

    handleCancel = () => {
        console.log('Clicked cancel button');
        this.setState({
          visible: false,
        });
    };


    render() {
        const { getFieldDecorator } = this.props.form;
        const { confirmLoading, visible } = this.state;
        return(

            <Modal
              title="Apostas"
              visible={visible}
              width="80%"
              onOk={this.handleSave}
              confirmLoading={confirmLoading}
              onCancel={this.handleCancel}
            >
                <Form onSubmit={this.handleSubmit} className="form-v1">
                    <Row>
                        <Col> 
                            <FormItem>
                                {getFieldDecorator('stake', {
                                rules: [{ required: true, message: 'Por favor, insira um Nome!'}],
                                })(
                                <Input size="large" placeholder="stake" />
                                )}
                            </FormItem>
                        </Col>
                        <Col> 
                            <FormItem>
                                {getFieldDecorator('odd', {
                                rules: [{ required: true, message: 'Por favor, insira um Nome!'}],
                                })(
                                <Input size="large"  placeholder="ODD" />
                                )}
                            </FormItem>
                        </Col>
                        
                    </Row>
                    <Row>
                        <Col> 
                            <FormItem>
                                {getFieldDecorator('green')(
                                    <Checkbox>
                                        {"Green"}
                                  </Checkbox>
                                )}
                            </FormItem>
                        </Col>
                      
                    </Row>
                  
                </Form>
            </Modal>
        )
    }

}

const WrappedEditForm = Form.create()(withRouter(EditForm));

export default WrappedEditForm;