import { IBanknote, ICard, IField, IGame } from "../../types/ViewModels"

export interface IGameState {
    game?: IGame
    cards: Array<ICard>
    baknotes: Array<IBanknote>
    fields: Array<IField>
    loaded: boolean
}
export interface IGameActionState {
    game?: IGame
    cards?: Array<ICard>
    card?: ICard
    baknotes?: Array<IBanknote>
    banknote?: IBanknote
    fields?: Array<IField>
    field?: IField
    loaded?: boolean
}
export interface IGameAction {
    type: string
    payload: IGameActionState
}
export const gameInitialState: IGameState = {
    game: undefined,
    cards: [],
    baknotes: [],
    fields: [],
    loaded: false
}
export const gameReducer = (state: IGameState = gameInitialState, action: IGameAction): IGameState => {
    switch (action.type) {
        default: return state
    }
}
