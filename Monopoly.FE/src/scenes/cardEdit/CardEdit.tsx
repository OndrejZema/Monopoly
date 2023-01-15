import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { CardFormSchema, emptyCard } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { ICard, ICardType } from '../../types/ViewModels'

interface Props{
    doClone?: boolean
}

export const CardEdit = (props: Props) => {
    
    const params = useParams()
    const {gameState} = React.useContext(GlobalContext)


    const [card, setCard] = React.useState<ICard | undefined>()
    const [cardTypes, setCardTypes] = React.useState<Array<ICardType>>()

    React.useEffect(() => {

        fetch(`${process.env.REACT_APP_API}/cardtypes`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setCardTypes(json)
                    console.log(json)
                })
                .catch(err => {
                    console.log("Error loading card types")
                })

        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/cards/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setCard(props.doClone?{...json, id: undefined}: json)
                })
                .catch(err => {
                    console.log("Error loading card")
                })
        }
        else {
            setCard({...emptyCard, gameId: gameState.game?.id!})
        }
    }, [])


    return (
        <LoadingPanel loaded={card && cardTypes}>
            <ItemEdit
                title={`Card ${card?.id?"edit":"create"}`}
                returnUrl='/cards'
                apiUrl={`${process.env.REACT_APP_API}/cards`}
                schema={CardFormSchema}
                options={{type: cardTypes?.map(type => {return{label: type.name, value: type}})}}
                data={card}
                doClone={props.doClone}
            />
        </LoadingPanel>
    )
}