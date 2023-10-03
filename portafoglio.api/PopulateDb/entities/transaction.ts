import { BaseEntity } from "./base-entity";

export interface Transaction extends BaseEntity {
    idLabel: string
    idWallet: string

    description: string
    value: number
    date: Date
}