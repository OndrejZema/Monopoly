import React from 'react'
import { Col, Container, Form, Pagination, Row } from 'react-bootstrap'
import Select from 'react-select'
import { setPage, setPerPage } from '../store/actions/PaginationActions'
import { IPaginationAction, IPaginationState } from '../store/reducers/PaginationReducer'

interface Props {
    label: string
    state: IPaginationState
    dispatch: React.Dispatch<IPaginationAction>
}

export const PaginationPanel = (props: Props) => {
    const [pagesCount, setPagesCount] = React.useState(Math.ceil(props.state.totalCount / props.state.perPage))
    React.useEffect(() => {
        if (Math.ceil(props.state.totalCount / props.state.perPage) !== pagesCount) {
            setPagesCount(Math.ceil(props.state.totalCount / props.state.perPage))
        }
    })
    return (
        <div className="border rounded p-2 mb-3">
            <Container>
                <Row>
                    <Col className="d-flex align-items-center">
                        <div>
                            <Form.Label>{props.label}</Form.Label>
                            <Select
                                options={(props.state.perPageOptions.map(item => { return { label: item, value: item } }) as Array<any>)}
                                value={{ label: props.state.perPage, value: props.state.perPage }}
                                onChange={e => setPerPage(props.dispatch, e?.value ? e.value : 10)} />
                        </div>
                    </Col>
                    <Col className="d-flex align-items-center">
                        <p className="text-center">{props.state.perPage * props.state.page} - {props.state.perPage * props.state.page + props.state.perPage} of {props.state.totalCount}</p>
                    </Col>
                    <Col className="d-flex align-items-center">
                        <Pagination>
                            <Pagination.Prev disabled={props.state.page === 0} onClick={() => { setPage(props.dispatch, props.state.page - 1) }} />
                            <div className='p-2'>{props.state.page}</div>
                            <Pagination.Next disabled={props.state.page + 1 >= pagesCount} onClick={() => { setPage(props.dispatch, props.state.page + 1) }} />
                        </Pagination>
                    </Col>
                </Row>
            </Container>
        </div>

    )
}