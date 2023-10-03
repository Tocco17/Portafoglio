import { ActionFunctionArgs, Form, LoaderFunctionArgs, redirect, useLoaderData } from "react-router-dom"
import { route } from "../../../../contextes/route.context"
import { editWallet, getWallet } from "../../../../api/controllers/wallet-controller"
import { Wallet } from "../../../../models/entities/wallet"
import { Box, Button, FormControl, Input, InputLabel } from "@mui/material"
import { CloseButton } from "../../../../components/elements/close-button"
import { TextInput } from "../../../../components/forms/text-input"
import { MoneyInput } from "../../../../components/forms/money-input"

export const editWalletLoader = async ({ params }: LoaderFunctionArgs) => {
	const idWallet = params.idWallet as string | undefined

	if (!idWallet) return redirect(route.wallets)

	const wallet = await getWallet(idWallet)

	return wallet
}

export const EditWallet = () => {
	const wallet = useLoaderData() as Wallet

	const moneyInString = `${wallet.money / 100}`

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
					// alignSelf: 'end',

					display: 'flex',
					flexDirection: 'row',
					justifyContent: 'space-between',
					alignItems: 'center'
				}}>
					<h1>{wallet?.name}</h1>
					<CloseButton action={route.wallets} />
				</Box>

				<Form method="post">
					<Box sx={{
						display: 'flex',
						flexDirection: 'column',
						gap: '20px',
						alignItems: 'start',
						width: '100%'
					}}>
						<TextInput id="wallet-name-input" name="name" required defaultValue={wallet.name}>Name</TextInput>

						<TextInput id="wallet-description-input" name="description" defaultValue={wallet.description}>Description</TextInput>

						<MoneyInput id="wallet-money-input" name="money" defaultValue={moneyInString}>Moneys</MoneyInput>

						<Input name="id" defaultValue={wallet.id} sx={{ display: 'none' }} />

						<Button type="submit">Edit</Button>
					</Box>
				</Form>
			</Box>
		</>
	)
}

export const editWalletAction = async ({ request }: ActionFunctionArgs) => {
	const formData = await request.formData()

	const name = formData.get("name") as string
	const description = formData.get("description") as string | undefined
	const money = parseFloat(formData.get("money") as string)
	const id = formData.get("id") as string

	const moneyInCents = Math.trunc(money * 100)

	await editWallet({ id, name, description, money: moneyInCents })

	return redirect(`${route.wallets}/${id}`)
}