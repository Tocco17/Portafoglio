import { Link } from "react-router-dom"
import { route } from "../../contextes/route.context"
import Button from '@mui/material/Button';

const Home = () => {
    return (
        <>
        <div>Home</div>
        <Button component={Link} to={route.login}>Login</Button>
        </>
    )
}

export default Home