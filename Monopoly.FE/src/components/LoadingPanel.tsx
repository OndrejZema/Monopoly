import React from 'react'
import { Spinner } from 'react-bootstrap'

interface Props {
    children: React.ReactNode
    loaded?: boolean | any
}

export const LoadingPanel = (props: Props) => {
    return (<>
        {
            !props.loaded ?
                <div className="d-flex justify-content-center">
                    <Spinner />
                </div>
                :
                props.children
        }
    </>
    )
}