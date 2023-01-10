import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldSchema } from '../../schemas/Schemas'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'


export const Fields = () => {
    const [fieldsPaginationState, fieldsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    return (<>
        <ItemsPanel
            title="Fields"
            url="fields"
            schema={FieldSchema}
            paginationState={fieldsPaginationState}
            paginationDispatch={fieldsPaginationDispatch}
        />
    </>)
}