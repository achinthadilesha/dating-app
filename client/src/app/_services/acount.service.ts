import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

//! angular service is a singleton

@Injectable({
  providedIn: 'root'
})
export class AcountService {


  //! base url:-
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }


  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model);
  }
}

