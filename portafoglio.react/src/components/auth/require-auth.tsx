import { Navigate, Outlet, useLocation } from "react-router-dom"
import { useAuth } from "../../contextes/auth.context"

const RequireAuth = () => {
    const { auth } = useAuth()
    const location = useLocation()

    //Se l'utente non è loggato, va nella pagina di login
    if(!auth || !auth.user)
        return <Navigate to="/auth/login" state={{from: location}} replace/>
    
    return <Outlet/>
}

export default RequireAuth