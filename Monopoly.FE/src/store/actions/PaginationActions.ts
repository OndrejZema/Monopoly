import React from "react";
import { IPaginationAction } from "../reducers/PaginationReducer";

export const SET_PAGE:string = "SET_PAGE"
export const SET_PER_PAGE:string = "SET_PER_PAGE"

export const setPage = (dispatch: React.Dispatch<IPaginationAction>, page: number) => {
    dispatch({type: SET_PAGE, payload: {page: page}})
}
export const setPerPage = (dispatch: React.Dispatch<IPaginationAction>, perPage: number) => {
    dispatch({type: SET_PER_PAGE, payload: {perPage: perPage}})
}