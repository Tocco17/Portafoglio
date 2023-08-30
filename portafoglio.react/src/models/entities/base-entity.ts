export interface BaseEntity {
    id?: number
}

export interface LogicDeleteEntity extends BaseEntity {
    isActive: boolean
}