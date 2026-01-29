import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ClientService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:59082/api/Client/';

  // Fonction privée pour récupérer le badge d'accès
  private getHeaders() {
    const userData = localStorage.getItem('user');
    let myToken = '';

    if (userData) {
      const parsedUser = JSON.parse(userData);
      myToken = parsedUser.token;
    }

    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${myToken}`,
      }),
    };
  }

  // Utilisation pour Lister
  getClients(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'all', this.getHeaders());
  }

  // Utilisation pour Supprimer
  deleteClient(id: number): Observable<any> {
    const url = `${this.apiUrl}${id}`;
    return this.http.delete(url, this.getHeaders());
  }
  updateClient(id: number, formData: FormData): Observable<any> {
    const userData = localStorage.getItem('user');
    let myToken = '';
    if (userData) {
      myToken = JSON.parse(userData).token;
    }

    // Ne mettez PAS 'Content-Type': 'application/json' ici !
    const headers = new HttpHeaders({
      Authorization: `Bearer ${myToken}`,
    });
  return this.http.put(`${this.apiUrl}${id}`, formData, { headers });
}

  createClient(formData: FormData): Observable<any> {
    const userData = localStorage.getItem('user');
    let myToken = '';
    if (userData) {
      myToken = JSON.parse(userData).token;
    }

    // Ne mettez PAS 'Content-Type': 'application/json' ici !
    const headers = new HttpHeaders({
      Authorization: `Bearer ${myToken}`,
    });

    return this.http.post(this.apiUrl + 'Create', formData, { headers });
  }
}
