import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { BanknoteSchema } from '../../schemas/Schemas'
import { loadData } from '../../services/ItemsService'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { paginationInitialState, paginationReducer } from '../../store/reducers/PaginationReducer'
import { IBanknote } from '../../types/ViewModels'

export const Banknotes = () => {

    const {gameState, notificationsDispatch} = React.useContext(GlobalContext)

    const [banknotesPaginationState, banknotesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)    
    const [banknotes, setBanknotes] = React.useState<Array<IBanknote>>()

    React.useEffect(()=>{
        loadData("banknotes", setBanknotes,
        banknotesPaginationState, banknotesPaginationDispatch,
        notificationsDispatch,
        gameState.game?.id)
    }, [banknotesPaginationState])
    return (<>
        <ItemsPanel
            title="Banknotes"
            url="banknotes"
            apiUrl={`${process.env.REACT_APP_API}/banknotes`}
            schema={BanknoteSchema}
            paginationState={banknotesPaginationState}
            paginationDispatch={banknotesPaginationDispatch}
            data={banknotes}
            reload={()=>{
                loadData("banknotes", setBanknotes,
                banknotesPaginationState, banknotesPaginationDispatch,
                notificationsDispatch,
                gameState.game?.id)
        
            }}
        />

    </>)
}