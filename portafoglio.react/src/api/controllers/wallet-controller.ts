import { LoggedUser } from "../../models/dtos/logged-user"
import { Wallet } from "../../models/entities/wallet"
import { WalletFilter } from "../../models/filters/wallet.filter"
import { EditWalletRequest } from "../../models/requests/edit-wallet.request"
import { DatabaseKey, getById, getList, insertNewData,  } from "../../utils/simil-axios-storage"
import { StorageKey, readFromStorage, writeToStorage } from "../../utils/storage"

export const createWallet = async (name: string, description?: string) => {
	const auth = readFromStorage(StorageKey.auth) as LoggedUser
	if(!auth || !auth.idUser) throw new Error("Not logged in.")

	const data = new Date().toUTCString()

	const idUser = auth.idUser
	const wallet: Wallet = {
		idUser: idUser,
		isActive: true,
		money: 0,
		name: name,
		description: description,
		lastUpdate: new Date(data),
	}

	const walletCreated = insertNewData(DatabaseKey.wallet, wallet) as Wallet

	if(!walletCreated.id) throw new Error('Wallet not created.')
	
	return walletCreated.id
}

const filteredFunction = (database: Wallet[], filter?: WalletFilter) => {
	if(!filter) return database

	let dataFiltered = database.map(d => ({...d})) as Wallet[] | undefined

	if(!dataFiltered) return undefined

	if(!!filter.idUser) dataFiltered = dataFiltered.filter(d => d.idUser == filter.idUser)

	if(!!filter.name) dataFiltered = dataFiltered.filter(d => d.name.toLowerCase().includes(filter.name?.toLowerCase() ?? ''))

	return dataFiltered
}

export const getWallets = async (filter?: WalletFilter) => {
	const auth = readFromStorage(StorageKey.auth) as LoggedUser
	const userFilter = filter ?? {} as WalletFilter
	userFilter.idUser = auth.idUser

	const wallets = readFromStorage(DatabaseKey.wallet) as Wallet[]
	const walletsFiltered = filteredFunction(wallets, userFilter)
	
	return walletsFiltered
}

export const getWallet = async (idWallet: number) => {
	const wallet = getById(DatabaseKey.wallet, idWallet) as Wallet | undefined
	if(!wallet) throw new Error('Wallet not found.')
	return wallet
}

export const editWallet = async (request: EditWalletRequest) => {
	const database = readFromStorage(DatabaseKey.wallet) as Wallet[] | undefined

	if(!database || !database.length) return false

	const dataToEdit = database.find(d => d.id == request.id)
	const newDatabase = database.filter(d => d.id != request.id)

	if(!dataToEdit) return false

	const dataEdited: Wallet = {...dataToEdit, name: request.name, description: request.description}
	newDatabase.push(dataEdited)

	writeToStorage(DatabaseKey.wallet, newDatabase)
	
	return true
}