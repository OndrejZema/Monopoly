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
        }
    },
    required: ["name", "description"]
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
        types: {
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
    required: ["name", "description", "types", "games"]
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
        types: {
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
    required: ["name", "description", "types", "games"]
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
}
export const CardTypeSchema = {
    type: "object",
    title: "Card type",
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
}
export const FieldTypeSchema = {
    type: "object",
    title: "Field type",
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
}

export const CardSchema = {
    type: "object",
    title: "Card",
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
        },
        type: {
            type: "object",
            title: "Card type",
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
        game: {
            type: "object",
            title: "Game",
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
        }
    },
    required: ["name", "description", "types", "games"]
}
export const FieldSchema = {
    type: "object",
    title: "Field",
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
        },
        type: {
            type: "object",
            title: "Field type",
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

        game: {
            type: "object",
            title: "Game",
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
        }
    },
    required: ["name", "description", "type", "game"]
}

export const BanknoteSchema = {
    type: "object",
    title: "Banknote",
    properties: {
        id: {
            type: "number",
            title: "Id"
        },
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
        },
        game: {
            type: "object",
            title: "Game",
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
        }
    },
    required: ["id", "value", "count", "unit", "game"]
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
    complete: 1
}
export const emptyCard = {
    name: "",
    description: "",
    type: undefined,
    game: undefined
}
export const emptyField = {
    name: "",
    description: "",
    type: undefined,
    game: undefined
}
export const emptyBanknote = {
    value: 0,
    count: 0,
    unit: "",
    game: undefined

}

