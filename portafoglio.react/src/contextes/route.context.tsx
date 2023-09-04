import { createBrowserRouter } from "react-router-dom";
import Login, { loginSubmitAction } from "../pages/login";
import Home from "../pages/home";
import { element } from "prop-types";
import { DefineDb, defineDbLoader } from "../pages/define-db";
import RequireAuth from "../components/auth/require-auth";
import { SeeDb, seeDbLoader } from "../pages/see-db";

const router = createBrowserRouter([
	{
		path: '/',
		children: [
			{
				path: 'define-db',
				element: <DefineDb />,
				loader: defineDbLoader,
			},
			{
				path: 'see-db',
				element: <SeeDb />,
				loader: seeDbLoader,
			},
			{
				path: 'auth/',
				children: [
					{
						path: 'login/',
						action: loginSubmitAction,
						element: <Login />,
						children: [
							{
								path: 'search',
								action: loginSubmitAction,
								errorElement: <div>Oops</div>
							}
						],
					}
				]
			},
			{
				element: <RequireAuth />,
				children: [
					{
						index: true,
						element: <Home />,
					}
				]
			},
		]
	},

])

export default router


export enum route {
	home = '/',
	login = '/auth/login',
}