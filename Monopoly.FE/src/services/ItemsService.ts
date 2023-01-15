import React from "react"
import { createNotification } from "../store/actions/NotificationsActions"
import { setTotalCount } from "../store/actions/PaginationActions"
import { INotificationsAction } from "../store/reducers/NotificationsReducer"
import { IPaginationAction, IPaginationState } from "../store/reducers/PaginationReducer"

export const loadData = (url: string, setData: (data: any)=>void,
    paginationState: IPaginationState, 
    paginationDispatch: React.Dispatch<IPaginationAction>, notificationsDispatch: React.Dispatch<INotificationsAction>, gameId?: number) => {

    let apiUrl:string = `${process.env.REACT_APP_API}/${gameId?`games/${gameId}/`:""}${url}?page=${paginationState.page}&perPage=${paginationState.perPage}`
    fetch(apiUrl)
    .then(data => {
        if (!data.ok) {
            throw new Error()
        }
        let totalCount = data.headers.get("x-total-count")
        if (totalCount) {
            if (!isNaN(parseInt(totalCount))) {
                if (parseInt(totalCount) !== paginationState.totalCount) {
                    setTotalCount(paginationDispatch, parseInt(totalCount))
                }
            }
        }
        return data.json()
    })
    .then(json => {
        setData(json)
        // createNotification(notificationsDispatch, "Success", "", "success")
    })
    .catch(err => {
        createNotification(notificationsDispatch, "Error", "", "danger")
        // console.log(`Error loading ${url}`)
    })
}