import { RouterProvider } from "react-router-dom"
import router from "./route.context"

const Provider = () => {
    return (
        <>
        <RouterProvider router={router} />
        </>
    )
}

export default Provider