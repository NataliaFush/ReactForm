import {urls} from "../config/urls";
import {axiosService} from "./axios.service";

export const userService= {
    create: (user)=>axiosService.post(urls.users, user).then(value => value.data),
    checkEmail: (email) =>
        axiosService.get(`${urls.users}/email/${email}`).then(value => value.data)
    

}