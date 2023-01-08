import React from 'react'
import { Container } from 'react-bootstrap'
import Col from 'react-bootstrap/esm/Col'
import Row from 'react-bootstrap/esm/Row'
import { Navigation } from './Navigation'

interface CustomRouteProps {
    children: React.ReactNode
}

export const CustomRoute = (props: CustomRouteProps) => {

    return (
        <div className='d-flex flex-column'>
            <Navigation />
            <Container className='mt-3'>
                <Row className='justify-content-center'>
                    <Col lg="8">
                        {props.children}
                    </Col>
                </Row>
            </Container>
        </div>
    )
}