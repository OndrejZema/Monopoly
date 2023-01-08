import React from 'react'
import { Game } from './components/Game'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { PaginationPanel } from '../../components/PaginationPanel'

let games = [{}, {}, {}]

export const Games = () => {



    return (<>
        <h2>Games</h2>
        <Button variant="outline-dark" className='mb-2'>
            <FontAwesomeIcon icon={faPlus} className="me-1" />
            New game
        </Button>
        {games.map(item => <Game />)}
        <PaginationPanel page={0} perPage={10} perPageOptions={[1, 2, 4]} total={30}/>
    </>)
}