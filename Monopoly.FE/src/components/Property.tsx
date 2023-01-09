import React from 'react'
import { Form } from 'react-bootstrap'

interface Props {
    name: string
    label: string
    type: string
    value?: string | number
    options?: Array<{ label: string, value: string | number }>
    onChange: (name: string, value: string | number) => void
}

export const Property = (props: Props) => {
    return (
        <>
            <Form.Label>{props.label}</Form.Label>
            <Form.Control type={props.type}
                onChange={(e) => { props.onChange(props.name, e.target.value) }}
                value={props.value} />
        </>
    )
}