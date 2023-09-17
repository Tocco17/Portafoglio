import { Box, Button, FormControl, FormGroup, FormLabel, Input, InputLabel, TextField } from "@mui/material"
import { ActionFunctionArgs, Form, redirect } from "react-router-dom"
import { StorageKey, readFromStorage } from "../../../utils/storage"
import { LoggedUser } from "../../../models/dtos/logged-user"
import { Wallet } from "../../../models/entities/wallet"
import { createWallet } from "../../../api/controllers/wallet-controller"
import { route } from "../../../contextes/route.context"
import { CloseButton } from "../../../components/elements/close-button"
import { TextInput } from "../../../components/forms/text-input"

export const NewWalletPage = () => {
	return (
		<>
			<Box sx={{
				flexGrow: 1,

				display: 'flex',
				flexDirection: 'column',
				gap: '20px',
				height: '100%'
			}}>
				{/* CLOSE */}
				<Box sx={{
					alignSelf: 'end'
				}}>
					<CloseButton action={route.wallets} />
				</Box>

				{/* FORM */}
				<Form method="post">
					<Box sx={{
						display: 'flex',
						flexDirection: 'column',
						gap: '20px',
						flexGrow: '1'
					}}>
						<TextInput id="wallet-name-input" name="name" required>Name</TextInput>

						<TextInput id="wallet-description-input" name="description">Description</TextInput>

						<TextInput id="wallet-money-input" name="money" type="number">Moneys</TextInput>

						<Button type="submit">Create</Button>
					</Box>
				</Form>
			</Box>
		</>
	)
}

export const newWalletPageAction = async ({ request }: ActionFunctionArgs) => {
	const formData = await request.formData()

	const name = formData.get("name") as string
	const description = formData.get("description") as string | undefined
	const money = parseFloat(formData.get("money") as string)

	const moneyInCents = Math.trunc(money * 100)

	if (!name) throw new Error("Name of the wallet not specified.")

	const newId = await createWallet({name, description, money: moneyInCents})

	return redirect(`${route.wallets}/${newId}`)
}