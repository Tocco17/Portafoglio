import { FormControl, FormLabel, TextField } from "@mui/material"
import { ReactNode } from "react"

type TextInputType = "button" | "checkbox" | "color" | "date" | "datetime-local" | "email" | "file" | "hidden" | "image" | "month" | "number" | "password" | "radio" | "range" | "reset" | "search" | "submit" | "tel" | "text" | "url" | "week"

export interface TextInputProps {
	id?: string
	name?: string
	children?: ReactNode
	required?: boolean
	defaultValue?: string

	type?: TextInputType
}

export const TextInput: React.FC<TextInputProps> = ({
	id,
	children,
	name,
	required,
	defaultValue,
	type
}) => {
	return (
		<FormControl>
			<FormLabel htmlFor={id}>{children}</FormLabel>

			<TextField
				id={id}
				name={name}
				required={required}
				defaultValue={defaultValue}
				type={type}
			/>
		</FormControl>
	)
}