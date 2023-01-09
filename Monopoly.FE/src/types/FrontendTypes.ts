export interface IProperty {
    label: string,
    type: string,
    name: string,
    options?: Array<IOption>
}
export interface IOption {
    value: string | number,
    label: string,
}