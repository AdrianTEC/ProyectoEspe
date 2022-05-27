import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestApiServiceService } from 'src/app/Services/rest-api-service.service';
import { SesionService } from 'src/app/Services/sesion-service.service';
import { Md5 } from 'ts-md5/dist/md5';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private router: Router,
    private backend: RestApiServiceService,
    private sesionService: SesionService
  ) {}

  ngOnInit(): void {}

  login(username: string, password: string): void {
    password = Md5.hashStr(password);

    const data = { username: username, password: password };

    this.backend.post_request('Login', data).subscribe((userAuth: any) => {
      console.log(userAuth);

      if (!userAuth.isPlayer) return;
      this.sesionService.getUserFromDb(username);
    });
  }

  register(): void {
    this.router.navigateByUrl('/auth/register');
  }
}
