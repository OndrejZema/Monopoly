import { SET_PAGE, SET_PER_PAGE } from "../actions/PaginationActions"

export interface IPaginationState {
    page: number
    perPage: number
    perPageOptions: Array<number>
}
export interface IPaginationActionState{
    page?: number
    perPage?: number
}
export interface IPaginationAction {
        type: string
        payload: IPaginationActionState
}
export const paginationInitialState: IPaginationState = {
    page: 0,
    perPage: 10,
    perPageOptions: [1, 2, 5, 10, 20, 50, 100]
}
export const paginationReducer = (state: IPaginationState = paginationInitialState, action: IPaginationAction): IPaginationState => {
    switch (action.type) {
        case SET_PAGE:
            return {
                ...state,
                page: action.payload.page?action.payload.page:state.page
            }
        case SET_PER_PAGE:
            return {
                ...state,
                perPage: action.payload.perPage?action.payload.perPage:state.perPage

            }
        default: return state
    }
}