import { faAngleLeft, faPlus, faTrashCan } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button, Spinner, Table } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import { ISchema } from '../schemas/Schemas'
import { createNotification } from '../store/actions/NotificationsActions'
import { GlobalContext } from '../store/GlobalContextProvider'
import { IPaginationAction, IPaginationState } from '../store/reducers/PaginationReducer'
import { DeleteModal } from './DeleteModel'
import { PaginationPanel } from './PaginationPanel'

interface Props {
    title: string
    url?: string
    apiUrl?: string
    paginationState: IPaginationState
    paginationDispatch: React.Dispatch<IPaginationAction>
    schema: ISchema
    data?: Array<any>
    reload: ()=>void
}

export const ItemsPanel = (props: Props) => {
    const { gameState, notificationsDispatch } = React.useContext(GlobalContext)

    const [selectedItem, setSelectedItem] = React.useState<any>()
    const [isShowModal, setIsShowModal] = React.useState<boolean>(false)

    const handleBtnDeleteClick = () => {

        fetch(`${props.apiUrl}/${selectedItem.id}`, {
            method: "DELETE"
        }).then( data => {
            if(!data.ok){
                throw new Error()
            }
            //todo ok alert
            props.reload()
            setSelectedItem(undefined)
            createNotification(notificationsDispatch, "Success", "", "success", 3000)

        }).catch(err => {
            // console.log(err)
            setSelectedItem(undefined)
            createNotification(notificationsDispatch, "Error", "", "danger")
        })
    }

    return (<>
    <DeleteModal title={`Delete`} onBtnDeleteClick={handleBtnDeleteClick} onBtnCloseClick={()=>{setIsShowModal(false)}} isShow={isShowModal} />
        <div className="d-flex flex-column align-items-center">
            <h2>{props.title}</h2>
            {!props.title.includes("type") && <h4 className='text-secondary font-monospace'>{gameState.game?.name}</h4>}
        </div>
        <div className={`d-flex mb-2 ${props.url ? "justify-content-between" : "justify-content-end"}`}>
            {props.url && <Link to="/">
                <Button variant="outline-secondary" className=''>
                    <FontAwesomeIcon icon={faAngleLeft} className="me-1" />
                    Back
                </Button>
            </Link>}
            <div className='d-flex align-items-stretch'>
                {
                    selectedItem && <>
                        <Link to={`/${props.url}/clone/${selectedItem.id}`}>
                            <Button variant="outline-secondary" className='me-2'>
                                <FontAwesomeIcon icon={faPlus} className="me-1" />
                                Clone
                            </Button>
                        </Link>
                        <Link to={`/${props.url}/edit/${selectedItem.id}`}>
                            <Button variant="outline-success" className='me-2'>
                                <FontAwesomeIcon icon={faPlus} className="me-1" />
                                Edit
                            </Button>
                        </Link>
                        <Button variant="outline-danger" className='me-2'
                        onClick={()=>{setIsShowModal(true)}}>
                            <FontAwesomeIcon icon={faTrashCan} className="me-1" />
                            Delete
                        </Button>
                        <div className='border me-2'> </div>
                    </>
                }
                <Link to={`/${props.url}/create`}>
                    <Button variant="outline-dark" className=''>
                        <FontAwesomeIcon icon={faPlus} className="me-1" />
                        New
                    </Button>
                </Link>
            </div>
        </div>
        {props.data ? <>
            {props.data.length > 0 ? <>
                <div className="border rounded p-1 mb-3">
                    <Table bordered striped responsive hover>
                        <thead>
                            <tr>
                                <th>Id</th>
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
                                    return <tr key={`item_panel_tr_${props.title}_${index}`}
                                        onClick={() => { setSelectedItem(item) }}
                                        className={`cursor-pointer ${selectedItem?.id === item.id ? "bg-selected" : ""}`}
                                    >
                                        <td className={`cursor-pointer ${selectedItem?.id === item.id?"bg-selected":""}`} >{props.paginationState.perPage * props.paginationState.page + index + 1}</td>
                                        {Object.keys(props.schema.properties).map((key, index) => {

                                            if (props.schema.properties[key]["visible"]) {
                                                return <td key={`item_panel_td_${props.title}_${index}`} className={`cursor-pointer ${selectedItem?.id === item.id ? "bg-selected" : ""}`}>
                                                    {typeof item[key] === "object" ? (Object.keys(item[key]).includes("name") ? item[key]["name"] : "undefiend name") : item[key]}
                                                </td>
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
                : <div className='d-flex justify-content-center p-3 border rounded bg-light'><h3 className='text-secondary font-monospace'>No {props.title}</h3></div>}
        </> : <div className="d-flex justify-content-center">
            <Spinner />
        </div>
        }
    </>)
}