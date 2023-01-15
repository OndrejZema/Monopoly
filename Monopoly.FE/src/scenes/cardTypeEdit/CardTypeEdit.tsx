import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { CardTypeFormSchema, emptyCardType } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { ICardType } from '../../types/ViewModels'

interface Props {
    doClone?: boolean
}


export const CardTypeEdit = (props: Props) => {
    const params = useParams()
    const { gameState } = React.useContext(GlobalContext)

    const [cardType, setCardType] = React.useState<ICardType | undefined>()

    React.useEffect(() => {
        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/cardtypes/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setCardType(props.doClone?{...json, id: undefined}:json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setCardType(emptyCardType)
        }
    }, [])


    return (
        <LoadingPanel loaded={cardType}>
            <ItemEdit
                title={`Card type ${cardType?.id ? "edit" : "create"}`}
                returnUrl='/card-types'
                apiUrl={`${process.env.REACT_APP_API}/cardtypes`}
                schema={CardTypeFormSchema}
                options={{}}
                data={cardType}
                doClone={props.doClone}

            />
        </LoadingPanel>
    )
}