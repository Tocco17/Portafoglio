import { LoggedUser } from "../../models/dtos/logged-user"
import { Wallet } from "../../models/entities/wallet"
import { DatabaseKey, getById, insertNewData,  } from "../../utils/simil-axios-storage"
import { StorageKey, readFromStorage } from "../../utils/storage"

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

export const getWallets = async () => {
	const wallets = readFromStorage(DatabaseKey.wallet) as Wallet[]
	return wallets
}

export const getWallet = async (idWallet: number) => {
	const wallet = getById(DatabaseKey.wallet, idWallet) as Wallet | undefined
	if(!wallet) throw new Error('Wallet not found.')
	return wallet
}