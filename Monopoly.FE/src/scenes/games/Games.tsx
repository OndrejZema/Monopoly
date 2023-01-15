import React from 'react'
import { Game } from './components/Game'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { PaginationPanel } from '../../components/PaginationPanel'
import { Link } from 'react-router-dom'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IGamePreview } from '../../types/ViewModels'
import { LoadingPanel } from '../../components/LoadingPanel'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { loadData } from '../../services/ItemsService'


export const Games = () => {

    const { gamesPaginationState, gamesPaginationDispatch, notificationsDispatch } = React.useContext(GlobalContext)
    const [games, setGames] = React.useState<Array<IGamePreview>>()

    React.useEffect(() => {
        loadData("gamespreview", setGames,
            gamesPaginationState, gamesPaginationDispatch, notificationsDispatch)

    }, [gamesPaginationState])

    return (<LoadingPanel loaded={games}>
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
        {games?.length ?
            games?.map((item, index) => <div key={`game_${index}`}><Game game={item} reload={() => {
                loadData("gamespreview", setGames,
                    gamesPaginationState, gamesPaginationDispatch, notificationsDispatch)
            }} /></div>)
            : <div className='d-flex justify-content-center p-3 border rounded bg-light'><h3 className='text-secondary font-monospace'>No games</h3></div>
        }
        <PaginationPanel
            label='Games per page'
            state={gamesPaginationState}
            dispatch={gamesPaginationDispatch}
        />
    </LoadingPanel>)
}