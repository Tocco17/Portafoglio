import { LoggedUser } from "../../models/dtos/logged-user"
import { User } from "../../models/entities/user"
import UserFilter from "../../models/filters/user.filter"
import { StorageKey, readFromStorage, writeToStorage } from "../../utils/storage"
import { getApi, postApi } from "../axios/calls"


export const createUser = async (user: User) => {
	const response = await postApi<string>({
		url: 'User',
		data: user
	})

	return response.data
}

export const loginUser = async (username: string, password: string) => {
	const filter: UserFilter = {
		username,
		password,
	}

	const response = await getApi<string>({
		controller: 'User/Login',
		params: filter
	})

	const loggedUser: LoggedUser = {
		idUser: response.data
	}

	writeToStorage(StorageKey.auth, loggedUser)
	
	return response.data
}