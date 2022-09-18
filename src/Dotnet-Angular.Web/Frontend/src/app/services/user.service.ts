import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {UserModel} from "src/app/models/user.model";

@Injectable({providedIn: "root"})
export class AppUserService {
  constructor() {
  }

  public getUsers(): UserModel[] {
    let user = new UserModel();
    user.id = 1;
    user.firstName = "Amir Hossein";
    user.lastName = "Salehi";
    user.email = "amirhossein.salehi@hotmail.com";
    user.place = "Iran";

    return [user];
  }
}
