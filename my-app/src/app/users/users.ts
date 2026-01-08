import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule, 
    HttpClientModule
  ],
  templateUrl: './users.html'
})
export class UsersComponent {

  registerForm!: FormGroup;
  apiUrl = 'http://localhost:59082/api/User/registre';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) {
    this.registerForm = this.fb.group({
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', Validators.required],
      Role: ['', Validators.required]
    });
  }

  onSubmit() {
    console.log('Données du formulaire :', this.registerForm.value);

    if (this.registerForm.invalid) {
      console.log('Formulaire invalide');
      return;
    }

    this.http.post(this.apiUrl, this.registerForm.value).subscribe({
      next: (res) => console.log('Réponse API :', res),
      error: (err) => console.error('Erreur API :', err)
    });
  }
}
