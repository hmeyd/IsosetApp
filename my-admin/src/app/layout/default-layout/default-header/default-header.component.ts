import { NgTemplateOutlet } from '@angular/common';
import { Component, computed, inject, input, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { CommonModule } from '@angular/common';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { toSignal } from '@angular/core/rxjs-interop';
import { ProgressModule, BadgeModule, DropdownModule } from '@coreui/angular';
import { Router } from '@angular/router';



import {
  AvatarComponent,
  BadgeComponent,
  BreadcrumbRouterComponent,
  ColorModeService,
  ContainerComponent,
  DropdownComponent,
  DropdownDividerDirective,
  DropdownHeaderDirective,
  DropdownItemDirective,
  DropdownMenuDirective,
  DropdownToggleDirective,
  HeaderComponent,
  HeaderNavComponent,
  HeaderTogglerDirective,
  NavItemComponent,
  NavLinkDirective,
  SidebarToggleDirective
} from '@coreui/angular';

import { IconDirective } from '@coreui/icons-angular';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
  imports: [ContainerComponent,  CommonModule, // ✅ OBLIGATOIRE pour *ngIf, *ngFor, ngTemplateOutlet
    // CoreUI
    HeaderNavComponent,
    NavItemComponent,
    NavLinkDirective,ProgressModule,
    BadgeModule,
    DropdownModule,
    IconDirective,HeaderTogglerDirective, SidebarToggleDirective, IconDirective, HeaderNavComponent, NavItemComponent, NavLinkDirective, RouterLink, RouterLinkActive, NgTemplateOutlet, BreadcrumbRouterComponent, DropdownComponent, DropdownToggleDirective, AvatarComponent, DropdownMenuDirective, DropdownHeaderDirective, DropdownItemDirective, BadgeComponent, DropdownDividerDirective]
})
export class DefaultHeaderComponent extends HeaderComponent implements OnInit {
  // Injection moderne (Angular 16+)
  readonly #colorModeService = inject(ColorModeService);
  readonly colorMode = this.#colorModeService.colorMode;
  
  // Variables utilisateur
  public currentUser: any;
  public notificationCount: number = 10;

  // --- PARTIE AUTHENTIFICATION (Signals) ---
  // On transforme l'observable du service en Signal pour le HTML
  userSignal = toSignal(this.authService.user$);

  isLoggedIn = computed(() => {
    const user = this.userSignal();
    if (user && user.token) {
      return !this.jwtHelper.isTokenExpired(user.token);
    }
    return false;
  });

  readonly colorModes = [
    { name: 'light', text: 'Light', icon: 'cilSun' },
    { name: 'dark', text: 'Dark', icon: 'cilMoon' },
    { name: 'auto', text: 'Auto', icon: 'cilContrast' }
  ];

  public tasks = [
  { name: 'Base de données', progress: 25, color: 'info' },
  { name: 'Backend API', progress: 75, color: 'success' },
  { name: 'Tests unitaires', progress: 50, color: 'warning' }
];
  readonly icons = computed(() => {
    const currentMode = this.colorMode();
    return this.colorModes.find(mode => mode.name === currentMode)?.icon ?? 'cilSun';
  });

  constructor(
    private authService: AuthService, 
    private jwtHelper: JwtHelperService,
    private router: Router
  ) {
    super();
  }

   user$ = this.authService.user$;
  isLoggedIn$ = this.user$.pipe(

    map(user => {
      return !!user?.token && !this.jwtHelper.isTokenExpired(user.token);
    })
  );
  goToProfile(): void {
  const targetPath = '/profile';
  console.log('Tentative de navigation vers :', targetPath); // Vous verrez ceci dans la console
  this.router.navigate([targetPath]);
}

  ngOnInit(): void {
    // 1. Récupération des infos locales
    const userJson = localStorage.getItem('currentUser');
    if (userJson) {
      this.currentUser = JSON.parse(userJson);
      console.log("Utilisateur chargé au démarrage :", this.currentUser);
    }

    // 2. Note : Le filtrage de la navBar (navItems) se fait normalement 
    // dans le composant "DefaultLayout", pas dans le Header.
  }

  onLogout(): void {
    this.authService.logout();
    // La redirection vers /login est normalement gérée dans le service logout
  }
  // l'envelope 

