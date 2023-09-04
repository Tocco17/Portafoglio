import { Button, FormControl, Input, InputLabel, } from "@mui/material"
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
				<FormControl>
					<InputLabel htmlFor="username-input" >Username</InputLabel>
					<Input id="username-input" name="username"/>
				</FormControl>

				<FormControl>
					<InputLabel htmlFor="password-input">Password</InputLabel>
					<Input id="password-input" name="password"/>
				</FormControl>

				<Button type="submit">Login</Button>
			</Form>
		</>
	)
}

export const loginSubmitAction = async ({ params, request }: ActionFunctionArgs) => {
	console.log('submit action')

	const { username, password } = params
	let formData = await request.formData()
	console.log(params)
	console.log(request)
	console.log(formData)

	if (!username || !password) throw new Error('username or password not inserted.')

	const user = await loginUser(username, password)

	if (!user || !user?.id) throw new Error('User not found.')

	const loggedUser: LoggedUser = {
		idUser: user.id
	}

	writeToStorage(StorageKey.auth, loggedUser)

	return redirect(route.home)
}
