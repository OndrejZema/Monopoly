import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { BanknoteSchema } from '../../schemas/Schemas'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'

export const Banknotes = () => {

    const [banknotesPaginationState, banknotesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)

    return (<>
        <ItemsPanel
            title="Banknotes"
            url="banknotes"
            schema={BanknoteSchema}
            paginationState={banknotesPaginationState}
            paginationDispatch={banknotesPaginationDispatch}
        />

    </>)
}