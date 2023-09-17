export interface CreateWalletRequest {
	name: string
	description?: string
	money: number
}

export interface EditWalletRequest {
	id: number
	name: string
	description?: string
	money: number
}