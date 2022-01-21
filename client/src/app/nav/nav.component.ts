import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  //! defining the model here
  model: any = {}
  
  //? injecting service components inside the constructor
  constructor() { }

  ngOnInit(): void {
  }

  //! login method
  login(){
    console.log(this.model);
    
  }

}
