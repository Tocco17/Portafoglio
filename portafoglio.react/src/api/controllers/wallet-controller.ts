import { Wallet } from "../../models/entities/wallet"
import { DatabaseKey } from "../../utils/simil-axios-storage"
import { readFromStorage } from "../../utils/storage"

export const getWallets = async () => {
	const wallets = readFromStorage(DatabaseKey.wallet) as Wallet[]
	return wallets
}