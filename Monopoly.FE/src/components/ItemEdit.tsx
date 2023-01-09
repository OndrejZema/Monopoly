import { faAngleLeft, faFloppyDisk, faXmark } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button } from 'react-bootstrap'
import { Link, useNavigate } from 'react-router-dom'
import { Property } from './Property'

interface Props {
    title: string
    returnUrl: string
    saveUrl: string
    schema: any
    data: any
}

export const ItemEdit = (props: Props) => {
    const navigate = useNavigate()

    const [data, setData] = React.useState<any>(props.data)

    const handleChange = (name: string, value: string | number) => {
        setData({...data, [name]: value})
    }
    return (
        <>
            <div className='d-flex justify-content-center'>
                <h2>{props.title}</h2>
            </div>
            <div className="d-flex justify-content-between mb-2">
                <Link to={props.returnUrl}>
                    <Button variant="outline-secondary">
                        <FontAwesomeIcon icon={faAngleLeft} className="me-1" />
                        Back
                    </Button>
                </Link>
                <div>
                    <Button variant="outline-dark" className='me-2' onClick={() => {
                        navigate(props.returnUrl)
                    }}>
                        <FontAwesomeIcon icon={faFloppyDisk} className="me-1" />
                        Save
                    </Button>
                    <Button variant="outline-danger" onClick={() => {
                        navigate(props.returnUrl)
                    }}>
                        <FontAwesomeIcon icon={faXmark} className="me-1" />
                        Cancel
                    </Button>
                </div>
            </div>
            <div className='border rounded p-2'>
                {Object.keys(props.schema.properties).map(item => <Property
                    name={item}
                    label={ props.schema.properties[item]["title"]}
                    type={props.schema.properties[item]["type"]}
                    options={props.schema.properties[item]["items"]}
                    onChange={handleChange}
                    value={data[item]}
                />)}
            </div>
        </>
    )
}