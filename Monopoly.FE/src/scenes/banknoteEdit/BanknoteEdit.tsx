import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { BanknoteFormSchema, emptyBanknote, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IBanknote, ICardType } from '../../types/ViewModels'

interface Props{
    doClone?: boolean
}


export const BanknoteEdit = (props: Props) => {

    const params = useParams()
    const {gameState} = React.useContext(GlobalContext)
    
    const [banknote, setBanknote] = React.useState<IBanknote | undefined>()

    React.useEffect(() => {
        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/banknotes/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setBanknote(json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setBanknote({...emptyBanknote, gameId: gameState.game?.id!})
        }
    }, [])



    return (
        <LoadingPanel loaded={banknote}>
            <ItemEdit
                title={`Banknote ${banknote?.id?"edit":"create"}`}
                returnUrl='/banknotes'
                saveUrl={`${process.env.REACT_APP_API}/banknotes`}
                schema={BanknoteFormSchema}
                options={{}}
                data={banknote}
                doClone={props.doClone}
            />
        </LoadingPanel>
    )
}