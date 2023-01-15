import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardTypeSchema } from '../../schemas/Schemas'
import { loadData } from '../../services/ItemsService'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { ICardType } from '../../types/ViewModels'


export const CardTypes = () => {
    const { cardTypesPaginationState, cardTypesPaginationDispatch, notificationsDispatch } = React.useContext(GlobalContext)
    const [cardTypes, setCardTypes] = React.useState<Array<ICardType>>()

    React.useEffect(() => {
        loadData("cardtypes", setCardTypes,
            cardTypesPaginationState, cardTypesPaginationDispatch, 
            notificationsDispatch)
    }, [cardTypesPaginationState])

    return (<>
        <ItemsPanel
            title="Card types"
            url="card-types"
            apiUrl={`${process.env.REACT_APP_API}/cardtypes`}
            schema={CardTypeSchema}
            paginationState={cardTypesPaginationState}
            paginationDispatch={cardTypesPaginationDispatch}
            data={cardTypes}
            reload={() => {
                loadData("cardtypes", setCardTypes,
                    cardTypesPaginationState, cardTypesPaginationDispatch,
                    notificationsDispatch)
            }}
        />
    </>)
}