import { createBrowserRouter } from "react-router-dom";
import Login from "../pages/login";
import Home from "../pages/home";

const router = createBrowserRouter([
    {
        path: '/',
        children: [
            {
                index: true,
                element: <Home />
            },
            {
                path: 'auth/',
                children: [
                    {
                        path: 'login',
                        element: <Login />
                    }
                ]
            }
        ]
    }
])

export default router