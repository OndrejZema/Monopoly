import { faAngleLeft, faFloppyDisk, faPersonWalkingDashedLineArrowRight, faXmark } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button, Spinner } from 'react-bootstrap'
import { Link, useNavigate } from 'react-router-dom'
import { LoadingPanel } from './LoadingPanel'
import { Property } from './Property'

interface Props {
    title: string
    returnUrl: string
    saveUrl: string
    schema: any
    options: any // object of options like {type: [{label: "Card type one", value: "1"}], gameId: [{label: "Game 1", value: "game1"}]}
    data?: any
    doClone?: boolean
}

export const ItemEdit = (props: Props) => {
    const navigate = useNavigate()


    const [data, setData] = React.useState<any>()

    React.useEffect(() => {
        if (!data && props.data) {
            setData(props.data)
        }
    })

    const handleBtnSaveClick = () => {
        fetch(props.saveUrl, {
            method: props.doClone ? "POST" : "PUT",
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(data)
        }).then(response => {
            if (!response.ok) {
                throw new Error()
            }
            return response.json()
        }).then(json => {
            
            navigate(props.returnUrl)
        }).catch(err => {
            console.log(err)
        })
    }
    const handleChange = (name: string, value: string | number) => {
        setData({ ...data, [name]: value })
    }
    if (!props.data || !data) {
        return <div className="d-flex justify-content-center"><Spinner /></div>
    }
    return (
        <LoadingPanel loaded={props.data && data}>
            <div className='d-flex justify-content-center'>
                <h2>{props.title}</h2>
            </div>
            {"game" in Object.keys(props.data?props.data:{}) &&
                <div className='d-flex justify-content-center'>
                    <h2>{props.data?.game.name}</h2>
                </div>
            }
            <div className="d-flex justify-content-between mb-2">
                <Link to={props.returnUrl}>
                    <Button variant="outline-secondary">
                        <FontAwesomeIcon icon={faAngleLeft} className="me-1" />
                        Back
                    </Button>
                </Link>
                <div>
                    <Button variant="outline-dark" className='me-2' onClick={() => {
                        handleBtnSaveClick()

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
                {Object.keys(props.schema.properties).map((item, index) => <div key={`item_prop_${index}`}><Property
                    name={item}
                    label={props.schema.properties[item]["title"]}
                    type={props.schema.properties[item]["type"]}
                    options={props.options[item]}
                    onChange={handleChange}
                    value={data[item]}
                /></div>)}
            </div>

        </LoadingPanel>
    )
}