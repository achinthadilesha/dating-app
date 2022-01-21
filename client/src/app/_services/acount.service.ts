import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';

//! angular service is a singleton

@Injectable({
  providedIn: 'root'
})
export class AcountService {
  //! declaring observables here
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  //! base url:-
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }


  //! login method
  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User)=>{
        const user = response;
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  setCurrentUser(user: User){
    this.currentUserSource.next(user);
  }

  //! logout method
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}

