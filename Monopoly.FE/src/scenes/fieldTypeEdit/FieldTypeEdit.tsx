import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyFieldType, FieldTypeSchema } from '../../schemas/Schemas'
import {IFieldType} from '../../types/MonopolyTypes'

export const FieldTypeEdit = () => {

    const [fieldType, setFieldType] = React.useState<IFieldType>(emptyFieldType)

    return (
        <>
            <ItemEdit
                title='Field type edit'
                returnUrl='/field-types'
                saveUrl='/api/file-types'
                schema={FieldTypeSchema}
                data={fieldType}
            />
        </>
    )
}