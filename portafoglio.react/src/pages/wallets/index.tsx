import { Form, Link, LoaderFunctionArgs, NavLink, Outlet, useLoaderData } from "react-router-dom"
import { getWallets } from "../../api/controllers/wallet-controller"
import { Wallet } from "../../models/entities/wallet"
import { Box, Button, Input, InputLabel } from "@mui/material"

interface WalletLoaderData {
	wallets: Wallet[] | undefined
	q: string | undefined
}

export const walletsLoader = async ({ request }: LoaderFunctionArgs) => {
	const url = new URL(request.url)
	const q = url.searchParams.get("q") as string | undefined
	const wallets = await getWallets({name: q})

	const walletLoaderData: WalletLoaderData = {
		wallets,
		q
	}
	return walletLoaderData
}

export const Wallets = () => {
	const {wallets, q} = useLoaderData() as WalletLoaderData

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
					height: 'inherit',
					display: 'flex',
					flexDirection: 'column',
					alignItems: 'center',
				}}>
					<Box sx={{
						width: '100%',
						display: 'flex',
						flexDirection: 'row',
						justifyContent: 'space-between',
					}}>
						<Form role="search">
							<InputLabel htmlFor="search-wallet-input" >Search</InputLabel>
							<Input id="search-wallet-input" type="search" name="q" defaultValue={q} />
						</Form>

						<Form action="new">
							<Button type="submit">New</Button>
						</Form>
					</Box>

					<nav>
						{wallets?.map((wallet, index) => (
							<li key={`wallet-${index}-${wallet.name}`}>
								<NavLink to={`${wallet.id ?? '/'}`}>{wallet.name}</NavLink>
							</li>
						))}
					</nav>
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