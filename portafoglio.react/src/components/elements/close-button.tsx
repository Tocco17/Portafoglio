import { Button } from "@mui/material"
import { Form } from "react-router-dom"

export interface CloseProps {
	action?: string
}

export const CloseButton: React.FC<CloseProps> = ({action}) => {
	return (
		<>
			<Form action={action}>
				<Button type="submit">X</Button>
			</Form>
		</>
	)
}