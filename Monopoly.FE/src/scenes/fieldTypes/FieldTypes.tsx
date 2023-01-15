import React from 'react'
import { ItemsPanel } from '../../components/ItemsPanel'
import { FieldTypeSchema } from '../../schemas/Schemas'
import { loadData } from '../../services/ItemsService'
import { setTotalCount } from '../../store/actions/PaginationActions'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IField, IFieldType } from '../../types/ViewModels'


export const FieldTypes = () => {

    const { fieldTypesPaginationState, fieldTypesPaginationDispatch, notificationsDispatch } = React.useContext(GlobalContext)

    const [fieldTypes, setFieldTypes] = React.useState<Array<IFieldType>>()

    React.useEffect(() => {
        loadData("fieldtypes", setFieldTypes,
            fieldTypesPaginationState, fieldTypesPaginationDispatch, 
            notificationsDispatch)

    }, [fieldTypesPaginationState])

    return (<>
        <ItemsPanel
            title="Field types"
            url="field-types"
            apiUrl={`${process.env.REACT_APP_API}/fieldtypes`}
            schema={FieldTypeSchema}
            data={fieldTypes}
            paginationState={fieldTypesPaginationState}
            paginationDispatch={fieldTypesPaginationDispatch}
            reload={() => {
                loadData("fieldtypes", setFieldTypes,
                    fieldTypesPaginationState, fieldTypesPaginationDispatch,
                    notificationsDispatch)
            }}
        />
    </>)
}