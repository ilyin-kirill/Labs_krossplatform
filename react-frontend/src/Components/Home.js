import React from 'react'
import Map_view from './Map_view'
import {Button, Container} from 'react-bootstrap'

export const Home = () => {
    return(
        <>
        <Container>
        <Map_view />
        <div class="text-center" style={{paddingTop:"2rem"}}>
        <Button variant="warning" className="mr-2" size="lg">Заказать такси</Button>
        </div>
        </Container>
        </>
    )
}