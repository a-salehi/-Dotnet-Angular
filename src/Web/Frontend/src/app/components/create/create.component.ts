import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {UserModel} from "src/app/models/user.model";
import {AppUserService} from "../../services/user.service";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  userForm: UserModel = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    place: '',
  };

  constructor(private appUserService: AppUserService,
              private router: Router) {
  }

  ngOnInit(): void {
  }

  create() {
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    form.classList.add('was-validated');
    if (form.checkValidity() !== false) {
      this.appUserService.add(this.userForm)
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
