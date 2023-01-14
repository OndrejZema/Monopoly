import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { CardTypeSchema } from '../../schemas/Schemas'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { ICardType } from '../../types/ViewModels'


export const CardTypes = () => {
    const {cardTypesPaginationState, cardTypesPaginationDispatch} = React.useContext(GlobalContext)
    const [cardTypes, setCardTypes] = React.useState<Array<ICardType>>()

    React.useEffect(()=>{
        fetch(`${process.env.REACT_APP_API}/cardtypes?page=${cardTypesPaginationState.page}&perPage=${cardTypesPaginationState.perPage}`).then(data => {
            if(!data.ok){
                throw new Error()
            }
            let totalCount = data.headers.get("x-total-count")
            if (totalCount) {
                if (!isNaN(parseInt(totalCount))) {
                    if (parseInt(totalCount) !== cardTypesPaginationState.totalCount) {
                        setTotalCount(cardTypesPaginationDispatch, parseInt(totalCount))
                    }
                }
            }
            return data.json()
        }).then(json => {
            //todo check type
            setCardTypes((json as Array<ICardType>))
        }).catch(err => {
            console.log(err)
        })
    }, [cardTypesPaginationState])

    return (<>
        <ItemsPanel 
            title="Card types"
            url="card-types"
            schema={CardTypeSchema}
            paginationState={cardTypesPaginationState}
            paginationDispatch={cardTypesPaginationDispatch}
            data={cardTypes}
        />
    </>)
}