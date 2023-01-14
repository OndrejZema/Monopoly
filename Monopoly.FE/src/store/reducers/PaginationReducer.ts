import { SET_PAGE, SET_PER_PAGE, SET_TOTAL_COUNT } from "../actions/PaginationActions"

export interface IPaginationState {
    page: number
    perPage: number
    perPageOptions: Array<number>
    totalCount: number
}
export interface IPaginationActionState{
    page?: number
    perPage?: number
    totalCount?: number
}
export interface IPaginationAction {
        type: string
        payload: IPaginationActionState
}
export const paginationInitialState: IPaginationState = {
    page: 0,
    perPage: 10,
    totalCount: 0,
    perPageOptions: [1, 2, 5, 10, 20, 50, 100],
}
export const paginationReducer = (state: IPaginationState = paginationInitialState, action: IPaginationAction): IPaginationState => {
    switch (action.type) {
        case SET_PAGE:
            return {
                ...state,
                page: action.payload.page !== undefined?action.payload.page:state.page,
            }
        case SET_PER_PAGE:
            return {
                ...state,
                page: action.payload.page !== undefined?action.payload.page:state.page,
                perPage: action.payload.perPage?action.payload.perPage:state.perPage
            }
        case SET_TOTAL_COUNT:
            return {
                ...state,
                totalCount: action.payload.totalCount?action.payload.totalCount:state.totalCount
            }
        default: return state
    }
}