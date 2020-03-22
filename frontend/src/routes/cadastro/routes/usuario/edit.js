import React from 'react';
import {  Icon, Row, Col, Form, Input, Modal} from 'antd';
import { withRouter } from "react-router-dom";
import api from '../../../../services/api';

const FormItem = Form.Item;

class EditForm extends React.Component {

    state = {
       
        confirmLoading: false,
        visible: true
      };


    handleSave = (e) => {
        e.preventDefault();
        this.props.form.validateFields((err, values) => {
          if (!err) {
            this.handleClick(); 
          }
        });
    }
    

    async handleClick () {
        this.setState({
            confirmLoading: true,
        });

        let response = await api.post('/Usuario/registrar', {
                nome: this.props.form.getFieldValue("nome"),
                email: this.props.form.getFieldValue("email"),
                bancaInicial: this.props.form.getFieldValue("bancaInicial")

        })

        if(response.data){

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
              title="Colaborador"
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
                                {getFieldDecorator('nome', {
                                rules: [{ required: true, message: 'Por favor, insira um Nome!'}],
                                })(
                                <Input size="large" prefix={<Icon type="user" style={{ fontSize: 13 }} />} placeholder="Nome" />
                                )}
                            </FormItem>
                        </Col>
                        <Col> 
                            <FormItem>
                                {getFieldDecorator('email' )(
                                <Input type="email" size="large" prefix={<Icon type="email" style={{ fontSize: 13 }} />} placeholder="Email" />
                                )}
                            </FormItem>
                        </Col>
                    </Row>
                    <Row>
                        <Col span={11}>
                            <FormItem>
                                {getFieldDecorator('bancaInicial', {
                                rules: [{ required: true, message: 'Por favor, insira o valor da banca Inicial'}],
                                })(
                                <Input size="large" prefix={<Icon type="user" style={{ fontSize: 13 }} />} placeholder="Banca Inicial" />
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