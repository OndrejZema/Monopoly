import { faPlus } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import React from 'react'
import { Button, Table } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import { PaginationPanel } from '../../components/PaginationPanel'


export const FieldTypes = () => {
    return (<>
        <div className="d-flex justify-content-center">
            <h2>Field types</h2>
        </div>
        <div className="d-flex justify-content-end">
            <Link to="/field-types/create">
                <Button variant="outline-dark" className='mb-2'>
                    <FontAwesomeIcon icon={faPlus} className="me-1" />
                    New field type
                </Button>
            </Link>
        </div>
        <div className="border rounded p-1 mb-3">
            <Table bordered striped responsive >
                <thead>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            Name
                        </th>
                        <th>
                            Description
                        </th>

                    </tr>
                </thead>
                <tbody>

                </tbody>
            </Table>
        </div>
        <PaginationPanel label="Fields per page" page={0} perPage={10} perPageOptions={[1, 2, 4]} total={30} />
    </>)
}