import React from 'react'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheck, faCopy, faEdit, faPersonDigging, faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { Col, Container, Row } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import { IGamePreview } from '../../../types/ViewModels'
import { GlobalContext } from '../../../store/GlobalContextProvider'
import { setGame } from '../../../store/actions/GameActions'
import { createNotification } from '../../../store/actions/NotificationsActions'
import { DeleteModal } from '../../../components/DeleteModel'

interface Props {
    game: IGamePreview
    reload: ()=>void
}

export const Game = (props: Props) => {

    const { gameDispatch, notificationsDispatch } = React.useContext(GlobalContext)
    const [isShowModal, setIsShowModal] = React.useState<boolean>(false)

    const handleBtnDeleteClick = () =>{
        fetch(`${process.env.REACT_APP_API}/games/${props.game.id}`, {
            method: "DELETE"
        }).then( data => {
            if(!data.ok){
                throw new Error()
            }
            //todo ok alert
            createNotification(notificationsDispatch, "Success", "", "success", 3000)
            props.reload()

        }).catch(err => {
            // console.log(err)
            createNotification(notificationsDispatch, "Error", "", "danger")
        })
    }
    return (<>
    <DeleteModal title={`Delete ${props.game.name}`} onBtnDeleteClick={handleBtnDeleteClick} onBtnCloseClick={()=>{setIsShowModal(false)}} isShow={isShowModal} />
        <div className='border p-2 mb-3 rounded cursor-pointer game' onClick={() => { setGame(gameDispatch, props.game) }}>
            <div className='d-flex justify-content-between align-items-end'>
                <h4 className='mb-2'>{props.game.name}{<span className={`text-${props.game.isCompleted ? "success" : "danger"}`}><FontAwesomeIcon icon={props.game.isCompleted ? faCheck : faPersonDigging} className={"ms-2"} /></span>}</h4>
                <div className='d-flex'>
                    <Link to={`/games/clone/${props.game.id}`}>
                        <Button variant="outline-secondary" className="me-2"> <FontAwesomeIcon icon={faCopy} /> Clone</Button>
                    </Link>
                    <Link to={`/games/edit/${props.game.id}`}>
                        <Button variant="outline-success" className="me-2"> <FontAwesomeIcon icon={faEdit} /> Edit</Button>
                    </Link>
                    <Button variant="outline-danger"
                        className="me-2"
                        onClick={()=>{setIsShowModal(true)}}
                        >
                        <FontAwesomeIcon icon={faTrashCan} /> Delete
                    </Button>
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
                                <div className="font-monospace">Total: {props.game.cardsCount}</div>
                            </div>
                        </Link>
                    </Col>
                    <Col>
                        <Link to="/fields" className='link'>
                            <div className="border rounded cursor-pointer p-2 m-1 bg-white  game-card">
                                <h6>Fields</h6>
                                <hr className='my-1' />
                                <div className="font-monospace">Total: {props.game.fieldsCount}</div>
                            </div>
                        </Link>
                    </Col>
                    <Col>
                        <Link to="/banknotes" className='link'>
                            <div className="border rounded cursor-pointer p-2 m-1 bg-white  game-card">
                                <h6>Banknotes</h6>
                                <hr className='my-1' />
                                <div className="font-monospace">Total: {props.game.banknotesCount}</div>
                            </div>
                        </Link>
                    </Col>
                </Row>
            </Container>
        </div>
        </>
    )
}