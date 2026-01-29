import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap, map} from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';


export interface AuthUser {
  id: number;
  email: string;
  role: string;
  token: string;
}


export interface RegisterDto {
  email: string;
  password: string;
  role: string;
}

export interface LoginDto {
  email: string;
  password: string;
  role:string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {

  private apiUrl = 'http://localhost:59082/api/User';
  private jwtHelper = new JwtHelperService();

  private _user$ = new BehaviorSubject<AuthUser | null>(null);
  user$ = this._user$.asObservable();
 


  constructor(private http: HttpClient) {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      this._user$.next(JSON.parse(storedUser));
    }
  }
  register(data: RegisterDto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/registre`, data);
  }


login(dto: LoginDto) {
  return this.http.post<AuthUser>(`${this.apiUrl}/login`, dto).pipe(
    tap(user => {
      console.log("Utilisateur connecté avec succès :", user);
      
      // 1. Sauvegarder dans le localStorage pour persister après un refresh
      localStorage.setItem('user', JSON.stringify(user));
      
      // 2. Diffuser l'information à tous les composants (dont le Header)
      this._user$.next(user); 
    })
  );
}
updateClient(id: number, formData: FormData) {
  return this.http.put(`${this.apiUrl}/${id}`, formData);
}


/*
login(dto: LoginDto) {
  return this.http.post<AuthUser>(`${this.apiUrl}/login`, dto).pipe(
    tap(user => {
      console.log("Utilisateur connecté avec succès :", user);
      
      // 1. Sauvegarder dans le localStorage pour persister après un refresh
      localStorage.setItem('user', JSON.stringify(user));
      
      // 2. Diffuser l'information à tous les composants (dont le Header)
      this._user$.next(user); 
    })
  );
}

*/


  
public isLoggedIn$ = this.user$.pipe(
  map(user => {
    console.log("isLoggedIn$ recalculé");
    console.log("User reçu :", user);

    if (!user) {
      return false;
    }

    return !!user.token && !this.jwtHelper.isTokenExpired(user.token);
  })
);



  logout(): void {
    this._user$.next(null);
    localStorage.removeItem('user');
  }
}
