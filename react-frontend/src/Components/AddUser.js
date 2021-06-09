import React,{Component,Redirect} from "react"
import {Button, Container, Form, Alert, Card, Row, Col} from "react-bootstrap"

export class AddUser extends Component{

    constructor(props){
        super(props);
        this.state={name:'',login:'', password:'', role:'', rating:''}
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
        
        fetch(process.env.REACT_APP_API+'Users/',{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                "name": this.state.name,
                "login": this.state.login,
                "password": this.state.password,
                "role": this.state.role,
                "rating": this.state.rating,
                "rides": []
            })
            
        })
        
        
        }

        render(){
            return(
                    <div>
                        <br/>
                        <Container>
                        <Card style={{ width: '100%' }}>
                        <Card.Body>
                        <Card.Title>Добавление пользователя</Card.Title>
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
                    <Button onClick={() => {window.location.assign('http://localhost:3000/');}}> Вернуться назад </Button>
                    </Card.Body>
                    </Card>
                    </Container> 
                    </div>)}



}