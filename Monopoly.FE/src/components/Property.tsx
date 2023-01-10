import React from 'react'
import { Form } from 'react-bootstrap'
import Select from 'react-select'
import { IOption } from '../types/FrontendTypes'

interface Props {
    name: string
    label: string
    type: string
    value?: string | number
    options?: Array<IOption>
    onChange: (name: string, value: string | number) => void
}

export const Property = (props: Props) => {
    return (
        <div className="mb-3">
            <Form.Label className='mb-1'>{props.label}</Form.Label>
            {(props.type === "string" || props.type === "number") ?
                (<Form.Control type={props.type}
                    onChange={(e) => { props.onChange(props.name, e.target.value) }}
                    value={props.value} />) :
                (props.options ?
                    <Select options={(props.options as any)}
                        onChange={(e) => {e && props.onChange(props.name, e)}}
                        value={props.value} /> : <>Chybny parametr</>)}
        </div>
    )
}