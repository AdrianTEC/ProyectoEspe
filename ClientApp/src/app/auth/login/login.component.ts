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
    this.backend.get_request('Players/' + username, null).subscribe((user) => {
      user.money = 1000000000;
      this.sesionService.setUser(JSON.stringify(user));
      this.router.navigateByUrl('/pages');
    });
  }

  register(): void {
    this.router.navigateByUrl('/auth/register');
  }
}
