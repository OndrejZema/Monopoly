import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { BanknoteSchema } from '../../schemas/Schemas'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { IBanknote } from '../../types/ViewModels'

export const Banknotes = () => {


    const [banknotesPaginationState, banknotesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)    
    const [banknotes, setBanknotes] = React.useState<Array<IBanknote>>()

    React.useEffect(()=>{
        fetch(`${process.env.REACT_APP_API}/banknotes?page=${banknotesPaginationState.page}&perPage=${banknotesPaginationState.perPage}`)
        .then(data => {
            if (!data.ok) {
                throw new Error()
            }
            let totalCount = data.headers.get("x-total-count")
            if (totalCount) {
                if (!isNaN(parseInt(totalCount))) {
                    if (parseInt(totalCount) !== banknotesPaginationState.totalCount) {
                        setTotalCount(banknotesPaginationDispatch, parseInt(totalCount))
                    }
                }
            }
            return data.json()
        })
        .then(json => {
            setBanknotes(json)
        })
        .catch(err => {
            console.log("Error loading games")
        })


    }, [banknotesPaginationState])
    return (<>
        <ItemsPanel
            title="Banknotes"
            url="banknotes"
            schema={BanknoteSchema}
            paginationState={banknotesPaginationState}
            paginationDispatch={banknotesPaginationDispatch}
            data={banknotes}
        />

    </>)
}