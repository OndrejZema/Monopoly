export interface ISchema {
    type: string
    title: string
    properties: any
}

export const GameSchema = {
    type: "object",
    title: "Game",
    properties: {
        "name": {
            type: "string",
            title: "Name"
        },
        "description": {
            type: "string",
            title: "Description"
        }
    },
    required: ["name", "description"]
}
export const CardTypeSchema = {
    type: "object",
    title: "Card type",
    properties: {
        "name": {
            type: "string",
            title: "Name"
        },
        "description": {
            type: "string",
            title: "Description"
        }
    },
    required: ["name", "description"]
}
export const FieldTypeSchema = {
    type: "object",
    title: "Field type",
    properties: {
        "name": {
            type: "string",
            title: "Name"
        },
        "description": {
            type: "string",
            title: "Description"
        }
    },
    required: ["name", "description"]
}
export const emptyFieldType = {
    name: "",
    description: ""
}
export const emptyCardType = {
    name: "",
    description: ""
}
export const emptyGame = {
    name: "",
    description: ""
}

