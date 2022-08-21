import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RoleTypeEnum } from '../models/Enum/role.enum';
import { User } from './../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  baseURL: string = environment.baseURL;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  _currenUser :User ;

  constructor(private http: HttpClient) {
    //for now
     this._currenUser = { image: '', token: '', role: [RoleTypeEnum.customer], userName: '' };
   }
  Login(userModel: any) {
    return this.http.post<User>(this.baseURL + 'Account/login', userModel).pipe(
      map((response: User) => {
        this.setCurrentUser(response);
        return response; 
      })
    );
  }

  Register(userModel: any) {
    return this.http
      .post<User>(this.baseURL + 'Account/register', userModel)
      .pipe(
        map((response: User) => {
          this.setCurrentUser(response);
        })
      );
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }
  LogOut() {
    localStorage.removeItem('user');
    let user: User = { image: '', token: '', role: [], userName: '' };
    this.currentUserSource.next(user);
  }
}
