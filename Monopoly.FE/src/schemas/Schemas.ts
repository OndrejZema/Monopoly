export interface ISchema {
    type: string
    title: string
    properties: any
    required: Array<string>
}
//#region "Form schemas"
export const GameFormSchema = {
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
        },
        isCompleted: {
            type: "boolean",
            title: "Is completed"
        }
    },
    required: ["name", "description", "isCompleted"]
}
export const CardTypeFormSchema = {
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
export const FieldTypeFormSchema = {
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

export const CardFormSchema = {
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
                    value: {
                        type: "number",
                        title: "Id"
                    },
                    label: {
                        type: "string",
                        title: "Name"
                    },
                },
                required: ["value", "label"]
            }
        }
    },
    required: ["name", "description", "type", "games"]
}
export const FieldFormSchema = {
    type: "object",
    title: "Field",
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
            title: "Field type",
            items: {
                type: "object",
                properties: {
                    value: {
                        type: "number",
                        title: "Id"
                    },
                    label: {
                        type: "string",
                        title: "Name"
                    },
                },
                required: ["value", "label"]
            }
        }
    },
    required: ["name", "description", "type", "games"]
}

export const BanknoteFormSchema = {
    type: "object",
    title: "Banknote",
    properties: {
        value: {
            type: "number",
            title: "Value"
        },
        count: {
            type: "number",
            title: "Count"
        },
        unit: {
            type: "string",
            title: "Unit"
        }
    },
    required: ["value", "count", "unit", "games"]
}
//#endregion "Form schemas"
//#region "Data schemas"
export const GameSchema = {
    type: "object",
    title: "Game",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false,
        },
        name: {
            type: "string",
            title: "Name",
            visible: true,
        },
        description: {
            type: "string",
            title: "Description",
            visible: true,
        },
        isCompleted: {
            type: "boolean",
            title: "Is completed",
            visible: true,
        }
    },
    required: ["id", "name", "description", "isCompleted"]
}
export const CardTypeSchema = {
    type: "object",
    title: "Card type",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false,
        },
        name: {
            type: "string",
            title: "Name",
            visible: true,
        },
        description: {
            type: "string",
            title: "Description",
            visible: true,
        }
    },
    required: ["id", "name", "description"]
}
export const FieldTypeSchema = {
    type: "object",
    title: "Field type",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false,
        },
        name: {
            type: "string",
            title: "Name",
            visible: true,
        },
        description: {
            type: "string",
            title: "Description",
            visible: true,
        }
    },
    required: ["id", "name", "description"]
}

export const CardSchema = {
    type: "object",
    title: "Card",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false,
        },
        name: {
            type: "string",
            title: "Name",
            visible: true,
        },
        description: {
            type: "string",
            title: "Description",
            visible: true,
        },
        type: {
            type: "object",
            title: "Card type",
            visible: true,
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
            },
            required: ["id", "name", "description"]
        },
        gameId: {
            type: "number",
            title: "Game",
            visible: false,
        }
    },
    required: ["id", "name", "description", "type", "gameId"]
}
export const FieldSchema = {
    type: "object",
    title: "Field",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false
        },
        name: {
            type: "string",
            title: "Name",
            visible: true
        },
        description: {
            type: "string",
            title: "Description",
            visible: true
        },
        type: {
            type: "object",
            title: "Field type",
            visible: true,
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
            },
            required: ["id", "name", "description"]
        },

        gameId: {
            type: "number",
            title: "Game",
            visible: false
        }
    },
    required: ["id", "name", "description", "type", "gameId"]
}

export const BanknoteSchema = {
    type: "object",
    title: "Banknote",
    properties: {
        id: {
            type: "number",
            title: "Id",
            visible: false
        },
        value: {
            type: "number",
            title: "Value",
            visible: true
        },
        count: {
            type: "number",
            title: "Count",
            visible: true
        },
        unit: {
            type: "string",
            title: "Unit",
            visible: true
        },
        gameId: {
            type: "number",
            title: "Game",
            visible: false
        }
    },
    required: ["id", "value", "count", "unit", "gameId"]
}
//#endregion "Data schemas"

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
    description: "",
    isCompleted: false
}
export const emptyCard = {
    name: "",
    description: "",
    type: undefined,
    gameId: -1
}
export const emptyField = {
    name: "",
    description: "",
    type: undefined,
    gameId: -1
}
export const emptyBanknote = {
    value: 0,
    count: 0,
    unit: "",
    gameId: -1

}

