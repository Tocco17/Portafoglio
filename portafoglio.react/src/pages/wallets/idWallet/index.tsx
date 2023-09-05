import { Form, LoaderFunctionArgs, Route, redirect, useLoaderData } from "react-router-dom"
import { route } from "../../../contextes/route.context"
import { getWallet } from "../../../api/controllers/wallet-controller"
import { Wallet } from "../../../models/entities/wallet"
import { Box, Button } from "@mui/material"
import { Close } from "../../../components/elements/close"

export const walletPageLoader = async ({ params }: LoaderFunctionArgs) => {
	const idWallet = params.idWallet as number | undefined

	if (!idWallet) return redirect(route.wallets)

	const wallet = await getWallet(idWallet)

	return wallet
}

export const WalletPage = () => {
	const wallet = useLoaderData() as Wallet

	return (
		<>
			<Box sx={{
				flexGrow: 1,
				
				display: 'flex',
				flexDirection: 'column',
				justifyContent: 'start',
				gap: '50px',
			}}>
				<Box sx={{
					alignSelf: 'end'
				}}>
					<Close action={route.wallets} />
				</Box>
				
				<h1>Wallet page</h1>

				<Box sx={{
					display: 'flex',
					flexDirection: 'column',
					justifyContent: 'start',
					gap: '10px',
				}}>
					<div>{wallet?.name}</div>
					<div>{wallet?.description}</div>
				</Box>
			</Box>
		</>
	)
}