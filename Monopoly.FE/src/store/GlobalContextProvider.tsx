import React from 'react'
import { gameInitialState, gameReducer, IGameAction, IGameState } from './reducers/GameReducer'
import { INotificationsAction, INotificationsState, notificationsInitialState, notificationsReducer } from './reducers/NotificationsReducer'

interface IGlobalContext {

    gameState: IGameState
    gameDispatch: (action: IGameAction) => void

    notificationState: INotificationsState
    notificationsDispatch: (action: INotificationsAction) => void
}

export const GlobalContext = React.createContext<IGlobalContext>({

    gameState: gameInitialState,
    gameDispatch: () => { },

    notificationState: notificationsInitialState,
    notificationsDispatch: () => { }


})

interface GlobalContextProviderProps {
    children: React.ReactNode
}

export const GlobalContextProvider = (props: GlobalContextProviderProps) => {


    const [gameState, gameDispatch] = React.useReducer(gameReducer, gameInitialState)
    const [notificationState, notificationsDispatch] = React.useReducer(notificationsReducer, notificationsInitialState)

    const store = React.useMemo(() => ({
        gameState, gameDispatch,
        notificationState, notificationsDispatch
    }), [
        gameState, gameDispatch,
        notificationState, notificationsDispatch
    ])

    return (
        <GlobalContext.Provider value={store}>
            {props.children}
        </GlobalContext.Provider>
    )

}