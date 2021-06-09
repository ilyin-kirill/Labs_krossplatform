import React, { useState } from 'react'
import Logo from './logo.svg'
import {ReactSVG} from 'react-svg'
import {Navbar, Nav, Button, Form, FormControl, Container, Modal, Dropdown} from 'react-bootstrap'
import Login from './Login';
import {Link } from "react-router-dom";

 
function Navibar(){

    const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

    return(
<>

<Navbar className="bg-light justify-content-between">
<Container>
<Navbar.Brand href="/"><ReactSVG src={Logo} /></Navbar.Brand>
<Container>
  <Navbar.Brand href="/">Яндекс-Такси</Navbar.Brand>
  </Container>
  <Navbar.Toggle aria-controls="basic-navbar-nav" />
  <Navbar.Collapse id="basic-navbar-nav">
    <Nav className="mr-auto">
      <Dropdown>
      <Dropdown.Toggle variant="success" id="dropdown-basic">
        Пользователи
      </Dropdown.Toggle>
      <Dropdown.Menu>
        <Dropdown.Item href="/users">Список пользователей</Dropdown.Item>
        <Dropdown.Item href="/adduser">Добавить пользователя</Dropdown.Item>
      </Dropdown.Menu>
      </Dropdown>
      <Nav.Link href="#">  </Nav.Link>
    </Nav>
    <Nav>
    <Link to="/rides"><Button variant="warning">Поездки</Button></Link>
    <Nav.Link href="#">  </Nav.Link>
    </Nav>
    <Nav>
    <Link to="/login"><Button variant="outline-success">Войти</Button></Link>
    </Nav>
  </Navbar.Collapse>
  </Container>
</Navbar>

</>
)}
export default Navibar