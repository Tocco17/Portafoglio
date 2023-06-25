import User from "../../models/entities/user.interface"
import UserFilter from "../../models/filters/user.filter"
import { postApi } from "../axios/calls"

const postUserLogin = async (filter: UserFilter) => {
    const response = await postApi<User>({controller: 'user/login', params: filter})
    return response.data
}

export default postUserLogin