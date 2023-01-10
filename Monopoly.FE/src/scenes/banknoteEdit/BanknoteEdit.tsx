import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { BanknoteFormSchema, emptyBanknote, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { IBanknote, ICardType } from '../../types/MonopolyTypes'

export const BanknoteEdit = () => {
    
    const [banknote, setBanknote] = React.useState<IBanknote>(emptyBanknote)


    return (
        <>
            <ItemEdit
                title='Banknote edit'
                returnUrl='/banknotes'
                saveUrl='/api/banknotes'
                schema={BanknoteFormSchema}
                options={{type: [{label: "lb1", value: "val1"}]}}
                data={banknote}
            />
        </>
    )
}