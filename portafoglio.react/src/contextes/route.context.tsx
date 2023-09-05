import { createBrowserRouter } from "react-router-dom";
import { Login, loginSubmitAction } from "../pages/login";
import Home from "../pages/home";
import { DefineDb, defineDbLoader } from "../pages/define-db";
import RequireAuth from "../components/auth/require-auth";
import { SeeDb, seeDbLoader } from "../pages/see-db";
import { Wallets, walletsLoader } from "../pages/wallets";
import { WalletPage, walletPageLoader } from "../pages/wallets/idWallet";
import { NewWalletPage, newWalletPageAction } from "../pages/wallets/new";

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
					}
				]
			},
			{
				element: <RequireAuth />,
				children: [
					{
						index: true,
						element: <Home />,
					},
					{
						path: 'wallets/',
						element: <Wallets />,
						loader: walletsLoader,
						children: [
							{
								path: ':idWallet/',
								element: <WalletPage />,
								loader: walletPageLoader,
							},
							{
								path: 'new/',
								element: <NewWalletPage />,
								action: newWalletPageAction,
							}
						]
					},
				],
			},
		]
	},

])

export default router


export enum route {
	home = '/',
	login = '/auth/login',
	wallets = '/wallets'
}