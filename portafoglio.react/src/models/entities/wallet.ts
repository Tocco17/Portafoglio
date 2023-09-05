import { LogicDeleteEntity } from "./base-entity";

export interface Wallet extends LogicDeleteEntity {
	idUser: number
	name: string
	description?: string

	money: number
	lastUpdate: Date
}