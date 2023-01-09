import React from 'react'
import { ItemEdit } from '../../components/ItemEdit'
import { emptyGame, GameSchema } from '../../schemas/Schemas'
import { IGame } from '../../types/MonopolyTypes'

export const GameEdit = () => {

    const [game, setGame] = React.useState<IGame>(emptyGame)

    return (
        <>
            <ItemEdit
                title='Game edit'
                returnUrl='/'
                saveUrl='/api/games'
                schema={GameSchema}
                data={game}
            />
        </>
    )
}