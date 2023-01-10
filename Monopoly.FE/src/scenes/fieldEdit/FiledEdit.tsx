import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyField, FieldFormSchema } from '../../schemas/Schemas'
import { IFieldType } from '../../types/MonopolyTypes'

export const FieldEdit = () => {
    
    const [field, setField] = React.useState<IFieldType>(emptyField)


    return (
        <>
            <ItemEdit
                title='Field edit'
                returnUrl='/fields'
                saveUrl='/api/fields'
                schema={FieldFormSchema}
                options={{types: [{label: "lb1", value: "val1"}], games: [{label: "Game 1", value: "game1"}]}}
                data={field}
            />
        </>
    )
}