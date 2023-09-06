import { Form, Link, LoaderFunctionArgs, NavLink, Outlet, useLoaderData } from "react-router-dom"
import { getWallets } from "../../api/controllers/wallet-controller"
import { Wallet } from "../../models/entities/wallet"
import { Box, Button, Input, InputLabel } from "@mui/material"
import { TextInput } from "../../components/forms/text-input"

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
							<TextInput id="search-wallet-input" name="q" defaultValue={q} type="search">Search</TextInput>
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