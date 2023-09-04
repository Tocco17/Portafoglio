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