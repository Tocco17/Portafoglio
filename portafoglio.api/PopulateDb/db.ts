import {User} from './entities/user'
import {EarningSuddivision} from './entities/earning-suddivision'
import {Earning} from './entities/earning'
import {Label} from './entities/label'
import {Wallet} from './entities/wallet'

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