import React from 'react'
import Navbar from 'react-bootstrap/Navbar'
import Container from 'react-bootstrap/Container'
import Nav from 'react-bootstrap/Nav'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faAddressCard, faCity, faDice, faHouseFlag } from '@fortawesome/free-solid-svg-icons'

export const Navigation = () => {
    return (<div>
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand><FontAwesomeIcon icon={faCity} /> Monopoly</Navbar.Brand>
                <Navbar.Toggle arial-controls="basic-navbar-nav" />
                <Navbar.Collapse>
                    <Nav defaultActiveKey={1}>
                        <Nav.Item>
                            <Nav.Link to="/" eventKey={1} as={Link}>
                                <FontAwesomeIcon icon={faDice} className="me-1" ></FontAwesomeIcon>
                                Games
                            </Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link to="/" eventKey={2} as={Link}>
                                <FontAwesomeIcon icon={faAddressCard} className="me-1" ></FontAwesomeIcon>
                                Card types
                            </Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link to="/" eventKey={3} as={Link}>
                                <FontAwesomeIcon icon={faHouseFlag} className="me-1" ></FontAwesomeIcon>
                                Field types
                            </Nav.Link>
                        </Nav.Item>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    </div>)
}