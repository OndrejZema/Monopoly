import React from 'react'
import { Form } from 'react-bootstrap'
import Select from 'react-select'
import { IOption } from '../types/FrontendTypes'

interface Props {
    name: string
    label: string
    type: string
    value?: string | number | any
    options?: Array<IOption>
    onChange: (name: string, value: string | number) => void
}

export const Property = (props: Props) => {

    const renderInput = (type: string) => {
        switch (type) {
            case "string":
                return <Form.Control type="string"
                    onChange={(e) => { props.onChange(props.name, e.target.value)}}
                    value={props.value} />
            case "number":
                return <Form.Control type="number"
                    onChange={(e) => { props.onChange(props.name, parseInt(e.target.value))}}
                    value={props.value} />
            case "boolean":
                return <Form.Check type="switch" value={props.value} onChange={(e)=>{props.onChange(props.name, e.target.value)}} />
            case "array":
                return props.options ?
                <Select options={(props.options as Array<any>)}
                    onChange={(e) => { e && props.onChange(props.name, (e as any)["value"]) }}
                    value={{ label: (props.value as any)?.["name"], value: props.value }} /> : <>Chybny parametr</>
            default:
                return <p>Non supported input</p>
        }
    }

    return (
        <div className="mb-3">
            <Form.Label className='mb-1'>{props.label}</Form.Label>
            {renderInput(props.type)}
        </div>
    )
}