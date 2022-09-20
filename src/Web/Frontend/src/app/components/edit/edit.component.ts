import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {UserModel} from "src/app/models/user.model";
import {AppUserService} from "../../services/user.service";

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent implements OnInit {
  userForm: UserModel = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    place: '',
  };
  constructor(
    private route: ActivatedRoute,
    private router:Router,
    private appUserService: AppUserService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      var id = Number(param.get('id'));
      this.getById(id);
    });
  }

  getById(id: number) {
    this.appUserService.get(id).subscribe((data) => {
      this.userForm = data;
    });
  }

  update() {
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    form.classList.add('was-validated');
    if (form.checkValidity() !== false) {
      this.appUserService.update(this.userForm)
        .subscribe({
          next: (data) => {
            this.router.navigate(["/"]).then(() => {
              window.location.reload();
            });
          },
          error: (err) => {
            console.log(err);
          }
        })
    }
  }
}
