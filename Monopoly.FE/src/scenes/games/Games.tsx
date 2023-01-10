import React from 'react'
import { Game } from './components/Game'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { PaginationPanel } from '../../components/PaginationPanel'
import { Link } from 'react-router-dom'
import { GlobalContext } from '../../store/GlobalContextProvider'

let games = [{}, {}, {}]

export const Games = () => {

    const {gamesPaginationState, gamesPaginationDispatch} = React.useContext(GlobalContext)

    return (<>
        <div className="d-flex justify-content-center">
            <h2>Games</h2>
        </div>
        <div className='d-flex justify-content-end'>
        <Link to="games/create">
            <Button variant="outline-dark" className='mb-2'>
                <FontAwesomeIcon icon={faPlus} className="me-1" />
                New game
            </Button>
        </Link>
        </div>
        {games.map(item => <Game />)}
        <PaginationPanel 
        label='Games per page' 
        page={gamesPaginationState.page} 
        perPage={gamesPaginationState.perPage} 
        perPageOptions={gamesPaginationState.perPageOptions} 
        total={30} 
        dispatch={gamesPaginationDispatch}
        />
    </>)
}