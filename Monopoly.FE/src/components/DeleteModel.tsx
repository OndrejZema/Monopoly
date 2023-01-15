import React from 'react'
import { Button, Modal } from 'react-bootstrap'

interface Props{
    onBtnDeleteClick: () => void
    title: string
    isShow: boolean
    onBtnCloseClick: () => void
}

export const DeleteModal = (props: Props) =>{
return (
    <Modal show={props.isShow}>
        <Modal.Header><h4>{props.title}</h4></Modal.Header>
        <Modal.Body className='d-flex justify-content-end'>
            <Button className='me-2' variant="outline-secondary" onClick={()=>{props.onBtnCloseClick()}}>Cancel</Button>
            <Button variant="outline-danger" onClick={()=>{props.onBtnDeleteClick(); props.onBtnCloseClick()}}>Delete</Button>
        </Modal.Body>

    </Modal>
)
}