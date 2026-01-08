import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'http://localhost:59082/api/User';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/users`);
  }

  login(): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, {});
  }

  registre(): Observable<any> {
    return this.http.post(`${this.apiUrl}/registre`, {});
  }
}
