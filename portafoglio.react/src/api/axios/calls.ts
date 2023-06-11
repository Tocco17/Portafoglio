import { AxiosRequestConfig } from "axios"
import axios from "./axios"
import { createUrl } from "./serialize-deserialize"

export interface GetApiProps {
    controller: string
    params?: any
}

export const getApi = async <T>({controller, params}: GetApiProps) => await axios.get<T>(createUrl(controller, params))



export interface PostApiProps {
    controller: string
    params: any
    config?: AxiosRequestConfig<any>
}

export const postApi = async <T>({controller, params, config = undefined}: PostApiProps) => await axios.post<T>(controller, params, config)



export interface DeleteApiProps {
    controller: string
}

export const deleteApi = async ({controller}: DeleteApiProps) => await axios.delete(controller)