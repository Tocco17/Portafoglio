import axios from 'axios';

const appVersion = '1'
const portNumber = 7114
const baseUrl = `https://localhost:${portNumber}/api`

export const getAppVersion = (): string => appVersion

export const getUrl = (controller: string): string => {
  return `${baseUrl}/${controller}`;
}

export const axiosInstance = axios.create({
  baseURL: baseUrl,
})