import { LogicDeleteEntity } from "./base-entity";

export interface Label extends LogicDeleteEntity {
	idEarningSuddivision: number
	name: string
	description?: string
	idFatherLabel?: number
}