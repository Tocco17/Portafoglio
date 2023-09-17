import { InputAdornment } from "@mui/material"
import { TextInput, TextInputProps } from "./text-input"

export interface MoneyInputProps extends TextInputProps {

}

export const MoneyInput: React.FC<MoneyInputProps> = ({
	id,
	children,
	name,
	required,
	defaultValue,
	type,
	placeholder,
	inputProps,
}) => {
	return (
		<>
			<TextInput
				id={id}
				name={name}
				required={required}
				defaultValue={defaultValue}
				type="number"
				placeholder={placeholder}
				inputProps={{
					...inputProps,
					startAdornment: <InputAdornment position="start">€</InputAdornment>,
				}}
			>
				{children}
			</TextInput>
		</>
	)
}