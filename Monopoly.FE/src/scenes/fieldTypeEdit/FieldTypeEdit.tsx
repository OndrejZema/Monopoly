import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyFieldType, FieldTypeFormSchema } from '../../schemas/Schemas'
import {IFieldType} from '../../types/MonopolyTypes'

export const FieldTypeEdit = () => {

    const [fieldType, setFieldType] = React.useState<IFieldType>(emptyFieldType)

    return (
        <>
            <ItemEdit
                title='Field type edit'
                returnUrl='/field-types'
                saveUrl='/api/file-types'
                schema={FieldTypeFormSchema}
                options={{}}
                data={fieldType}
            />
        </>
    )
}