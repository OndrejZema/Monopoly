import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardSchema } from '../../schemas/Schemas'
import { loadData } from '../../services/ItemsService'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { ICard } from '../../types/ViewModels'


export const Cards = () => {
    const { gameState, notificationsDispatch } = React.useContext(GlobalContext);
    const [cardsPaginationState, cardsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [cards, setCards] = React.useState<Array<ICard>>()

    React.useEffect(() => {
        loadData("cards", setCards,
            cardsPaginationState, cardsPaginationDispatch,
            notificationsDispatch,
            gameState.game?.id)
    }, [cardsPaginationState])


    return <>
        <ItemsPanel
            title="Cards"
            url="cards"
            apiUrl={`${process.env.REACT_APP_API}/cards`}
            paginationState={cardsPaginationState}
            paginationDispatch={cardsPaginationDispatch}
            schema={CardSchema}
            data={cards}
            reload={() => {
                loadData("cards", setCards,
                    cardsPaginationState, cardsPaginationDispatch,
                    notificationsDispatch,
                    gameState.game?.id)
            }}
        />
    </>
}