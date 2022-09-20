import { Component } from '@angular/core';
import {UserModel} from "./models/user.model";
import {AppUserService} from "./services/user.service";
import {Observable} from "rxjs";

declare var window: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  users: UserModel[] = [];
  deleteModal: any;
  idTodelete: number = 0;

  constructor(private appUserService: AppUserService) {
  }

  ngOnInit() : void{
    this.appUserService.list().subscribe((result : UserModel[])=>(this.users = result));
    console.log(this.users);
    this.deleteModal = new window.bootstrap.Modal(
      document.getElementById('deleteModal')
    );
  }

  openDeleteModal(id: number) {
    this.idTodelete = id;
    this.deleteModal.show();
  }

  delete() {
    this.appUserService.delete(this.idTodelete).subscribe({
      next: (data) => {
        this.users = this.users.filter(_ => _.id != this.idTodelete)
        this.deleteModal.hide();
      },
    });
  }
}
