import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AcountService } from '../_services/acount.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})

export class NavComponent implements OnInit {

  //! defining the model here
  model: any = {}
  // currentUser$: Observable<User>;
  // loggedIn: boolean;

  //? injecting service components inside the constructor
  constructor(public accountService: AcountService) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
  }

  //! login method
  login() {

    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      // this.loggedIn = true;
    }),
      error => {
        console.log(error);

      }
  }

  //! lougout method
  logout(){
    
    this.accountService.logout();
    // this.loggedIn = false;

  }

  //! get current user observabler
  // getCurrentUser(){
  //   this.accountService.currentUser$.subscribe(
  //     user => {
  //     this.loggedIn = !!user
  //     },
  //     error => {
  //       console.log(error);
        
  //     },
  //   )
  // } 

}
