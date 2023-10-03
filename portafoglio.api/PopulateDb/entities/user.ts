import { LogicDeleteEntity } from "./base-entity"

export interface User extends LogicDeleteEntity {
    username: string
    password: string
}