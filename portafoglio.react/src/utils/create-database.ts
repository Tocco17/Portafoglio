import { BaseEntity } from "../models/entities/base-entity";
import { Earning } from "../models/entities/earning";
import { EarningSuddivision } from "../models/entities/earning-suddivision";
import { Label } from "../models/entities/label";
import { User } from "../models/entities/user";
import { Wallet } from "../models/entities/wallet";
import { DatabaseKey, insertNewDataList } from "./simil-axios-storage";
import { clearStorage } from "./storage";

const userDb: User[] = [
	{ id: 1, username: 'tocco', password: '123Stella', isActive: true }
]

const earningSuddivisionDb: EarningSuddivision[] = [
	{ id: 1, idUser: 1, isActive: true, name: 'Necessaries', percentage: 50, description: 'All the needed payments' },
	{ id: 2, idUser: 1, isActive: true, name: 'Fun', percentage: 30, description: 'Fun payments' },
	{ id: 3, idUser: 1, isActive: true, name: 'Savings', percentage: 20, description: 'Money saved' },
]

const earningDb: Earning[] = [
	{ id: 1, idUser: 1, value: 150000, date: new Date(2023, 0, 1) },
]

const labelDb: Label[] = [
	{ id: 1, isActive: true, idEarningSuddivision: 1, name: 'Generic necessity' },
	{ id: 2, isActive: true, idEarningSuddivision: 2, name: 'Generic Fun' },
	{ id: 3, isActive: true, idEarningSuddivision: 3, name: 'Generic Saving' },
]

const walletDb: Wallet[] = [
	{ id: 1, isActive: true, idUser: 1, lastUpdate: new Date(2023, 0, 1), money: 150000, name: 'Conto', description: 'Generic conto' },
]

export interface DbKeyValue {
	key: DatabaseKey,
	datas: BaseEntity[]
}

const database: DbKeyValue[] = [
	{ key: DatabaseKey.user, datas: userDb },
	{ key: DatabaseKey.earningSuddivision, datas: earningSuddivisionDb },
	{ key: DatabaseKey.earning, datas: earningDb },
	{ key: DatabaseKey.label, datas: labelDb },
	{ key: DatabaseKey.wallet, datas: walletDb },
]

export const createDb = () => {
	clearStorage()

	database.map(table => insertNewDataList(table.key, table.datas))
}