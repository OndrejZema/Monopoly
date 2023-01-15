import React from 'react'
import { useParams } from 'react-router'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyGame, GameFormSchema } from '../../schemas/Schemas'
import { IGame } from '../../types/ViewModels'
interface Props {
    doClone?: boolean
}

export const GameEdit = (props: Props) => {

    const params = useParams()
    const [game, setGame] = React.useState<IGame>()

    React.useEffect(() => {
        if (params.id) {
            fetch(`${process.env.REACT_APP_API}/games/${params.id}`)
                .then(data => {
                    if (!data.ok) {
                        throw new Error()
                    }
                    return data.json()
                })
                .then(json => {
                    setGame(props.doClone? {...json, id: undefined}:json)
                })
                .catch(err => {
                    console.log("Error loading field")
                })
        }
        else {
            setGame({ ...emptyGame})
        }
    }, [])

    // React.useEffect(()=>{
    //     console.log(game)
    // }, [game])

    return (
        <>
            <ItemEdit
                title='Game edit'
                returnUrl='/'
                apiUrl={`${process.env.REACT_APP_API}/games`}
                schema={GameFormSchema}
                options={{}}
                data={game}
                doClone={props.doClone}

            />
        </>
    )
}