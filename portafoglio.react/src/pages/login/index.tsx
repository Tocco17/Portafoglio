import { Box, Button, FormControl, FormGroup, FormHelperText, Input, InputLabel, TextField, makeStyles } from "@mui/material"
import { ActionFunctionArgs, Form, redirect } from "react-router-dom"
import { route } from "../../contextes/route.context"
import { createUser, loginUser } from "../../api/controllers/user-controller"
import { LoggedUser } from "../../models/dtos/logged-user"
import { StorageKey, writeToStorage } from "../../utils/storage"
import { Password } from "@mui/icons-material"

const Login = () => {

	const handleSubmitBox = (event: FormEvent) => {
		console.log('submit box')
		console.log(event)

		// event
	}

	const handleSubmitFormControl = (event: FormEvent) => {
		console.log(event)
	}

	const handleSubmitForm = (event: FormEvent) => {
		console.log(event)
	}

	return (
		<>
			<h1>Login</h1>

			<FormGroup>

				<FormControl>
					<InputLabel htmlFor="username-input" >Username</InputLabel>
					<Input id="username-input" />
				</FormControl>

				<FormControl>
					<InputLabel htmlFor="password-input">Password</InputLabel>
					<Input id="password-input" />
				</FormControl>

				<Button >Login</Button>
			</FormGroup>

			{/* <Box component="form" onSubmit={handleSubmitBox}>
				<TextField id="username-input" label="Username" required name="username" />
				<TextField id="password-input" label="Password" required name="password" type="password"/>
				<Button type="submit">Login</Button>
			</Box> */}

			{/* <FormControl id="login-form" onSubmit={handleSubmit}>
            <TextField id="username-input" label="Username" required name="username" />
            <TextField id="password-input" label="Password" required name="password" />
            <Button type="submit">Login</Button>
        </FormControl> */}

			{/* <Form id="login-form" method="post" onSubmit={handleSubmitForm}>
            <TextField id="username-input" label="Username" required name="username" />
            <TextField id="password-input" label="Password" required name="password" />
            <Button type="submit">Login</Button>
        </Form> */}
		</>
	)
}

export default Login


export const loginSubmitAction = async ({ params }: ActionFunctionArgs) => {
	console.log('submit action')

	const { username, password } = params
	console.log(params)

	if (!username || !password) throw new Error('username or password not inserted.')

	const user = await loginUser(username, password)

	if (!user || !user?.id) throw new Error('User not found.')

	const loggedUser: LoggedUser = {
		idUser: user.id
	}

	writeToStorage(StorageKey.auth, loggedUser)

	return redirect(route.home)
}
