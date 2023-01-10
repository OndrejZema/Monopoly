import React from 'react'
import { Col, Container, Pagination, Row } from 'react-bootstrap'
import Select from 'react-select'
import { IPaginationAction } from '../store/reducers/PaginationReducer'

interface Props {
    page: number
    perPage: number
    perPageOptions: Array<number>
    total: number
    label: string
    dispatch: React.Dispatch<IPaginationAction>
}

export const PaginationPanel = (props: Props) => {

    const [buttons, setButtons] = React.useState<Array<number>>([1, -1, 4, 5, 6, 7, -1, 10])
    React.useEffect(() => {

    }, [])
    return (
        <div className="border rounded p-2 mb-2">
            <Container>
                <Row md="1" lg="2" xl="2" className='justify-content-between'>
                    <Col md={3} lg={3} xl={3}>
                        <span>{props.label}</span>
                        <Select options={props.perPageOptions} />
                    </Col>
                    <Col md={9} lg={9} xl={9} className="d-flex justify-content-end align-items-end">
                        <Pagination>
                            <Pagination.First />
                            <Pagination.Prev />
                            {buttons.map(item => {
                                if (item === -1){
                                    return <Pagination.Ellipsis />
                                }
                                return <Pagination.Item>{item}</Pagination.Item>
                            })}
                            <Pagination.Next />
                            <Pagination.Last />
                        </Pagination>
                    </Col>
                </Row>
            </Container>
        </div>
    )
}