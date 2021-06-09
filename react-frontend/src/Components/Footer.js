import React from 'react'
import {Navbar, Container} from 'react-bootstrap'

const Footer = () => {
    return(
    <Navbar expand="lg" variant="light" bg="light" fixed="bottom">
    <Container>
        <Container style={{display:'flex', justifyContent:'center'}}>
            Яндекс-Такси 2021
        </Container>
    </Container>
    </Navbar>
    )
}
export default Footer;