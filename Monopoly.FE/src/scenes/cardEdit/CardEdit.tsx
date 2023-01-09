import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { CardSchema, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { ICardType } from '../../types/MonopolyTypes'

export const CardEdit = () => {
    
    const [card, setCard] = React.useState<ICardType>(emptyCard)


    return (
        <>
            <ItemEdit
                title='Card edit'
                returnUrl='/cards'
                saveUrl='/api/cards'
                schema={CardSchema}
                options={{type: [{label: "lb1", value: "val1"}]}}
                data={card}
            />
        </>
    )
}