import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { Observable } from 'rxjs'; // Import obligatoire
import { CardModule, GridModule, ButtonModule } from '@coreui/angular';
import { RouterLink } from '@angular/router';
import { Router } from '@angular/router';

// 1. Définissez l'interface ici
export interface UserProfile {
  email: string;
  role: string;
}

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, CardModule, GridModule, RouterLink, ButtonModule],
  templateUrl: './profile.component.html'
})
export class ProfileComponent {
  private authService = inject(AuthService);
  private router = inject(Router);

  // 2. Typez l'observable avec votre interface
  // On force le type <UserProfile | null>
  public user$: Observable<UserProfile | null> = this.authService.user$ as Observable<UserProfile | null>;

  onLogout(): void {
    this.authService.logout();
  }
  onConnecte(): void{
       this.router.navigate(["/dashboard"]);
  }
}