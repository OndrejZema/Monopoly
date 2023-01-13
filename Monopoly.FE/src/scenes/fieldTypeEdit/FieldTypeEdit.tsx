import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { emptyFieldType, FieldTypeFormSchema } from '../../schemas/Schemas'
import {IFieldType} from '../../types/ViewModels'

export const FieldTypeEdit = () => {

    const params = useParams()

    const [fieldType, setFieldType] = React.useState<IFieldType | undefined>()

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
                    setFieldType(json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setFieldType(emptyFieldType)
        }
    }, [])


    return (
        <LoadingPanel loaded={fieldType}>
            <ItemEdit
                title={`Field type ${fieldType?.id?"edit":"create"}`}
                returnUrl='/field-types'
                saveUrl='/api/file-types'
                schema={FieldTypeFormSchema}
                options={{}}
                data={fieldType}
            />
        </LoadingPanel>
    )
}