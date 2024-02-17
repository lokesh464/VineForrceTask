import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import {IResult} from "../wrappers/IResult";

@Injectable(
    { providedIn: "root"}
)
export class CountryService{

    baseUrl = environment.apis.default.url + "/api/app/";
    constructor(private http: HttpClient){
    }

    getAll(){
        debugger;
        return this.http.get<any>(this.baseUrl + "Country");
    }

    add(country: any){
        return this.http.post<IResult<string>>(this.baseUrl + 'Country/', country);
    }

    delete(id : string){
        return this.http.delete<IResult<string>>(this.baseUrl + 'Country/' + id);
    }

}