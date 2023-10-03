import { LogicDeleteEntity } from "./base-entity";

/*
Come devo suddividere lo stipendio fra le varie tipologie di spese
*/
export interface EarningSuddivision extends LogicDeleteEntity {
    idUser: string
    percentage: number
    name: string
    description?: string
}