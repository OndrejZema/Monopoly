import React from 'react'
import { Game } from './components/Game'
import Button from 'react-bootstrap/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { PaginationPanel } from '../../components/PaginationPanel'
import { Link } from 'react-router-dom'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IGamePreview } from '../../types/MonopolyTypes'
import { LoadingPanel } from '../../components/LoadingPanel'
import { setTotalCount } from '../../store/actions/PaginationActions'


export const Games = () => {

    const { gamesPaginationState, gamesPaginationDispatch } = React.useContext(GlobalContext)
    const [games, setGames] = React.useState<Array<IGamePreview>>()

    React.useEffect(() => {
        console.log(gamesPaginationState)
        fetch(`${process.env.REACT_APP_API}/games?page=${gamesPaginationState.page}&perPage=${gamesPaginationState.perPage}`)
            .then(data => {
                if (!data.ok) {
                    throw new Error()
                }
                let totalCount = data.headers.get("x-total-count")
                if (totalCount) {
                    if (!isNaN(parseInt(totalCount))) {
                        if (parseInt(totalCount) !== gamesPaginationState.totalCount) {
                            setTotalCount(gamesPaginationDispatch, parseInt(totalCount))
                        }
                    }
                }
                return data.json()
            })
            .then(json => {
                console.log(json)
                setGames(json)
            })
            .catch(err => {
                console.log("Error loading games")
            })

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
        {games?.map(item => <Game game={item} />)}
        <PaginationPanel
            label='Games per page'
            state={gamesPaginationState}
            dispatch={gamesPaginationDispatch}
        />
    </LoadingPanel>)
}