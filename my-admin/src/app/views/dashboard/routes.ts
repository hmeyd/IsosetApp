import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./dashboard.component').then(m => m.DashboardComponent),
    data: { title: 'Dashboard' }
  },
  {
    path: 'register',
    loadComponent: () => import('../pages/register/register.component').then(m => m.RegisterComponent),
    data: { title: 'Register' }
  },
  {
    path: 'login',
    loadComponent: () => import('../pages/login/login.component').then(m => m.LoginComponent),
    data: { title: 'Login' }
  }
];
