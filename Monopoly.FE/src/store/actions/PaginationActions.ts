import React from "react";
import { IPaginationAction } from "../reducers/PaginationReducer";

export const SET_PAGE:string = "SET_PAGE"
export const SET_PER_PAGE:string = "SET_PER_PAGE"
export const SET_TOTAL_COUNT:string = "SET_TOTAL_COUNT"

export const setPage = (dispatch: React.Dispatch<IPaginationAction>, page: number) => {
    dispatch({type: SET_PAGE, payload: {page: page}})
}
export const setPerPage = (dispatch: React.Dispatch<IPaginationAction>, perPage: number) => {
    dispatch({type: SET_PER_PAGE, payload: {perPage: perPage, page: 0}})
}
export const setTotalCount = (dispatch: React.Dispatch<IPaginationAction>, totalCount: number) => {
    dispatch({type: SET_TOTAL_COUNT, payload: {totalCount: totalCount}})
}