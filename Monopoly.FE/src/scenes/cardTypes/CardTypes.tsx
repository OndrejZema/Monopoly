import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardTypeSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'


export const CardTypes = () => {
    const {cardTypesPaginationState, cardTypesPaginationDispatch} = React.useContext(GlobalContext)
    return (<>
        <ItemsPanel 
            title="Card types"
            url="card-types"
            schema={CardTypeSchema}
            paginationState={cardTypesPaginationState}
            paginationDispatch={cardTypesPaginationDispatch}
        />
    </>)
}