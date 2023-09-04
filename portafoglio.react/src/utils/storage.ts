import { decode, encode } from "./serialize"

export enum StorageKey {
	auth = 'auth',
}

export const writeToStorage = (key: string, object: any) => {
	const stringified = JSON.stringify(object)
	const encoded = encode(stringified)
	return localStorage.setItem(key, encoded)
}

export const readFromStorage = <T>(key: string) => {
	const item = localStorage.getItem(key) as string | null | undefined
	if (!item) return item

	const decoded = decode(item) as string
	const parsed = JSON.parse(decoded) as T
	return parsed
}

export const deleteFromStorage = (key: string) => localStorage.removeItem(key)

export const clearStorage = () => localStorage.clear()