import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'


export const Cards = () => {

    const [cardsPaginationState, cardsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)

    return <>
        <ItemsPanel
            title="Cards"
            url="cards"
            paginationState={cardsPaginationState}
            paginationDispatch={cardsPaginationDispatch}
            schema={CardSchema}
        />
    </>
}