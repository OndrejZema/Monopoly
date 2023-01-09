import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { CardTypeSchema, emptyCardType } from '../../schemas/Schemas'
import { ICardType } from '../../types/MonopolyTypes'

export const CardTypeEdit = () => {
    
    const [cardType, setCardType] = React.useState<ICardType>(emptyCardType)


    return (
        <>
            <ItemEdit
                title='Card type edit'
                returnUrl='/card-types'
                saveUrl='/api/card-types'
                schema={CardTypeSchema}
                data={cardType}
            />
        </>
    )
}