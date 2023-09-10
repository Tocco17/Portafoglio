export const moneyToString = (money: number) => {
	const euros = money / 100
	const cents = money % 100 ? money % 100 : '00'
	const inString = `${euros},${cents} €`
	return inString
}

export const moneyFromString = (inString: string) => {
	const regex = new RegExp('(?<euros>[0-9]*),(?<cents>[0-9]{2}) €')
	const result = regex.exec(inString)

	const groups = result?.groups as { euros: string, cents: string, }
	const euros = groups.euros
	const cents = groups.cents

	const moneyInString = euros + cents
	const money = parseInt(moneyInString)

	return money
}