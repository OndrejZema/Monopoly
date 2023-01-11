import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { emptyField, FieldFormSchema, FieldTypeSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IField } from '../../types/MonopolyTypes'

export const FieldEdit = () => {

    const params = useParams()
    const {gameState} = React.useContext(GlobalContext)


    const [field, setField] = React.useState<IField | undefined>()

    React.useEffect(() => {
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
            setField({...emptyField, game: gameState.game})
        }
    }, [])

    return (
        <LoadingPanel loaded={field?true:false}>
            <ItemEdit 
                title={`Field ${field?.id?"edit":"create"}`}
                returnUrl='/fields'
                saveUrl='/api/fields'
                schema={FieldFormSchema}
                options={{types: [{label: "lb type", value: 1}]}}
                data={field}
            />
        </LoadingPanel>
    )
}