import { useLoaderData } from "react-router-dom"
import { getWallets } from "../../api/controllers/wallet-controller"
import { Wallet } from "../../models/entities/wallet"

export const walletsLoader = async () => {
	const wallets = await getWallets()
	return wallets
}

export const Wallets = () => {
	const wallets = useLoaderData() as Wallet[]
	
	return (
		<>
		<ul>
			{wallets.map((wallet, index) => (
				<li key={`wallet-${index}`}>{wallet.name}</li>
			))}
		</ul>
		</>
	)
}