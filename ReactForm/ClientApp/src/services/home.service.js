import {urls} from "../config/urls";
import {axiosService} from "./axios.service";

export const homeService= {
    getHome: () =>
        axiosService.get(urls.home).then(value => value.data)

}