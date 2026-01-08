import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { IconDirective } from '@coreui/icons-angular';
import { RouterLink } from '@angular/router';
import { Router } from '@angular/router';

import {
  ContainerComponent,
  RowComponent,
  ColComponent,
  CardComponent,
  CardBodyComponent,
  CardGroupComponent,
  FormDirective,
  FormControlDirective,
  FormCheckComponent,
  FormCheckInputDirective,
  FormCheckLabelDirective,
  ButtonDirective
} from '@coreui/angular';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  imports: [
    RouterLink,
    ReactiveFormsModule,  // <-- AJOUTE CE MODULE
    ContainerComponent,
    RowComponent,
    ColComponent,
    CardGroupComponent,
    CardComponent,
    CardBodyComponent,
    FormDirective,
    FormControlDirective,
    FormCheckComponent,
    FormCheckInputDirective,
    FormCheckLabelDirective,
    ButtonDirective,
    IconDirective
  ]
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      role: ['User', Validators.required]
    });
  }

  onSubmit(): void {
  if (this.registerForm.invalid) {
    console.log('Formulaire invalide');
    return;
  }

  console.log('Données envoyées au serveur:', this.registerForm.value);

  this.http.post('http://localhost:59082/api/User/registre', this.registerForm.value)
    .subscribe({
      next: res => {
        console.log('Utilisateur créé !', res);
        // Réinitialiser le formulaire après soumission réussie
        this.registerForm.reset({
        });
      },
      error: err => console.error('Erreur API', err)
    });
  }
}
