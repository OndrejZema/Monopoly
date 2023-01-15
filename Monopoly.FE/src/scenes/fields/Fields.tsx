import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldSchema } from '../../schemas/Schemas'
import { loadData } from '../../services/ItemsService'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { IField } from '../../types/ViewModels'

interface Props {
    doClone?: boolean
}


export const Fields = () => {
    const { gameState, notificationsDispatch} = React.useContext(GlobalContext)

    const [fieldsPaginationState, fieldsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [fields, setFields] = React.useState<Array<IField>>()

    React.useEffect(() => {

        loadData("fields", setFields,
            fieldsPaginationState, fieldsPaginationDispatch,
            notificationsDispatch,
            gameState.game?.id)

    }, [fieldsPaginationState])

    return (<>
        <ItemsPanel
            title="Fields"
            url="fields"
            apiUrl={`${process.env.REACT_APP_API}/fields`}
            schema={FieldSchema}
            paginationState={fieldsPaginationState}
            paginationDispatch={fieldsPaginationDispatch}
            data={fields}
            reload={() => {
                loadData("fields", setFields,
                    fieldsPaginationState, fieldsPaginationDispatch,
                    notificationsDispatch,
                    gameState.game?.id)
            }}
        />
    </>)
}