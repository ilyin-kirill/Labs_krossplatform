import React,{Component,useState} from 'react';
import {Table, Button, ButtonToolbar, Container} from "react-bootstrap"

export class Rides extends Component{

    constructor(props){
        super(props);
        this.state={deps:[]}}

        refreshList(){
            fetch(process.env.REACT_APP_API+'Rides') 
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

        render(){
            const {deps}=this.state;
            return(
                <div>
                    <Container>
                    <h1 align="center">Список поездок</h1><br/>
                    <Table className="mt-4" striped bordered hover size="sm" className="text-center">
                        <thead>
                            <tr>
                            <th>id</th>
                            <th>Цена</th>
                            <th>Начало поездки</th>
                            <th>Окончание поездки</th>
                            <th>Адрес отправления</th>
                            <th>Адрес назначения</th>
                            <th>Userid</th>
                            
                            <th>DriverId</th>
                            
                            </tr>
                            
                        </thead>
                        <tbody>
                            {deps.map(dep=>
                                <tr key={dep.id}>
                                    <td>{dep.id}</td>
                                    <td>{dep.price}</td>
                                    <td>{dep.timeBegin}</td>
                                    <td>{dep.timeEnd}</td>
                                    <td>{dep.addressFrom}</td>
                                    <td>{dep.addressTo}</td>
                                    <td>{dep.userId}</td>
                                    
                                    <td>{dep.driverId}</td>
                                </tr>)}
                        </tbody>
                        </Table> 
                        <Button onClick={() => {window.location.assign('http://localhost:3000/');}}> Вернуться на главную </Button>
                        </Container>
                </div>
                
            )
        }


}