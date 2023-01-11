import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { LoadingPanel } from '../../components/LoadingPanel'
import { BanknoteFormSchema, emptyBanknote, emptyCard, emptyCardType } from '../../schemas/Schemas'
import { GlobalContext } from '../../store/GlobalContextProvider'
import { IBanknote, ICardType } from '../../types/MonopolyTypes'

export const BanknoteEdit = () => {

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
            setBanknote({...emptyBanknote, game: gameState.game})
        }
    }, [])



    return (
        <LoadingPanel loaded={banknote}>
            <ItemEdit
                title={`Banknote ${banknote?.id?"edit":"create"}`}
                returnUrl='/banknotes'
                saveUrl='/api/banknotes'
                schema={BanknoteFormSchema}
                options={{type: [{label: "lb1", value: "val1"}]}}
                data={banknote}
            />
        </LoadingPanel>
    )
}