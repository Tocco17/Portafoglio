import { User } from "../../models/entities/user"
import { DatabaseKey, insertNewData } from "../../utils/simil-axios-storage"
import { readFromStorage } from "../../utils/storage"

const database = DatabaseKey.user

export const createUser = async (user: User) => {
	insertNewData(database, user)
}

export const loginUser = async (username: string, password: string) => {
	const datas =  readFromStorage(database) as User[] | undefined

	const user = datas?.find(d => d.isActive && d.username === username && d.password === password)
	return user
}