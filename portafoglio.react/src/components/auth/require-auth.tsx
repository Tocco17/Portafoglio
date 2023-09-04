import { Navigate, Outlet, useLocation } from "react-router-dom"
import { useAuth } from "../../contextes/auth.context"
import { StorageKey, readFromStorage } from "../../utils/storage"
import { LoggedUser } from "../../models/dtos/logged-user"

const RequireAuth = () => {
    // const { auth } = useAuth()
    const location = useLocation()

	const auth = readFromStorage(StorageKey.auth) as LoggedUser

    //Se l'utente non è loggato, va nella pagina di login
    if(!auth || !auth.idUser)
        return <Navigate to="/auth/login" state={{from: location}} replace/>
    
    return <Outlet/>
}

export default RequireAuth