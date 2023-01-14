import { faAngleLeft, faPlus } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button, Spinner, Table } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import { ISchema } from '../schemas/Schemas'
import { GlobalContext } from '../store/GlobalContextProvider'
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
    const {gameState} = React.useContext(GlobalContext)
    return (<>
        <div className="d-flex flex-column align-items-center">
            <h2>{props.title}</h2>
            {!props.title.includes("type") && <h4 className='text-secondary font-monospace'>{gameState.game?.name}</h4>}
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
            { props.data.length > 0 ? <>
            <div className="border rounded p-1 mb-3">
                <Table bordered striped responsive >
                    <thead>
                        <tr>
                            {
                                Object.keys(props.schema.properties).map((item, index) => {
                                    return props.schema.properties[item]["visible"] && <th key={`item_panel_th_${props.title}_${index}`}>{props.schema.properties[item]["title"]}</th>
                                })
                            }
                        </tr>
                    </thead>
                    <tbody>
                        {
                            props.data.map((item, index) => {
                                return <tr key={`item_panel_tr_${props.title}_${index}`}>
                                    {Object.keys(props.schema.properties).map((key, index) => {

                                        if(props.schema.properties[key]["visible"]){
                                            return <td key={`item_panel_td_${props.title}_${index}`}>{typeof item[key] === "object"?(Object.keys(item[key]).includes("name")?item[key]["name"]:"undefiend name"):item[key]}</td>
                                        }
                                    })}
                                </tr>
                            })
                        }
                    </tbody>
                </Table>
            </div>
            <PaginationPanel label={`${props.title} per page`}
                state={props.paginationState}
                dispatch={props.paginationDispatch}
            />
            </>
           : <div className='d-flex justify-content-center p-3 border rounded bg-light'><h3 className='text-secondary font-monospace'>No {props.title}</h3></div> }
        </> : <div className="d-flex justify-content-center">
            <Spinner />
        </div>
        }
    </>)
}