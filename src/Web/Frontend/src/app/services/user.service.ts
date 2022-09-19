import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {UserModel} from "src/app/models/user.model";

@Injectable({ providedIn: "root" })
export class AppUserService {
  constructor(
    private readonly http: HttpClient) { }

  add = (user: UserModel) => this.http.post<number>("users", user);

  delete = (id: number) => this.http.delete(`users/${id}`);

  get = (id: number) => this.http.get<UserModel>(`users/${id}`);

  list = () => this.http.get<UserModel[]>("users");

  update = (user: UserModel) => this.http.put(`users/${user.id}`, user);

  // public getUsers(): UserModel[] {
  //   let user = new UserModel();
  //   user.id = 1;
  //   user.firstName = "Amir Hossein";
  //   user.lastName = "Salehi";
  //   user.email = "amirhossein.salehi@hotmail.com";
  //   user.place = "Iran";
  //
  //   return [user];
  // }
}
