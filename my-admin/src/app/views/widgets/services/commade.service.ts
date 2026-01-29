import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CommandeService {
  private http = inject(HttpClient);
 
  private apiUrl = 'http://localhost:59082/api/Commande';

  // Récupération du token pour l'autorisation
  private getHeaders() {
    const userData = localStorage.getItem('user');
    let myToken = '';

    if (userData) {
      const parsedUser = JSON.parse(userData);
      myToken = parsedUser.token;
    }

    return new HttpHeaders({
      Authorization: `Bearer ${myToken}`,
    });
  }

  // 1. Lister toutes les commandes
  getCommandes(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl, { headers: this.getHeaders() });
  }
// Get Commande by ID
  getCommande(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl, { headers: this.getHeaders() });
  }

  // 2. Créer une commande (avec photo via FormData)
 createCommande(formData: FormData, headers: HttpHeaders): Observable<any> {
  // On passe les headers dans l'objet d'options (le 3ème argument)
  return this.http.post(this.apiUrl, formData, { headers });
}

  // 3. Modifier une commande (avec ID dans l'URL)
  // Dans ton commande.service.ts
updateCommande(id: number, formData: FormData, headers: HttpHeaders): Observable<any> {
  // On passe les headers dans l'objet d'options (le 3ème argument)
  return this.http.put(`${this.apiUrl}/${id}`, formData, { headers });
}
  // 4. Supprimer une commande
  deleteCommande(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}