import { BaseEntity } from "./base-entity";

export interface Transaction extends BaseEntity {
    idLabel: number
    idWallet: number

    description: string
    value: number
    date: Date
}