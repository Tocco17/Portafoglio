export interface LabelDto {
	id: number
	isActive: boolean
	idEarningSuddivision: number
	name: string
	description?: string
	idFatherLabel?: number
	childrenLabels?: LabelDto[]
}