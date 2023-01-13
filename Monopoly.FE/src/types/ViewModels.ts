export interface IGame{
    id?: number
    name: string
    description: string
    isCompleted: boolean
}
export interface IGamePreview{
    id?: number
    name: string
    description: string
    isCompleted: boolean
    cardsCount: number
    fieldsCount: number
    banknotesCount: number
}

export interface ICard{
    id?: number
    name: string
    description: string
    type?: ICardType
    gameId: number
}
export interface ICardType{
    id?: number
    name?: string
    description?: string
}
export interface IBanknote{
    id?: number
    value: number
    count: number
    unit: string
    gameId: number
}
export interface IField{
    id?: number
    name: string
    type?: IFieldType
    gameId: number

}
export interface IFieldType{
    id?: number
    name?: string
    description?: string
}
