import { createBrowserRouter } from "react-router-dom";
import Login, { loginSubmitAction } from "../pages/login";
import Home from "../pages/home";
import { element } from "prop-types";
import { DefineDb, defineDbLoader } from "../pages/define-db";

const router = createBrowserRouter([
    {
        path: '/',
        children: [
            {
                index: true,
                element: <Home />
            },
			{
				path: 'define-db',
				element: <DefineDb />,
				loader: defineDbLoader,
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
        ]
    },
    
])

export default router


export enum route {
    home = '/',
    login = '/auth/login',
}