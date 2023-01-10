import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { CardFormSchema, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { ICard } from '../../types/MonopolyTypes'

export const CardEdit = () => {
    
    const [card, setCard] = React.useState<ICard>(emptyCard)


    return (
        <>
            <ItemEdit
                title='Card edit'
                returnUrl='/cards'
                saveUrl='/api/cards'
                schema={CardFormSchema}
                options={{types: [{label: "lb1", value: "val1"}], games: [{label: "game 1", value: "game1"}]}}
                data={card}
            />
        </>
    )
}