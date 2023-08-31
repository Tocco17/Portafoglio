import { BaseEntity } from "../models/entities/base-entity"
import { readFromStorage, writeToStorage } from "./storage"

export enum DatabaseKey {
	earningSuddivision = 'earningSuddivision',
	earning = 'earning',
	label = 'label',
	transaction = 'transaction',
	user = 'user',
	wallet = 'wallet',
}

export const getMaxId = (database: DatabaseKey) => {
	const datas = readFromStorage<BaseEntity[]>(database) as BaseEntity[] | undefined
	const ids = datas?.map(d => d.id).filter(id => !!id) as number[] | undefined

	if(!ids) return undefined
	
	const max = Math.max(...ids)
	return max
}

export const getNewId = (database: DatabaseKey) => {
	const maxId = getMaxId(database)
	return maxId ? maxId + 1 : 1
}

export const insertNewData = (database: DatabaseKey, data: BaseEntity) => {
	const datas = readFromStorage<BaseEntity[]>(database) as BaseEntity[] | undefined
	const newId = getNewId(database)

	const dataToInsert: BaseEntity = {...data, id: newId}
	const datasToInsert: BaseEntity[] = (!datas || !datas.length) ? [dataToInsert] : [...datas, dataToInsert]

	writeToStorage(database, datasToInsert)
	return dataToInsert
}

export const insertNewDataList = (database: DatabaseKey, data: BaseEntity[]) => {
	const datas = readFromStorage<BaseEntity[]>(database) as BaseEntity[] | undefined
	const newId = getNewId(database)
	
	const datasToAdd: BaseEntity[] = data.map((d, i) => ({...d, id: newId + i}))
	const datasToInsert: BaseEntity[] = (!datas || !datas.length) ? [...datasToAdd] : [...datas, ...datasToAdd]

	writeToStorage(database, datasToInsert)
	return datasToAdd
}