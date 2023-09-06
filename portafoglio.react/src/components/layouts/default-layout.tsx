import { Box } from "@mui/material"
import { Outlet } from "react-router-dom"

export const DefaultLayout = () => {
	return (
		<>
			<Box sx={{
				display: 'flex',
				flexDirection: 'column',
				height: '100vh',
				width: '100wh',
				paddingX: '45px',
				paddingY: '30px',
			}}>
				<Outlet />
			</Box>
		</>
	)
}