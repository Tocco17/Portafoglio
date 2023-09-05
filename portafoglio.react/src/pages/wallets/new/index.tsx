import { Box, Button, FormControl, FormGroup, Input, InputLabel } from "@mui/material"
import { ActionFunctionArgs, Form, redirect } from "react-router-dom"
import { StorageKey, readFromStorage } from "../../../utils/storage"
import { LoggedUser } from "../../../models/dtos/logged-user"
import { Wallet } from "../../../models/entities/wallet"
import { createWallet } from "../../../api/controllers/wallet-controller"
import { route } from "../../../contextes/route.context"
import { Close } from "../../../components/elements/close"

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
				<Box sx={{
					alignSelf: 'end'
				}}>
					<Close action={route.wallets} />
				</Box>
				<Form method="post">
					<Box sx={{
						display: 'flex',
						flexDirection: 'column',
						gap: '20px',
						flexGrow: '1'
					}}>
						<FormControl>
							<InputLabel htmlFor="wallet-name-input" >Name</InputLabel>
							<Input id="wallet-name-input" name="name" required />
						</FormControl>
						<FormControl>
							<InputLabel htmlFor="wallet-description-input" >Description</InputLabel>
							<Input id="wallet-description-input" name="description" />
						</FormControl>

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

	if (!name) throw new Error("Name of the wallet not specified.")

	const newId = await createWallet(name, description)

	return redirect(`${route.wallets}/${newId}`)
}

/*
idUser: number
	name: string
	description?: string

	money: number
	lastUpdate: Date
*/