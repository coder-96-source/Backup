import { Injectable } from '@angular/core';
import { User } from '../../../models/user';
import { Observable } from 'rxjs';
import { map, tap} from "rxjs/operators";
import { SessionStorage } from 'ngx-store';
import { GatewayService } from '../../shared/gateway.service';

@Injectable()
export class UserService {
  @SessionStorage() private jwtTokenSession?: string;
  @SessionStorage() private signInTimeSession?: Date;
  @SessionStorage() private userSession?: User;

  get getJwtToken(): string | undefined {
    return this.jwtTokenSession;
  }

  get getUser(): User | undefined {
    return this.userSession;
  }

  get getIsAuthenticated(): boolean | undefined {
    return this.isAuthenticated();
  }

  constructor(private gatewayService: GatewayService) {

  }

  signUp(user: User) {
    return this.gatewayService.post('users/signup', user)
      .pipe(map(res => res));
  }

  signIn(user: User) {
    return this.gatewayService.post('users/signin', user)
      .pipe(
      map(res => res),
      tap(res => {
        const user = res['user'] as User;
        const jwtToken = res['auth_token'] as string;
        this.setUserSession(user, jwtToken);
      }));
  }

  signOut() {
    this.clearUserSession();
    this.navigateHome();
  }

  navigateHome() {
    this.gatewayService.navigateHome();
  }

  private setUserSession(user: User, jwtToken: string) {
    this.signInTimeSession = new Date();
    this.jwtTokenSession = jwtToken;
    this.userSession = user;
  }

  private clearUserSession() {
    this.signInTimeSession = undefined;
    this.jwtTokenSession = undefined;
    this.userSession = undefined;
  }

  private isAuthenticated() {
    return this.signInTimeSession != undefined;
  }
}

