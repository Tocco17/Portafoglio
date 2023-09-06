import { Form, LoaderFunctionArgs, NavLink, Outlet, redirect, useLoaderData, useNavigate } from "react-router-dom"
import { getWallets } from "../../api/controllers/wallet-controller"
import { Wallet } from "../../models/entities/wallet"
import { Box, Button, Input, InputLabel, Link, List, ListItem, ListItemButton } from "@mui/material"
import { TextInput } from "../../components/forms/text-input"
import { route } from "../../contextes/route.context"
import './main.css'

interface WalletLoaderData {
	wallets: Wallet[] | undefined
	q: string | undefined
}

export const walletsLoader = async ({ request }: LoaderFunctionArgs) => {
	const url = new URL(request.url)
	const q = url.searchParams.get("q") as string | undefined
	const wallets = await getWallets({ name: q })

	const walletLoaderData: WalletLoaderData = {
		wallets,
		q
	}
	return walletLoaderData
}

export const Wallets = () => {
	const { wallets, q } = useLoaderData() as WalletLoaderData
	const navigate = useNavigate()

	const handleNavBarClick = (wallet: Wallet) => {
		// return () => navigate(`${wallet.id ?? '/'}`)
		return () => true
	}

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
					alignItems: 'start',
					gap: '15px',
					
					borderRadius: '20px',
					paddingX: '15px',
					paddingY: '20px',

					boxShadow: `5px 5px 20px rgba(0, 0, 0, 0.25),
					10px 10px 70px rgba(0, 0, 0, 0.25),
					inset 3px 3px 5px rgba(0, 0, 0, 0.25),
					inset 5px 5px 20px rgba(255, 255, 255, 0.2),
					inset -3px -3px 10px rgba(0, 0, 0, 0.25)`

				}}>
					<Box sx={{
						width: '100%',
						display: 'flex',
						flexDirection: 'row',
						justifyContent: 'space-between',


					}}>
						<Form role="search">
							<TextInput id="search-wallet-input" name="q" defaultValue={q} type="search" placeholder="Search" />
						</Form>

						<Form action="new">
							<Box sx={{
								display: 'flex',
								justifyContent: 'center',
								alignItems: 'center',
								width: '100%',
								height: '100%',
							}}>
								<Button type="submit">New</Button>
							</Box>
						</Form>
					</Box>

					<nav className="nav-wallet-list">
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