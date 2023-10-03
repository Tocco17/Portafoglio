export interface CreateWalletRequest {
	name: string
	description?: string
	money: number
}

export interface EditWalletRequest {
	id: string
	name: string
	description?: string
	money: number
}