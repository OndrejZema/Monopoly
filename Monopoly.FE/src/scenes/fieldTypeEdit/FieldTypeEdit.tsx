import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { emptyFieldType, FieldTypeFormSchema } from '../../schemas/Schemas'
import { IFieldType } from '../../types/ViewModels'

interface Props {
    doClone?: boolean
}


export const FieldTypeEdit = (props: Props) => {

    const params = useParams()

    const [fieldType, setFieldType] = React.useState<IFieldType | undefined>()

    React.useEffect(() => {
        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/fieldtypes/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setFieldType(props.doClone?{...json, id: undefined}:json)
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
                title={`Field type ${fieldType?.id ? "edit" : "create"}`}
                returnUrl='/field-types'
                apiUrl={`${process.env.REACT_APP_API}/fieldtypes`}
                schema={FieldTypeFormSchema}
                options={{}}
                data={fieldType}
                doClone={props.doClone}

            />
        </LoadingPanel>
    )
}