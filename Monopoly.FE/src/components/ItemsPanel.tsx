import { faAngleLeft, faPlus } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button, Spinner, Table } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import { ISchema } from '../schemas/Schemas'
import { IPaginationAction, IPaginationState } from '../store/reducers/PaginationReducer'
import { PaginationPanel } from './PaginationPanel'

interface Props {
    title: string
    url?: string
    paginationState: IPaginationState
    paginationDispatch: React.Dispatch<IPaginationAction>
    schema: ISchema
    data?: Array<any>
}

export const ItemsPanel = (props: Props) => {
    return (<>
        <div className="d-flex justify-content-center">
            <h2>{props.title}</h2>
        </div>
        <div className={`d-flex ${props.url ? "justify-content-between" : "justify-content-end"}`}>
            {props.url && <Link to="/">
                <Button variant="outline-secondary" className='mb-2'>
                    <FontAwesomeIcon icon={faAngleLeft} className="me-1" />
                    Back
                </Button>
            </Link>}

            <Link to={`/${props.url}/create`}>
                <Button variant="outline-dark" className='mb-2'>
                    <FontAwesomeIcon icon={faPlus} className="me-1" />
                    New {props.title}
                </Button>
            </Link>
        </div>
        {props.data ? <>
            <div className="border rounded p-1 mb-3">
                <Table bordered striped responsive >
                    <thead>
                        <tr>
                            {
                                Object.keys(props.schema.properties).map(item => {
                                    return <th>{props.schema.properties[item]["title"]}</th>
                                })
                            }
                        </tr>
                    </thead>
                    <tbody>
                        {
                            props.data.map(item => {
                                return <tr>
                                    {props.schema.required.map(key => {
                                        return <td>{item[key]}</td>
                                    })}
                                </tr>
                            })
                        }
                    </tbody>
                </Table>
            </div>
            <PaginationPanel label={`{props.title} per page`}
            page={props.paginationState.page}
            perPage={props.paginationState.perPage}
            perPageOptions={props.paginationState.perPageOptions}
            total={30}
            dispatch={props.paginationDispatch}
        />
        </> : <div className="d-flex justify-content-center">
            <Spinner />
        </div>
        }
    </>)
}