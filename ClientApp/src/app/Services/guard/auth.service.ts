import { Injectable, NgZone } from '@angular/core';
import { Router } from '@angular/router';

import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  userData: any; // Save logged in user data

  constructor(
    public afAuth: AngularFireAuth, // Inject Firebase auth service
    public router: Router,
    public ngZone: NgZone,
    public afs: AngularFirestore,
    public userService: UserService
  ) {}

  async sendVerificationMail() {
    return (await this.afAuth.currentUser)
      .sendEmailVerification()
      .then(() => {});
  }

  SignIn(email: string, password: string) {
    return this.afAuth.signInWithEmailAndPassword(email, password);
  }

  SignUp(email: string, password: string) {
    return this.afAuth.createUserWithEmailAndPassword(email, password);
  }

  get isLoggedIn(): boolean {
    const temp: any = localStorage.getItem('user');
    if (temp !== 'undefined') {
      const user = JSON.parse(temp);
      return user !== null && user.emailVerified !== false ? true : false;
    }
    return false;
  }

  getData(use: string) {}
  SignOut() {
    return this.afAuth.signOut().then(() => {
      localStorage.removeItem('user');
      this.router.navigate(['/login']);
    });
  }
}
