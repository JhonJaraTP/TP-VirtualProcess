import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(private http: HttpClient) { }

  getPersonalData(): Observable<any>{
    return this.http.get(environment.apiUrl + "api/PersonalDatas");
  }
  
  getPersonalDataByNIT(NIT:number):Observable<any>{
    return this.http.get(environment.apiUrl + "api/PersonalDatas/"+NIT);
  }

  getPersonalDataCreate(user: any): Observable<any>{
    return this.http.post(environment.apiUrl + "api/PersonalDatas/", user);
  }


}
