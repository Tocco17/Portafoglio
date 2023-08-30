import { BaseEntity } from "./base-entity";

/*
Per indicare l'ultimo stipendio ricevuto
*/
export interface Earning extends BaseEntity {
    idUser: number
    value: number
    date: Date
}