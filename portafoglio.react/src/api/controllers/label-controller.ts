import { LoggedUser } from "../../models/dtos/logged-user"
import { Label } from "../../models/entities/label"
import { LabelFilter } from "../../models/filters/label.filter"
import { StorageKey, readFromStorage } from "../../utils/storage"

export const getLabels = async (filter: LabelFilter) => {
	const auth = readFromStorage(StorageKey.auth) as LoggedUser
	const labelFilter = filter ?? {} as LabelFilter



	return true
}