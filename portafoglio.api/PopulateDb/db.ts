import {User} from './entities/user'
import {EarningSuddivision} from './entities/earning-suddivision'
import {Earning} from './entities/earning'
import {Label} from './entities/label'
import {Wallet} from './entities/wallet'

const userDb: User[] = [
	{ id: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', username: 'tocco', password: '123Stella', isActive: true }
]

const earningSuddivisionDb: EarningSuddivision[] = [
	{ id: 'e73a0666-9e43-454a-ab46-d4e307a41229', idUser: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', isActive: true, name: 'Necessaries', percentage: 50, description: 'All the needed payments' },
	{ id: '80ff698f-e04f-440a-a921-8e269cf344d3', idUser: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', isActive: true, name: 'Fun', percentage: 30, description: 'Fun payments' },
	{ id: 'c7b15351-ecb7-491b-aecd-50fba72c8e8a', idUser: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', isActive: true, name: 'Savings', percentage: 20, description: 'Money saved' },
]

const earningDb: Earning[] = [
	{ id: '778eae00-9c35-4bfe-bbbf-4141cc1a9a7c', idUser: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', value: 150000, date: new Date(2023, 0, 1) },
]

const labelDb: Label[] = [
	{ id: '36d56040-eaed-49fc-a195-448dd4a7fcca', isActive: true, idEarningSuddivision: 'e73a0666-9e43-454a-ab46-d4e307a41229', name: 'Generic necessity' },
	{ id: 'ffc957c5-0abe-45c9-b81d-0bbf97e0de0b', isActive: true, idEarningSuddivision: '80ff698f-e04f-440a-a921-8e269cf344d3', name: 'Generic Fun' },
	{ id: '9822fafb-eacd-4a73-9340-905ac811abea', isActive: true, idEarningSuddivision: 'c7b15351-ecb7-491b-aecd-50fba72c8e8a', name: 'Generic Saving' },
]

const walletDb: Wallet[] = [
	{ id: '2ee94876-086f-4f69-af62-6fd1cb1817c3', isActive: true, idUser: 'd6e53c84-40dd-43d7-b7c8-a459be6337ca', lastUpdate: new Date(2023, 0, 1), money: 150000, name: 'Conto', description: 'Generic conto' },
]