  public messages = [
  { from: 'Jean Dupont', time: 'il y a 5 min', message: 'Le rapport est prêt...', color: 'success' },
  { from: 'Marie Laure', time: 'il y a 2h', message: 'Réunion reportée à 15h', color: 'info' },
  { from: 'Système', time: 'il y a 1j', message: 'Nouveau message de sécurité', color: 'warning' }
];

// Dans le .ts
userName = computed(() => {
  const user = this.userSignal();
  if (user && user.email) {
    return user.email.split('@')[0];
  }
  return 'Invité';
});

// default-header.component.ts

onLockAccount(): void {
  console.log('Action : Verrouillage du compte');
  
  // 1. On peut récupérer l'email actuel avant de "lock"
  const currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
  const userEmail = currentUser.email;

  // 2. On appelle le service de déconnexion
  this.authService.logout(); 

  // 3. Optionnel : Rediriger vers une page "Lock Screen" spécifique 
  // au lieu de la page Login classique
  this.router.navigate(['/login'], { queryParams: { locked: 'true', email: userEmail } });
}

// Le compteur dynamique basé sur la longueur du tableau
get messageCount(): number {
  return this.messages.length;
}

  sidebarId = input('sidebar1');

  public newMessages = [
    {
      id: 0,
      from: 'Jessica Williams',
      avatar: '7.jpg',
      status: 'success',
      title: 'Urgent: System Maintenance Tonight',
      time: 'Just now',
      link: 'apps/email/inbox/message',
      message: 'Attention team, we\'ll be conducting critical system maintenance tonight from 10 PM to 2 AM. Plan accordingly...'
    },
    {
      id: 1,
      from: 'Richard Johnson',
      avatar: '6.jpg',
      status: 'warning',
      title: 'Project Update: Milestone Achieved',
      time: '5 minutes ago',
      link: 'apps/email/inbox/message',
      message: 'Kudos on hitting sales targets last quarter! Let\'s keep the momentum. New goals, new victories ahead...'
    },
    {
      id: 2,
      from: 'Angela Rodriguez',
      avatar: '5.jpg',
      status: 'danger',
      title: 'Social Media Campaign Launch',
      time: '1:52 PM',
      link: 'apps/email/inbox/message',
      message: 'Exciting news! Our new social media campaign goes live tomorrow. Brace yourselves for engagement...'
    },
    {
      id: 3,
      from: 'Jane Lewis',
      avatar: '4.jpg',
      status: 'info',
      title: 'Inventory Checkpoint',
      time: '4:03 AM',
      link: 'apps/email/inbox/message',
      message: 'Team, it\'s time for our monthly inventory check. Accurate counts ensure smooth operations. Let\'s nail it...'
    },
    {
      id: 4,
      from: 'Ryan Miller',
      avatar: '3.jpg',
      status: 'info',
      title: 'Customer Feedback Results',
      time: '3 days ago',
      link: 'apps/email/inbox/message',
      message: 'Our latest customer feedback is in. Let\'s analyze and discuss improvements for an even better service...'
    }
  ];

  public newNotifications = [
    { id: 0, title: 'New user registered', icon: 'cilUserFollow', color: 'success' },
    { id: 1, title: 'User deleted', icon: 'cilUserUnfollow', color: 'danger' },
    { id: 2, title: 'Sales report is ready', icon: 'cilChartPie', color: 'info' },
    { id: 3, title: 'New client', icon: 'cilBasket', color: 'primary' },
    { id: 4, title: 'Server overloaded', icon: 'cilSpeedometer', color: 'warning' }
  ];

  public newStatus = [
    { id: 0, title: 'CPU Usage', value: 25, color: 'info', details: '348 Processes. 1/4 Cores.' },
    { id: 1, title: 'Memory Usage', value: 70, color: 'warning', details: '11444GB/16384MB' },
    { id: 2, title: 'SSD 1 Usage', value: 90, color: 'danger', details: '243GB/256GB' }
  ];

  public newTasks = [
    { id: 0, title: 'Upgrade NPM', value: 0, color: 'info' },
    { id: 1, title: 'ReactJS Version', value: 25, color: 'danger' },
    { id: 2, title: 'VueJS Version', value: 50, color: 'warning' },
    { id: 3, title: 'Add new layouts', value: 75, color: 'info' },
    { id: 4, title: 'Angular Version', value: 100, color: 'success' }
  ];

    
}

