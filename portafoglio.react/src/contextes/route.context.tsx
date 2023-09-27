import { createBrowserRouter } from "react-router-dom";
import { Login, loginSubmitAction } from "../pages/login";
import Home from "../pages/home";
import { DefineDb, defineDbLoader } from "../pages/define-db";
import RequireAuth from "../components/auth/require-auth";
import { SeeDb, seeDbLoader } from "../pages/see-db";
import { Wallets, walletsLoader } from "../pages/wallets";
import { WalletPage, walletPageLoader } from "../pages/wallets/idWallet";
import { NewWalletPage, newWalletPageAction } from "../pages/wallets/new";
import { EditWallet, editWalletAction, editWalletLoader } from "../pages/wallets/idWallet/edit";
import { DefaultLayout } from "../components/layouts/default-layout";
import { LabelPage } from "../pages/labels";

const router = createBrowserRouter([
	{
		element: <DefaultLayout />,
		children: [
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
										path: ':idWallet/edit/',
										element: <EditWallet />,
										loader: editWalletLoader,
										action: editWalletAction,
									},
									{
										path: 'new/',
										element: <NewWalletPage />,
										action: newWalletPageAction,
									}
								]
							},
							{
								path: 'labels/',
								element: <LabelPage />,
							}
						],
					},
				]
			},
		]
	}
	

])

export default router


export enum route {
	home = '/',
	login = '/auth/login',
	wallets = '/wallets',
	labels = '/labels',
}