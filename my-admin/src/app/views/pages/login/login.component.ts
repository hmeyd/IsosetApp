import { Component, EventEmitter, Output } from '@angular/core';
import { IconDirective } from '@coreui/icons-angular';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginDto, AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import {
  ButtonDirective,
  CardBodyComponent,
  CardComponent,
  CardGroupComponent,
  ColComponent,
  ContainerComponent,
  FormControlDirective,
  FormDirective,
  InputGroupComponent,
  InputGroupTextDirective,
  RowComponent
} from '@coreui/angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  imports: [ReactiveFormsModule,ContainerComponent, RowComponent, ColComponent, CardGroupComponent, CardComponent, CardBodyComponent, FormDirective, InputGroupComponent, InputGroupTextDirective, IconDirective, FormControlDirective, ButtonDirective]
})
export class LoginComponent {
  @Output() LoginSubmit = new EventEmitter<LoginDto>();

  loginForm: FormGroup;
  

  constructor(
    private fb: FormBuilder,
    private authService: AuthService, // ⚡ Injection ici
    private router: Router            // ⚡ Pour naviguer après login
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      role: ['', [Validators.required]]
    });
  }

  onSubmit(): void {
  if (this.loginForm.invalid) {
    this.loginForm.markAllAsTouched();
    return;
  }

  const dto: LoginDto = this.loginForm.value; // Contient email, password et le rôle CHOISI

  this.authService.login(dto).subscribe({
    next: (user) => {
      // VERIFICATION DU ROLE : On compare le choix de l'utilisateur avec la réalité du serveur
      // On suppose que votre objet 'user' renvoyé par le serveur contient une propriété 'role'
      if (user && user.role === dto.role) {
        
        console.log('Rôle correct ! Connexion autorisée.');
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.router.navigate(['/dashboard']);

      } else {
        // Le rôle ne correspond pas !
        console.warn('Rôle incorrect. Attendu:', user.role, 'Reçu:', dto.role);
        
        // On force la déconnexion ou on ne stocke rien
        alert("Accès refusé : Le rôle sélectionné ne correspond pas à votre compte.");
        
        // Optionnel : on peut appeler le logout pour nettoyer si le serveur a créé une session
        // this.authService.logout(); 
      }
    },
    
    error: (err) => {
      console.error('Erreur login:', err);
      alert("Email ou mot de passe incorrect.");
    }
  });
}
  onLogout(): void {
  // 1. Supprimer les données de session
  localStorage.removeItem('token');
  this.router.navigate(['/dashboard']);
}
}