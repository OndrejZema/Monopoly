import React from "react";
import { IGame } from "../../types/ViewModels";
import { IGameAction } from "../reducers/GameReducer";

export const SET_GAME: string = "SET_GAME"

export const setGame = (dispatch: React.Dispatch<IGameAction>, game: IGame) =>{
    dispatch({type: SET_GAME, payload: {game: game}})
}