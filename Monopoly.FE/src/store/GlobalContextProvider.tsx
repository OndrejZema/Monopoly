import React from 'react'
import { gameInitialState, gameReducer, IGameAction, IGameState } from './reducers/GameReducer'
import { INotificationsAction, INotificationsState, notificationsInitialState, notificationsReducer } from './reducers/NotificationsReducer'
import { IPaginationAction, IPaginationState, paginationInitialState, paginationReducer } from './reducers/PaginationReducer'

interface IGlobalContext {

    gameState: IGameState
    gameDispatch: (action: IGameAction) => void

    gamesPaginationState: IPaginationState
    gamesPaginationDispatch: (action: IPaginationAction) => void

    cardTypesPaginationState: IPaginationState
    cardTypesPaginationDispatch: (action: IPaginationAction) => void

    fieldTypesPaginationState: IPaginationState
    fieldTypesPaginationDispatch: (action: IPaginationAction) => void


    notificationState: INotificationsState
    notificationsDispatch: (action: INotificationsAction) => void
}

export const GlobalContext = React.createContext<IGlobalContext>({

    gameState: gameInitialState,
    gameDispatch: () => { },

    gamesPaginationState: paginationInitialState,
    gamesPaginationDispatch: () => { },

    cardTypesPaginationState: paginationInitialState,
    cardTypesPaginationDispatch: () => { },

    fieldTypesPaginationState: paginationInitialState,
    fieldTypesPaginationDispatch: () => { },

    notificationState: notificationsInitialState,
    notificationsDispatch: () => { }


})

interface GlobalContextProviderProps {
    children: React.ReactNode
}

export const GlobalContextProvider = (props: GlobalContextProviderProps) => {

    const [gameState, gameDispatch] = React.useReducer(gameReducer, gameInitialState)
    const [gamesPaginationState, gamesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [cardTypesPaginationState, cardTypesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)
    const [fieldTypesPaginationState, fieldTypesPaginationDispatch] = React.useReducer(paginationReducer, paginationInitialState)

    const [notificationState, notificationsDispatch] = React.useReducer(notificationsReducer, notificationsInitialState)

    const store = React.useMemo(() => ({
        gameState, gameDispatch,
        gamesPaginationState, gamesPaginationDispatch,
        cardTypesPaginationState, cardTypesPaginationDispatch,
        fieldTypesPaginationState, fieldTypesPaginationDispatch,
        notificationState, notificationsDispatch
    }), [
        gameState, gameDispatch,
        gamesPaginationState, gamesPaginationDispatch,
        cardTypesPaginationState, cardTypesPaginationDispatch,
        fieldTypesPaginationState, fieldTypesPaginationDispatch,
        notificationState, notificationsDispatch
    ])

    return (
        <GlobalContext.Provider value={store}>
            {props.children}
        </GlobalContext.Provider>
    )

}