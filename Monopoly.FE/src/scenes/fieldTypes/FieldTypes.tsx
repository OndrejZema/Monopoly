import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldTypeSchema } from '../../schemas/Schemas'
import { setTotalCount } from '../../store/actions/PaginationActions'
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
            let totalCount = data.headers.get("x-total-count")
            if (totalCount) {
                if (!isNaN(parseInt(totalCount))) {
                    if (parseInt(totalCount) !== fieldTypesPaginationState.totalCount) {
                        setTotalCount(fieldTypesPaginationDispatch, parseInt(totalCount))
                    }
                }
            }
            return data.json()
        }).then(json => {
            //todo check type
            setFieldTypes((json as Array<IFieldType>))
        }).catch(err => {
            console.log(err)
        })

    }, [fieldTypesPaginationState])

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