import { ActionFunctionArgs, Form, LoaderFunctionArgs, redirect, useLoaderData } from "react-router-dom"
import { route } from "../../../../contextes/route.context"
import { editWallet, getWallet } from "../../../../api/controllers/wallet-controller"
import { Wallet } from "../../../../models/entities/wallet"
import { Box, Button, FormControl, Input, InputLabel } from "@mui/material"
import { CloseButton } from "../../../../components/elements/close-button"
import { EditWalletRequest } from "../../../../models/requests/edit-wallet.request"

export const editWalletLoader = async ({ params }: LoaderFunctionArgs) => {
	const idWallet = params.idWallet as number | undefined

	if (!idWallet) return redirect(route.wallets)

	const wallet = await getWallet(idWallet)

	return wallet
}

export const EditWallet = () => {
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
					<CloseButton action={route.wallets} />
				</Box>

				<h1>Edit</h1>

				<Form method="post">
					<Box sx={{
						display: 'flex',
						flexDirection: 'column',
						gap: '20px',
						alignItems: 'start',
						width: '100%'
					}}>

						<FormControl sx={{width: '100%'}}>
							<InputLabel htmlFor="name-edit-input" >Name</InputLabel>
							<Input id="name-edit-input" name="name" defaultValue={wallet.name} required />
						</FormControl>

						<FormControl sx={{width: '100%'}}>
							<InputLabel htmlFor="description-edit-input" >Description</InputLabel>
							<Input id="description-edit-input" name="description" defaultValue={wallet.description} />
						</FormControl>

						<Input name="id" defaultValue={wallet.id} sx={{display: 'none'}}/>

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
	const id = parseInt(formData.get("id") as string)

	const apiRequest: EditWalletRequest = {id, name, description}

	await editWallet(apiRequest)

	return redirect(`${route.wallets}/${id}`)
}