import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { emptyField, FieldFormSchema, FieldTypeSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IField, IFieldType } from '../../types/ViewModels'
interface Props {
    doClone?: boolean
}

export const FieldEdit = (props: Props) => {

    const params = useParams()
    const { gameState } = React.useContext(GlobalContext)


    const [field, setField] = React.useState<IField | undefined>()
    const [fieldTypes, setFieldTypes] = React.useState<Array<IFieldType>>()

    React.useEffect(() => {

        fetch(`${process.env.REACT_APP_API}/fieldtypes`).then(data => {
            if (!data.ok) {
                throw new Error()
            }
            return data.json()
        }).then(json => {
            setFieldTypes(json)
        }).catch(err => {
            console.log(err)
        })

        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/fields/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setField(json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setField({ ...emptyField, gameId: gameState.game?.id! })
        }
    }, [])

    return (
        <LoadingPanel loaded={field || fieldTypes}>
            <ItemEdit
                title={`Field ${field?.id ? "edit" : "create"}`}
                returnUrl='/fields'
                saveUrl={`${process.env.REACT_APP_API}/fields`}
                schema={FieldFormSchema}
                options={{ type: fieldTypes?.map(item => { return { label: item.name, value: item } }) }}
                data={field}
                doClone={props.doClone}

            />
        </LoadingPanel>
    )
}