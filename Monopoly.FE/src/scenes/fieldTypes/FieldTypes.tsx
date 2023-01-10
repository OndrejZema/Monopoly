import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldTypeSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IField, IFieldType } from '../../types/MonopolyTypes'


export const FieldTypes = () => {

    const {fieldTypesPaginationState, fieldTypesPaginationDispatch} = React.useContext(GlobalContext)

    const[fieldTypes, setFieldTypes] =  React.useState<Array<IFieldType>>()

    React.useEffect(()=>{

    }, [])

    return (<>
        <ItemsPanel
            title="Field types"
            url="field-types"
            schema={FieldTypeSchema}
            data={fieldTypes}
            paginationState={fieldTypesPaginationState}
            paginationDispatch={fieldTypesPaginationDispatch}
        />
    </>)
}