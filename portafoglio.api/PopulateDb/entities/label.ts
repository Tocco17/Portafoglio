import { LogicDeleteEntity } from "./base-entity";

export interface Label extends LogicDeleteEntity {
	idEarningSuddivision: string
	name: string
	description?: string
	idFatherLabel?: string
}