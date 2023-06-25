import { createContext, useContext } from "react";
import User from "../models/entities/user.interface";

export interface IAuth {
    user: User
}

export interface IAuthContext {
    auth: IAuth | undefined
    setAuth: React.Dispatch<React.SetStateAction<IAuth | undefined>>
} 

export const AuthContext = createContext<IAuthContext>({
    auth: undefined,
    setAuth: () => {},
})

export const useAuth = () => useContext(AuthContext)
// interface AuthProviderProps {
//     children: ReactElement
// }

// export const AuthProvider = ({children} : AuthProviderProps) => {
//     const [auth, setAuth] = useState<AuthInterface>()
//     const [persist, setPersist] = useState(false)

//     return (
//         <AuthContext.Provider value={{auth, setAuth, persist, setPersist}}>
//             {children}
//         </AuthContext.Provider>
//     )
// }
