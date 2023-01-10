import React from 'react'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCopy, faEdit, faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { Col, Container, Row } from 'react-bootstrap'
import { PaginationPanel } from '../../../components/PaginationPanel'
import { Link } from 'react-router-dom'

export const Game = () => {
    return (
        <div className='border p-2 mb-3 rounded cursor-pointer game'>
            <div className='d-flex justify-content-between align-items-end'>
                <h4 className='mb-2'>Start wars</h4>
                <div className='d-flex'>
                    <Button variant="outline-secondary" className="me-2"> <FontAwesomeIcon icon={faCopy} /> Clone</Button>
                    <Button variant="outline-success" className="me-2"> <FontAwesomeIcon icon={faEdit} /> Edit</Button>
                    <Button variant="outline-danger" className="me-2"> <FontAwesomeIcon icon={faTrashCan} /> Delete</Button>
                </div>
            </div>
            <hr className='mt-2' />
            <Container>
                <Row>
                    <Col>
                        <Link to="/cards" className='link'>
                            <div className="border rounded cursor-pointer p-2 m-1 bg-white game-card">
                                <h6>Cards</h6>
                                <hr className='my-1' />
                                <div className="font-monospace">Total: 12312</div>
                            </div>
                        </Link>
                    </Col>
                    <Col>
                        <Link to="/fields" className='link'>
                            <div className="border rounded cursor-pointer p-2 m-1 bg-white  game-card">
                                <h6>Fields</h6>
                                <hr className='my-1' />
                                <div className="font-monospace">Total: 12312</div>
                            </div>
                        </Link>
                    </Col>
                    <Col>
                        <Link to="/banknotes" className='link'>
                            <div className="border rounded cursor-pointer p-2 m-1 bg-white  game-card">
                                <h6>Banknotes</h6>
                                <hr className='my-1' />
                                <div className="font-monospace">Total: 12312</div>
                            </div>
                        </Link>
                    </Col>
                </Row>
            </Container>
        </div>
    )
}