import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldSchema } from '../../schemas/Schemas'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { IField } from '../../types/ViewModels'

interface Props{
    doClone?: boolean
}


export const Fields = () => {
    const {gameState} = React.useContext(GlobalContext)

    const [fieldsPaginationState, fieldsPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [fields, setFields] = React.useState<Array<IField>>()

    React.useEffect(()=>{
        fetch(`${process.env.REACT_APP_API}/games/${gameState.game?.id}/fields?page=${fieldsPaginationState.page}&perPage=${fieldsPaginationState.perPage}`)
        .then(data => {
            if (!data.ok) {
                throw new Error()
            }
            let totalCount = data.headers.get("x-total-count")
            if (totalCount) {
                if (!isNaN(parseInt(totalCount))) {
                    if (parseInt(totalCount) !== fieldsPaginationState.totalCount) {
                        setTotalCount(fieldsPaginationDispatch, parseInt(totalCount))
                    }
                }
            }
            return data.json()
        })
        .then(json => {
            setFields(json)
        })
        .catch(err => {
            console.log("Error loading fields")
        })


    }, [fieldsPaginationState])
    
    return (<>
        <ItemsPanel
            title="Fields"
            url="fields"
            schema={FieldSchema}
            paginationState={fieldsPaginationState}
            paginationDispatch={fieldsPaginationDispatch}
            data={fields}
        />
    </>)
}