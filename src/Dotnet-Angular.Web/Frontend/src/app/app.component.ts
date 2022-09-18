import { Component } from '@angular/core';
import {UserModel} from "./models/user.model";
import {AppUserService} from "./services/user.service";

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
    this.users = this.appUserService.getUsers();
    console.log(this.users);
  }
}
