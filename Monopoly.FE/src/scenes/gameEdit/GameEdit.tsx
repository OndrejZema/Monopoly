import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyGame, GameFormSchema } from '../../schemas/Schemas'
import { IGame } from '../../types/ViewModels'

export const GameEdit = () => {

    const [game, setGame] = React.useState<IGame>(emptyGame)

    return (
        <>
            <ItemEdit
                title='Game edit'
                returnUrl='/'
                saveUrl='/api/games'
                schema={GameFormSchema}
                options={{}}
                data={game}
            />
        </>
    )
}