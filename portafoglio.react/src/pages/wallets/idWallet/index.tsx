import { Form, Link, LoaderFunctionArgs, Route, redirect, useLoaderData } from "react-router-dom"
import { route } from "../../../contextes/route.context"
import { getWallet } from "../../../api/controllers/wallet-controller"
import { Wallet } from "../../../models/entities/wallet"
import { Box, Button } from "@mui/material"
import { CloseButton } from "../../../components/elements/close-button"
import { moneyToString } from "../../../utils/format"

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
				paddingX: '50px',
			}}>
				<Box sx={{
					display: 'flex',
					flexDirection: 'row',
					justifyContent: 'space-between',
					alignItems: 'center'
				}}>
					<h1>{wallet?.name}</h1>
					<CloseButton action={route.wallets} />
				</Box>


				<Box sx={{
					display: 'flex',
					flexDirection: 'column',
					justifyContent: 'start',
					gap: '10px',
				}}>
					<div>{wallet?.description}</div>
					<div>{moneyToString(wallet?.money)}</div>
				</Box>

				<Box sx={{
					display: 'flex',
					flexDirection: 'row',
					justifyContent: 'start',
					alignItems: 'center',
					gap: '10px',
				}}>
					<Link to={'edit'}>Edit</Link>
				</Box>
			</Box>
		</>
	)
}