export interface BaseEntity {
    id?: string
}

export interface LogicDeleteEntity extends BaseEntity {
    isActive: boolean
}