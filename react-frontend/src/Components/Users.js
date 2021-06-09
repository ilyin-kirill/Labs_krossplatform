import { Router, Route } from "react-router-dom";
import React,{Component,useState} from 'react';
import {Table, Button, ButtonToolbar, Container, Form, Badge, Alert, Row, Col, Card, CardDeck,Nav} from "react-bootstrap"

export class Users extends Component{
    constructor(props){
        super(props);
        this.state={currentid:'',name:'',login:'', password:'', role:'', rating:'',deps:[], showing:true, checked:true}
        this.onChangeLogin = this.onChangeLogin.bind(this);
        this.onChangeName = this.onChangeName.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);
        this.onChangeRole = this.onChangeRole.bind(this);
        this.onChangeRating = this.onChangeRating.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onChangePassword(event){
        this.setState({password: event.target.value});
      }
  
    onChangeLogin(event) {
        this.setState({login: event.target.value});
      }
      onChangeRole(event){
        this.setState({role: event.target.value});
      }
  
      onChangeRating(event) {
        this.setState({rating: event.target.value});
      }
    
      onChangeName(event) {
        this.setState({name: event.target.value});
      }

      onSubmit(){
        fetch(process.env.REACT_APP_API+'Users/' + this.state.currentid,{
            method: 'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                "id": this.state.currentid,
                "name": this.state.name,
                "login": this.state.login,
                "password": this.state.password,
                "role": this.state.role,
                "rating": this.state.rating,
                "rides": []
            })
            
        })
        this.state={currentid:'',name:'',login:'', password:'', role:'', rating:''}
        return(
            <Alert variant="success">
                Пользователь успешно отредактирован!
            </Alert>
        )
        }

    deleteuser(id){
        fetch(process.env.REACT_APP_API+'Users/'+id,{
            method: 'DELETE',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        })
            .then(this.refreshList())
    }
        
    
    refreshList(){
        fetch(process.env.REACT_APP_API+'Users/') 
        .then(response=>response.json())
        .then(data=>{
            this.setState({deps:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        this.refreshList();
    }

    onClickEdit(dep){
        this.state.currentid = dep.id;
        this.state.name = dep.name;
        this.state.login = dep.login;
        this.state.password = dep.password;
        this.state.role = dep.role;
        this.state.rating = dep.rating;
    }

    render(){
        const {deps}=this.state;
        const {showing}=this.state;
        const {checked}=this.state;
        return(
            <div>
                <Container>
                    <h1 align="center">Список пользователей  <Button onClick={() => this.setState({ showing: !showing })} variant="outline-dark">
                        Поменять стиль отображения
                    </Button>
                    </h1>
                    {deps.map(dep=>
                    <>
                    <Card style={{ display: (showing ? 'none' : 'block'), width:'20rem'}} className="text-center" border="warning">
                    <Card.Header>Имя: {dep.name}</Card.Header>
                    <Card.Body>
                        <Card.Title>Логин: {dep.login}</Card.Title>
                        <Card.Text>
                        Пароль: {dep.password}<br/>
                        Роль: {dep.role}<br/>
                        Рейтинг: {dep.rating}<br/>
                        </Card.Text>
                        <Button onClick={() => {this.deleteuser(dep.id) }} variant="danger"> Delete</Button>
                        <Button onClick={() => {this.onClickEdit(dep)}}> Edit </Button>
                    </Card.Body>
                    </Card><br/>
                    </>)}
                    
                <Table className="mt-4" striped bordered hover size="sm" style={{ display: (showing ? 'table' : 'none') }} className="text-center">
                    <thead>
                        <tr>
                        <th>id</th>
                        <th>Имя</th>
                        <th>Логин</th>
                        <th>Пароль</th>
                        <th>Роль</th>
                        <th>Рейтинг</th>
                        <th>Удалить</th>
                        <th>Редактировать</th>
                        </tr>
                        
                    </thead>
                    <tbody>
                        {deps.map(dep=>
                            <tr key={dep.id}>
                                <td>{dep.id}</td>
                                <td>{dep.name}</td>
                                <td>{dep.login}</td>
                                <td>{dep.password}</td>
                                <td>{dep.role}</td>
                                <td>{dep.rating}</td>
                                <td> <Button onClick={() => {this.deleteuser(dep.id) }} variant="danger"> Delete</Button>
                                </td>
                                <td> 
                                <Button onClick={() => {this.onClickEdit(dep)}}> Edit </Button>
                                </td>
                            </tr>)}
                    </tbody>
                
                </Table>
                </Container> 
                <br/>
                        <Container>
                        <Card style={{ width: '100%' }}>
                        <Card.Body>
                        <Card.Title>Редактирование пользователя</Card.Title>
                        <Form onSubmit={this.onSubmit}>
                        <Row>
                        <Col>
                        <p><Form.Label> Имя: <Form.Control type="text" name="name" value={this.state.name}
                           onChange={this.onChangeName}/></Form.Label></p></Col>
                           <Col>
                    <p><Form.Label> Логин: <Form.Control type="text" name="login" value={this.state.login}
                           onChange={this.onChangeLogin}/></Form.Label></p></Col>
                           <Col>
                    <p><Form.Label> Пароль: <Form.Control type="password" name="password" value={this.state.password}
                            onChange={this.onChangePassword}/></Form.Label></p></Col>
                    <Col>
                    <p><Form.Label> Роль: <Form.Control type="text" name="role" value={this.state.role}
                           onChange={this.onChangeRole}/></Form.Label></p></Col>
                           <Col>
                    <p><Form.Label> Рейтинг: <Form.Control type="text" name="rating" value={this.state.rating}
                           onChange={this.onChangeRating}/></Form.Label></p></Col>
                           <Col>
                    <p><br/><Button type="submit" value="Submit" variant="success">Сохранить</Button></p></Col>
                    </Row>
                    </Form>
                    </Card.Body>
                    </Card>
                    </Container> 
            </div>
            
        )
    }
}