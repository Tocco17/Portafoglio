import { Box, Button, FormControl, Input, InputLabel, } from "@mui/material"
import { ActionFunctionArgs, Form, redirect } from "react-router-dom"
import { route } from "../../contextes/route.context"
import { loginUser } from "../../api/controllers/user-controller"
import { LoggedUser } from "../../models/dtos/logged-user"
import { StorageKey, writeToStorage } from "../../utils/storage"

export const Login = () => {
	return (
		<>
			<h1>Login</h1>

			<Form method="post">
				<Box sx={{
					display: 'flex',
					flexDirection: "column",
					alignItems: 'start',
					justifyContent: 'center',
					width: '100vw',
					height: '100%',
					gap: '50px',
					marginLeft: '50px',
				}}>
					<FormControl>
						<InputLabel htmlFor="username-input" >Username</InputLabel>
						<Input id="username-input" name="username" />
					</FormControl>

					<FormControl>
						<InputLabel htmlFor="password-input">Password</InputLabel>
						<Input id="password-input" name="password" />
					</FormControl>

					<Button type="submit">Login</Button>
				</Box>
			</Form>
		</>
	)
}

export const loginSubmitAction = async ({ request }: ActionFunctionArgs) => {
	const formData = await request.formData()

	const username = formData.get("username") as string
	const password = formData.get("password") as string

	if (!username || !password) throw new Error('username or password not inserted.')

	const user = await loginUser(username, password)

	if (!user || !user?.id) throw new Error('User not found.')

	const loggedUser: LoggedUser = {
		idUser: user.id
	}

	writeToStorage(StorageKey.auth, loggedUser)

	return redirect(route.home)
}
