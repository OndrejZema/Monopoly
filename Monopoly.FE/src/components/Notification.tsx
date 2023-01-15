import { faCircleCheck, faCircleExclamation } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Alert } from 'react-bootstrap'
import { removeNotification } from '../store/actions/NotificationsActions'
import { GlobalContext } from '../store/GlobalContextProvider'
import { INotification } from '../store/reducers/NotificationsReducer'

interface Props {
    notification: INotification
}

export const Notification = (props: Props) => {

    const {notificationsDispatch} = React.useContext(GlobalContext)

    const handleRemove = () => {
        removeNotification(notificationsDispatch, props.notification.id)
    }

    return (<Alert variant={props.notification.variant} onClick={handleRemove} className="cursor-pointer">
        <Alert.Heading>
            <FontAwesomeIcon icon={props.notification.variant === "danger" ? faCircleExclamation : faCircleCheck}
            className="me-2" />
            {props.notification.title}
        </Alert.Heading>
        {props.notification.text !== "" && <p>
            {props.notification.text}
        </p>}
    </Alert>)
}