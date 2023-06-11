import { AxiosError } from "axios"
import { IAuth } from "../../contextes/auth.context"

export const decode = (str: string):string => atob(str)
export const encode = (str: string):string => btoa(str)

export const serializeAuth = (auth: IAuth) => {
    const user = auth.user
    
    if(!user) return ''
    
    const userToken = `${user.username}:${user.password}`
    const userTokenEncoded = encode(userToken)

    return `Basic ${userTokenEncoded}`
}

const stringifyObject: (obj: any, defaultKey?: string) => string = (obj, defaultKey) => {
    return Object.entries(obj).map(([key, value]) => {
        // eslint-disable-next-line array-callback-return
        if(typeof value === 'undefined') return
        
        const keyToPut = defaultKey ? `${defaultKey}.${key}` : key

        if(typeof value !== 'object') return `${keyToPut}=${value}`

        if(value instanceof Date) return `${keyToPut}=${value.toISOString()}`

        return stringifyObject(value, keyToPut)
    }).filter(x => !!x).join('&')
}

export const createUrl = (controller: string, params: any) => {
    if(!params) return controller
    
    const query = stringifyObject(params)

    const questionMarkIndex = controller.indexOf('?')
    const hasQuestionMark = questionMarkIndex !== -1
    const hasQuery = hasQuestionMark && questionMarkIndex !== controller.length - 1

    if(!hasQuestionMark)
        return `${controller}?${query}`

    if(hasQuery)
        return `${controller}&${query}`

    return `${controller}${query}`
}

export const manageErrorMessage: (error: AxiosError<any, any>) => string = (error) => {
    console.error(error)
    
    if(error.response?.status === 500) return 'A server error has occured.'

    if(error.response?.status === 401) return 'Unauthorized call.'
    
    if(typeof error.response?.data === 'string') return error.response?.data
    
    const errorList = error.response?.data.errors
    const errors = Object.entries(errorList).map(([key, value]) => {
        if(typeof value === 'string') return value

        if(value instanceof Array)
            return value.map(v => {
                if(typeof v === 'string') return v
                return ''
            }).join('\n')
        
        return ''
    })

    return errors?.join('\n') ?? 'An error has occured.'
}