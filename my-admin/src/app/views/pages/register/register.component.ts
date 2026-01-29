import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService, RegisterDto } from '../../../services/auth.service';
import { ButtonDirective, FormControlDirective, FormDirective, FormCheckInputDirective, FormCheckLabelDirective, CardComponent, CardBodyComponent, CardGroupComponent, ContainerComponent, RowComponent, ColComponent } from '@coreui/angular';
import { IconDirective } from '@coreui/icons-angular';

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  imports: [
    ReactiveFormsModule,
    ContainerComponent,
    RowComponent,
    ColComponent,
    CardGroupComponent,
    CardComponent,
    CardBodyComponent,
    FormDirective,
    FormControlDirective,
    ButtonDirective,
    FormCheckInputDirective,
    FormCheckLabelDirective,
    IconDirective
  ]
})
export class RegisterComponent {

  registerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    // Définition du formulaire
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      role: ['', Validators.required]  // valeur par défaut
    });
  }

  onSubmit(): void {
    if (this.registerForm.invalid) {
      console.log('Formulaire invalide');
      return;
    }

    const data: RegisterDto = this.registerForm.value;

    this.authService.register(data).subscribe({
      next: () => {
        console.log('Utilisateur créé en base de données !');
      },
    });

    // reset optionnel
    this.registerForm.reset();
  }
}
