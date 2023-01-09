export interface ISchema {
    type: string
    title: string
    properties: any
}

export const GameSchema = {
    type: "object",
    title: "Game",
    properties: {
        name: {
            type: "string",
            title: "Name"
        },
        description: {
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
        name: {
            type: "string",
            title: "Name"
        },
        description: {
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
        name: {
            type: "string",
            title: "Name"
        },
        description: {
            type: "string",
            title: "Description"
        }
    },
    required: ["name", "description"]
}

export const CardSchema = {
    type: "object",
    title: "Card",
    properties: {
        name: {
            type: "string",
            title: "Name"
        },
        description: {
            type: "string",
            title: "Description"
        },
        type: {
            type: "array",
            title: "Card type",
            items: {
                type: "object",
                properties: {
                    id: {
                        type: "number",
                        title: "Id"
                    },
                    name: {
                        type: "string",
                        title: "Name"
                    },
                    description: {
                        type: "string",
                        title: "Description"
                    }
                }
            }
        }
    },
    required: ["name", "description", "type"]
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
export const emptyCard = {
    name: "",
    description: "",
    type: 0,
    typeOptions: [{label: "", value: 1}]
}

