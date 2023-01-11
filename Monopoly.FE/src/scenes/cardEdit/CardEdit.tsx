import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { CardFormSchema, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { ICard } from '../../types/MonopolyTypes'

export const CardEdit = () => {
    
    const params = useParams()
    const {gameState} = React.useContext(GlobalContext)


    const [card, setCard] = React.useState<ICard | undefined>()


    React.useEffect(() => {
        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/field-types/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setCard(json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setCard({...emptyCard, game: gameState.game})
        }
    }, [])


    return (
        <LoadingPanel loaded={card}>
            <ItemEdit
                title={`Card ${card?.id?"edit":"create"}`}
                returnUrl='/cards'
                saveUrl='/api/cards'
                schema={CardFormSchema}
                options={{types: [{label: "lb1", value: "val1"}], games: [{label: "game 1", value: "game1"}]}}
                data={card}
            />
        </LoadingPanel>
    )
}