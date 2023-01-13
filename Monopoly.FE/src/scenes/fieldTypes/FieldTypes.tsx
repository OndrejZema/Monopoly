import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldTypeSchema } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IField, IFieldType } from '../../types/ViewModels'


export const FieldTypes = () => {

    const {fieldTypesPaginationState, fieldTypesPaginationDispatch} = React.useContext(GlobalContext)

    const[fieldTypes, setFieldTypes] =  React.useState<Array<IFieldType>>()

    React.useEffect(()=>{
        fetch(`${process.env.REACT_APP_API}/fieldtypes?page=${fieldTypesPaginationState.page}&perPage=${fieldTypesPaginationState.perPage}`).then(data => {
            if(!data.ok){
                throw new Error()
            }
            return data.json()
        }).then(json => {
            //todo check type
            setFieldTypes((json as Array<IFieldType>))
        }).catch(err => {
            console.log(err)
        })

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