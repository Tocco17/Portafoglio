import { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { createUrl } from "./serialize-deserialize";
import { StorageKey, readFromStorage } from "../../utils/storage";
import { axiosInstance } from "./axios";

export interface GetApiProps {
	controller: string
	params?: any
	config?: AxiosRequestConfig<any> | undefined
	count?: number
}

export const getApi = async <T>({ controller, params, config, count }: GetApiProps) => {
	const url = createUrl(controller, params)

	const response = await axiosInstance.get<T, AxiosResponse<T, any>>(url, config)
	return response
}

export interface PostApiProps {
	url: string
	data?: any
	config?: AxiosRequestConfig<any> | undefined
	count?: number
}

export const postApi = async <T>({ url, data, config, count }: PostApiProps) => {
	const response = await axiosInstance.post<T, AxiosResponse<T, any>>(url, data, config)
	return response
}

export interface PutApiProps {
	url: string
	data?: any
	config?: AxiosRequestConfig<any> | undefined
	count?: number
}

export const putApi = async <T>({ url, data, config, count }: PutApiProps) => {
	const response = await axiosInstance.put<T, AxiosResponse<T, any>>(url, data, config)
	return response
}

export interface DeleteApiProps {
	controller: string
	params?: any
	config?: AxiosRequestConfig<any> | undefined
	count?: number
}

export const deleteApi = async <T>({ controller, config, count, params }: DeleteApiProps) => {
	const url = createUrl(controller, params)
	const response = await axiosInstance.delete<T, AxiosResponse<T, any>>(url, config)
	return response
}