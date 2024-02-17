import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import {IResult} from "../wrappers/IResult";

@Injectable(
    { providedIn: "root"}
)
export class StateService{

    baseUrl = environment.apis.default.url + "/api/app/";
    constructor(private http: HttpClient){
    }

    getAll(){
        debugger;
        return this.http.get<any>(this.baseUrl + "State");
    }

    add(State: any){
        return this.http.post<IResult<string>>(this.baseUrl + 'State/', State);
    }

    delete(id : string){
        return this.http.delete<IResult<string>>(this.baseUrl + 'State/' + id);
    }

}