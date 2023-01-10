export interface IGame{
    id?: number
    name: string
    description: string
}

export interface ICard{
    id?: number
    name: string
    description: string
    type?: ICardType
    game?: IGame
}
export interface ICardType{
    id?: number
    name: string
    description: string
}
export interface IBanknote{
    id?: number
    value: number
    count: number
    unit: string
    game?: IGame
}
export interface IField{
    id?: number
    name: string
    type?: IFieldType
    game?: IGame

}
export interface IFieldType{
    id?: number
    name: string
    description: string
}
