import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root',
})
export class RestApiServiceService {
  constructor(private http: HttpClient) {}

  get_requestByUrl(url: string, Params: any): Observable<any> {
    var http_params = new HttpParams({
      fromObject: Params,
    });
    return this.http.get(url, { params: http_params });
  }

  get_request(url: string, Params: any): Observable<any> {
    var http_params = new HttpParams({ fromObject: Params });

    return this.http.get(environment.serverUrl + url, {
      params: http_params,
    });
  }

  post_request2(url: string, Params: object) {
    return this.http.post(url, Params);
  }

  post_request(url: string, Params: object) {
    return this.http.post(environment.serverUrl + url, Params);
  }

  put_request(url: string, Params: object) {
    return this.http.put(environment.serverUrl + url, Params);
  }

  delete_request(url: string, Params: any) {
    var http_params = new HttpParams({ fromObject: Params });
    return this.http.delete(environment.serverUrl + url, {
      params: http_params,
    });
  }
}
