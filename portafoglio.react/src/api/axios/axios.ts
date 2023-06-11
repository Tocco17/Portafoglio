import axios from 'axios';

const appVersion = '1'
const portNumber = 5024
const version = 1
const baseUrl = `http://localhost:${portNumber}/api/v${version}`

export const getAppVersion = (): string => appVersion

export const getUrl = (controller: string): string => {
  return `${baseUrl}/${controller}`;
}

const axiosInstance = axios.create({
  baseURL: baseUrl,
})

export default axiosInstance