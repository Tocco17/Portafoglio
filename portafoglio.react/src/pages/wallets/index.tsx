import { Outlet, useLoaderData } from "react-router-dom"
import { getWallets } from "../../api/controllers/wallet-controller"
import { Wallet } from "../../models/entities/wallet"
import { Box } from "@mui/material"

export const walletsLoader = async () => {
	const wallets = await getWallets()
	return wallets
}

export const Wallets = () => {
	const wallets = useLoaderData() as Wallet[]

	return (
		<>
			<Box sx={{
				height: '100%',
				width: '100%',
				
				display: 'flex',
				flexDirection: 'row',
				justifyContent: 'center',
			}}>
				<Box sx={{
					width: 'calc(100%/3)',
					height: 'inherit'
				}}>

					<ul>
						{wallets.map((wallet, index) => (
							<li key={`wallet-${index}`}>{wallet.name}</li>
						))}
					</ul>
				</Box>

				<Outlet />
			</Box>
		</>
	)
}

/*
TODO - WALLET
L'idea da implementare:

Pagina 'wallets'
	Cosa si vede:
		Lista di wallet
		Barra di ricerca per filtrare i wallet
		Bottone New wallet
	Azioni
		Filtrare la lista -> va alla pagina 'wallets?q=[ricerca]'
		Cliccare su un wallet -> va alla pagina 'wallets/[idWallet]'
		Creare un nuovo bottone -> va alla pagina 'wallets/new'

Pagina 'wallets/[idWallet]'
	Cosa si vede
		Barra laterale uguale alla pagina 'wallets' con anche le stesse azioni disponibili
		Tutti i dettagli del wallet selezionato
		Se non è disponibile pagina di errore
		
Pagina 'wallets/new'
	Cosa si vede
		Barra laterale uguale alla pagina 'wallets' con anche le stesse azioni disponibili
		Form per creare un nuovo wallet

		

*/