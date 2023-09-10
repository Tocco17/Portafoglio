import { Button } from "@mui/material"
import { Form } from "react-router-dom"
import {AiOutlineCloseCircle} from "react-icons/ai"
import "./close-button.css"

export interface CloseProps {
	action?: string
}

export const CloseButton: React.FC<CloseProps> = ({action}) => {
	return (
		<>
			<Form action={action}>
				<Button type="submit" sx={{
					fontWeight: 'bold',
					backgroundColor: 'rgba(158, 0, 0, 0.6)',
					color: 'red',
					":hover": {
						backgroundColor: 'red',
						color: 'white',
					}
				}} className="close-button">
					<AiOutlineCloseCircle/>
				</Button>
			</Form>
		</>
	)
}