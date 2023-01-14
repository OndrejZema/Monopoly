import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardSchema } from '../../schemas/Schemas'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { ICard } from '../../types/ViewModels'


export const Cards = () => {
    const {gameState} = React.useContext(GlobalContext);
    const [cardsPaginationState, cardsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [cards, setCards] = React.useState<Array<ICard>>()

    React.useEffect(()=>{
        fetch(`${process.env.REACT_APP_API}/games/${gameState.game?.id}/cards?page=${cardsPaginationState.page}&perPage=${cardsPaginationState.perPage}`)
            .then(data => {
                if (!data.ok) {
                    throw new Error()
                }
                let totalCount = data.headers.get("x-total-count")
                console.log(totalCount)
                if (totalCount) {
                    if (!isNaN(parseInt(totalCount))) {
                        if (parseInt(totalCount) !== cardsPaginationState.totalCount) {
                            setTotalCount(cardsPaginationDispatch, parseInt(totalCount))
                        }
                    }
                }
                return data.json()
            })
            .then(json => {
                setCards(json)
            })
            .catch(err => {
                console.log("Error loading cards")
            })


    }, [cardsPaginationState])


    return <>
        <ItemsPanel
            title="Cards"
            url="cards"
            paginationState={cardsPaginationState}
            paginationDispatch={cardsPaginationDispatch}
            schema={CardSchema}
            data={cards}
        />
    </>
}