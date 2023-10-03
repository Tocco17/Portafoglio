import { LoggedUser } from "../../models/dtos/logged-user"
import { Wallet } from "../../models/entities/wallet"
import { WalletFilter } from "../../models/filters/wallet.filter"
import { CreateWalletRequest, EditWalletRequest } from "../../models/requests/wallet-request"
import { StorageKey, getAuthFromStorage, readFromStorage, writeToStorage } from "../../utils/storage"
import { getApi, postApi, putApi } from "../axios/calls"

export const createWallet = async (request: CreateWalletRequest) => {
	const auth = getAuthFromStorage()

	const data = new Date().toUTCString()

	const idUser = auth.idUser
	const wallet: Wallet = {
		idUser: idUser,
		isActive: true,
		money: request.money,
		name: request.name,
		description: request.description,
		lastUpdate: new Date(data),
	}

	const response = await postApi<string>({
		url: 'Wallet',
		data: wallet,
	})

	return response.data
}
export const getWallets = async (filter?: WalletFilter) => {
	const auth = getAuthFromStorage()
	const walletFilter = filter ?? {} as WalletFilter
	walletFilter.idUser = auth.idUser

	const response = await getApi<Wallet[]>({
		controller: 'Wallet',
		params: walletFilter
	})
	
	return response.data
}

export const getWallet = async (idWallet: string) => {
	const response = await getApi<Wallet>({
		controller: `Wallet/${idWallet}`
	})

	return response.data
}

export const editWallet = async (request: EditWalletRequest) => {
	const auth = getAuthFromStorage()
	
	const wallet: Wallet = {
		id: request.id,
		idUser: auth.idUser,
		money: request.money,
		description: request.description,
		name: request.name,
		isActive: true,
		lastUpdate: new Date()
	}

	const response = await putApi<number>({
		url: 'Wallet',
		data: wallet,
	})

	return response.data
}