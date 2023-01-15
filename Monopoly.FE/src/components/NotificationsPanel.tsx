import React from 'react'
import { GlobalContext } from '../store/GlobalContextProvider'
import { Notification } from './Notification'

export const NotificationsPanel = () => {

    const {notificationsState} = React.useContext(GlobalContext)
    
    return (<div className='notifications-panel'>
        {notificationsState.notifications.map((item, index) => {
            return <div key={item.id}><Notification notification={item} /></div>
        } )}
    </div>)
}