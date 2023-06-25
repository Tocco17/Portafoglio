import { Box, Button, FormControl, TextField } from "@mui/material"
import { ActionFunctionArgs, Form, redirect } from "react-router-dom"
import { route } from "../../contextes/route.context"
import postUserLogin from "../../api/user/user.login.post"

const Login = () => {
    const handleSubmitBox = (event: React.FormEvent<HTMLFormElement>) => {
        console.log(event)
    }

    const handleSubmitFormControl = (event: React.FormEvent<HTMLDivElement>) => {
        console.log(event)
    }

    const handleSubmitForm = (event: React.FormEvent<HTMLFormElement>) => {
        console.log(event)
    }
    
    return (
        <>
        <h1>Login</h1>

        <Box component="form" onSubmit={handleSubmitBox} action="/auth/login/search">
            <TextField id="username-input" label="Username" required name="username" />
            <TextField id="password-input" label="Password" required name="password" />
            <Button type="submit">Login</Button>
        </Box>

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


export const loginSubmitAction = async ({params}: ActionFunctionArgs) => {
    const {username, password} = params
    console.log(params)

    if(!username || !password) throw new Error('username or password not inserted.')

    const user = await postUserLogin({username: username, password: password})

    if(!user) throw new Error('User not found.')    
    
    return redirect(route.home)
}
