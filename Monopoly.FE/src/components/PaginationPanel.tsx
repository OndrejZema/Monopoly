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

    const [pages, setPages] = React.useState<Array<number>>([]);
    const [pagesCount, setPagesCount] = React.useState<number>(Math.ceil(props.state.totalCount / props.state.perPage))

    React.useEffect(() => {
        let temp = []
        let start: number = 0;
        let end: number = 0;
        let leftEllipsis = false
        let rightEllipsis = false
        if (pagesCount > 7) {
            if (props.state.page - 3 <= 0) {
                start = 0
                end = 6 + 1
                rightEllipsis = true
            }
            else if (props.state.page + 3 >= pagesCount - 1) {
                start = pagesCount - 1 - 6
                end = pagesCount
                leftEllipsis = true
            }
            else {
                start = props.state.page - 3
                end = props.state.page + 3 + 1
                rightEllipsis = true
                leftEllipsis = true
            }

            leftEllipsis && temp.push(-1)
            for (let i = start; i < end; i++) { temp.push(i) }
            rightEllipsis && temp.push(-1)
        } else {
            for (let i = 0; i < pagesCount; i++) { temp.push(i) }
        }

        setPages([...temp]);
    }, [props])

    return (
        <div className="border rounded p-2 mb-3">
            <Container>
                <Row>
                    <Col className="d-flex align-items-center">
                        <div>
                            <Form.Label>{props.label}</Form.Label>
                            <Select 
                            options={(props.state.perPageOptions.map(item => {return{label: item, value: item}}) as Array<any>)} 
                            value={{label: props.state.perPage, value: props.state.perPage}} 
                            onChange={e => setPerPage(props.dispatch, e?.value ? e.value : 10)} />
                        </div>
                    </Col>
                    <Col className="d-flex align-items-center">
                        <p className="text-center">{props.state.perPage * props.state.page} - {props.state.perPage * props.state.page + props.state.perPage} of {props.state.totalCount}</p>
                    </Col>
                    <Col className="d-flex align-items-center">
                        {pages.length > 1 && <>
                            <Pagination>
                                <Pagination.First disabled={props.state.page === 0} onClick={() => { setPage(props.dispatch, 0) }} />
                                <Pagination.Prev disabled={props.state.page === 0} onClick={() => { setPage(props.dispatch, props.state.page - 1) }} />

                                {pages.map((item: number, index: number) => <span key={item + " span " + index}>
                                    {
                                        item === props.state.page ?
                                            <Pagination.Item active key={item + " item " + index}>{item}</Pagination.Item> :
                                            item === -1 ?
                                                <Pagination.Ellipsis key={item + " ellipsis " + index} /> :
                                                <Pagination.Item key={item + " item " + index} onClick={() => setPage(props.dispatch, item)}>{item}</Pagination.Item>}
                                </span>
                                )}

                                <Pagination.Next disabled={props.state.page + 1 >= pagesCount} onClick={() => { setPage(props.dispatch, props.state.page + 1) }} />
                                <Pagination.Last disabled={props.state.page + 1 >= pagesCount} onClick={() => { setPage(props.dispatch, pagesCount - 1) }} />
                            </Pagination>
                        </>
                        }
                    </Col>
                </Row>
            </Container>
        </div>

    )
}