import { Component } from '@angular/core';
import {UserModel} from "./models/user.model";
import {AppUserService} from "./services/user.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  users: UserModel[] = [];

  constructor(private appUserService: AppUserService) {
  }

  ngOnInit() : void{
    this.appUserService.list().subscribe((result : UserModel[])=>(this.users = result));
    console.log(this.users);
  }
}
