import {
  AfterContentInit,
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  inject,
  OnInit,
  viewChild,
} from '@angular/core';
import { getStyle } from '@coreui/utils';
import { IconModule } from '@coreui/icons-angular';
import { HttpClient, HttpHeaders } from '@angular/common/http'; // Ajoute HttpHeaders ici
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Input } from '@angular/core';
import { ChartjsComponent } from '@coreui/angular-chartjs';
import { CommandeService } from '../services/commade.service';
import { CommonModule } from '@angular/common';
import { ClientService } from '../services/client.service';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ModalModule } from '@coreui/angular';
import { IconDirective } from '@coreui/icons-angular';
import Swal from 'sweetalert2';
import { AuthService } from '../../../services/auth.service'; // Ajuste le chemin selon ton projet
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

import {
  ButtonDirective,
  ColComponent,
  DropdownComponent,
  DropdownDividerDirective,
  DropdownItemDirective,
  DropdownMenuDirective,
  DropdownToggleDirective,
  RowComponent,
  TemplateIdDirective,
  WidgetStatAComponent,
  ButtonModule,
  TableModule,
  SpinnerModule,
  DropdownModule,
} from '@coreui/angular';

@Component({
  selector: 'app-widgets-dropdown',
  templateUrl: './widgets-dropdown.component.html',
  imports: [
    RowComponent,
    TableModule,
    SpinnerModule,
    ModalModule,
    FormsModule,
    CommonModule,
    IconModule,
    CommonModule,
    ColComponent,
    WidgetStatAComponent,
    TemplateIdDirective,
    IconDirective,
    DropdownComponent,
    ButtonDirective,
    DropdownToggleDirective,
    DropdownMenuDirective,
    DropdownItemDirective,
    RouterLink,
    DropdownDividerDirective,
    ChartjsComponent,
  ],
  styles: [
    `
      /* 1. Limiter le corps de la modal et activer le scrollbar */
      .body-scroll-container {
        max-height: 480px;
        overflow-y: auto;
        overflow-x: auto;
        padding: 0 !important;
      }

      /* 2. Fixer l'entête du tableau */
      .sticky-header {
        position: sticky;
        top: 0;
        z-index: 10;
        background-color: #f8f9fa !important;
        box-shadow: inset 0 -1px 0 #dee2e6;
      }

      /* 3. Style de la barre de défilement (Slider) */
      .body-scroll-container::-webkit-scrollbar {
        width: 10px;
      }

      .body-scroll-container::-webkit-scrollbar-thumb {
        background: #321fdb;
        border-radius: 4px;
      }

      .body-scroll-container::-webkit-scrollbar-track {
        background: #f1f1f1;
      }

      /* 4. Largeur de la modal adaptée */
      ::ng-deep .full-scroll-modal .modal-dialog {
        max-width: fit-content !important;
        min-width: 900px;
      }

      th,
      td {
        white-space: nowrap;
        padding: 12px 20px !important;
      }
      /* Style pour rendre la bulle très arrondie */
      .my-custom-popup-class {
        border-radius: 50px !important; /* Ajuste la valeur pour l'effet goutte */
        padding: 2rem !important;
      }

      /* Style pour chaque élément de la liste */
      .item-primary {
        padding: 10px 15px !important;
        border-radius: 8px; /* Coins arrondis pour un look moderne */
        transition: all 0.2s ease-in-out;
        color: #4f5d73; /* Couleur de texte sobre */
      }

      /* Effet au survol (Hover) */
      .item-primary:hover {
        background-color: rgba(
          50,
          31,
          219,
          0.1
        ) !important; /* Bleu primary très léger */
        color: #321fdb !important; /* Le bleu Primary de CoreUI */
      }

      /* Style de l'icône au survol */
      .item-primary:hover svg {
        transform: scale(1.1); /* Petit effet de zoom sur l'icône */
        color: #321fdb !important;
      }
      .item-primary {
        border-radius: 8px !important;
        margin: 0 8px; /* Espace sur les côtés pour l'effet de bulle */
        color: #4f5d73;
        transition: all 0.2s ease;
      }

      /* Effet au survol (Bleu Primary très léger) */
      .item-primary:hover {
        background-color: rgba(50, 31, 219, 0.08) !important;
        color: #321fdb !important;
        transform: translateX(3px); /* Petit décalage vers la droite */
      }

      /* Animation de l'icône */
      .item-primary:hover svg {
        transform: scale(1.1);
      }

      .icon-stack {
        position: relative;
        display: inline-flex;
        align-items: center;
        justify-content: center;
        width: 40px;
        height: 40px;
        background: rgba(50, 31, 219, 0.1); /* Fond bleu très léger */
        border-radius: 10px; /* Coins arrondis style appli moderne */
        transition: all 0.3s ease;
      }

      /* L'icône User */
      .main-user-icon {
        color: #321fdb;
      }

      /* Le petit badge "+" (style point de notification) */
      .plus-dot {
        position: absolute;
        bottom: -2px;
        right: -2px;
        width: 14px;
        height: 14px;
        background-color: #2eb85c; /* Vert succès */
        border: 2px solid #fff; /* Contour blanc pour détacher du fond */
        border-radius: 50%;
        display: flex;
        align-items: center;
        justify-content: center;
      }

      /* On ajoute un vrai petit "+" à l'intérieur du badge */
      .plus-dot::after {
        content: '+';
        font-size: 10px;
        color: white;
        font-weight: bold;
        margin-top: -1px;
      }

      /* Effet au survol */
      .item-primary:hover .icon-stack {
        background-color: #321fdb;
        transform: scale(1.05);
      }

      .item-primary:hover .main-user-icon {
        color: white;
      }

      .item-primary:hover .plus-dot {
        background-color: #218838;
      }

      button[cDropdownItem][disabled] {
        cursor: not-allowed;
        pointer-events: none;
        display: flex;
        align-items: center;
        background: transparent !important;
      }

      /* Animation de la petite icône de cadenas */
      .text-warning {
        animation: pulse-warning 2s infinite;
      }

      @keyframes pulse-warning {
        0% {
          transform: scale(1);
          opacity: 1;
        }
        50% {
          transform: scale(1.1);
          opacity: 0.7;
        }
        100% {
          transform: scale(1);
          opacity: 1;
        }
      }

      /* Custom background pour l'avertissement */
      .bg-light {
        background-color: #f8f9fa !important;
      }

      ::ng-deep .custom-modal-container .modal-dialog {
        max-width: 1000px;
        margin: 1rem auto;
      }

      .body-scroll-container {
        max-height: 80vh;
        overflow-y: auto;
        background-color: #f4f7f9; /* Un gris très léger pour faire ressortir le blanc des cartes */
      }
    `,
  ],
})
export class WidgetsDropdownComponent implements OnInit, AfterContentInit {
  private changeDetectorRef = inject(ChangeDetectorRef);
  private authService = inject(AuthService);
  private jwtHelper = inject(JwtHelperService);
  private commandeService = inject(CommandeService); // Injecter le service commande
  private clientService = inject(ClientService); // Garder pour l'ID Client si besoin
  private cdr = inject(ChangeDetectorRef);

  // --- VARIABLES POUR COMMANDES ---
  public listCommandes: any[] = [];
  public visibleCommandeModal = false; // Pour la liste des commandes
  public visibleCreateCommande = false; // Pour le formulaire de création
  public imagePreview: string | null = null;

  public newCommande: any = {
    numeroCommande: '',
    dateCommande: '',
    montantTotal: 0,
    statut: '',
    clientId: '',
    photo: '',
  };

  public user$ = this.authService.user$;
  public isLoggedIn$ = this.user$.pipe(
    map((user: any) => {
      const token = user?.token;
      return !!token && !this.jwtHelper.isTokenExpired(token);
    })
  );

  @Input() items: any[] = [];
  @Input() icon: string = ''; // Reçoit "cilBell"
  @Input() badgeColor: string = 'primary';
  data: any[] = [];
  options: any[] = [];
  labels = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
    'January',
    'February',
    'March',
    'April',
  ];
  datasets = [
    [
      {
        label: 'My First dataset',
        backgroundColor: 'transparent',
        borderColor: 'rgba(255,255,255,.55)',
        pointBackgroundColor: getStyle('--cui-primary'),
        pointHoverBorderColor: getStyle('--cui-primary'),
        data: [65, 59, 84, 84, 51, 55, 40],
      },
    ],
    [
      {
        label: 'My Second dataset',
        backgroundColor: 'transparent',
        borderColor: 'rgba(255,255,255,.55)',
        pointBackgroundColor: getStyle('--cui-info'),
        pointHoverBorderColor: getStyle('--cui-info'),
        data: [1, 18, 9, 17, 34, 22, 11],
      },
    ],
    [
      {
        label: 'My Third dataset',
        backgroundColor: 'rgba(255,255,255,.2)',
        borderColor: 'rgba(255,255,255,.55)',
        pointBackgroundColor: getStyle('--cui-warning'),
        pointHoverBorderColor: getStyle('--cui-warning'),
        data: [78, 81, 80, 45, 34, 12, 40],
        fill: true,
      },
    ],
    [
      {
        label: 'My Fourth dataset',
        backgroundColor: 'rgba(255,255,255,.2)',
        borderColor: 'rgba(255,255,255,.55)',
        data: [78, 81, 80, 45, 34, 12, 40, 85, 65, 23, 12, 98, 34, 84, 67, 82],
        barPercentage: 0.7,
      },
    ],
  ];
  optionsDefault = {
    plugins: {
      legend: {
        display: false,
      },
    },
    maintainAspectRatio: false,
    scales: {
      x: {
        border: {
          display: false,
        },
        grid: {
          display: false,
          drawBorder: false,
        },
        ticks: {
          display: false,
        },
      },
      y: {
        min: 30,
        max: 89,
        display: false,
        grid: {
          display: false,
        },
        ticks: {
          display: false,
        },
      },
    },
    elements: {
      line: {
        borderWidth: 1,
        tension: 0.4,
      },
      point: {
        radius: 4,
        hitRadius: 10,
        hoverRadius: 4,
      },
    },
  };

  ngOnInit(): void {
    this.setData();
  }

  //creer un client
  public visibleCreate = false;
  public newClient: any = {
    nom: '',
    prenom: '',
    email: '',
    telephone: '',
    adresse: '',
    imagePath: '',
  };

  isSaving: boolean = false;

  toggleCreateModal() {
    this.visibleCreate = !this.visibleCreate;
    if (!this.visibleCreate) {
      this.imagePreview = null; // On vide l'aperçu
      this.newClient = {
        nom: '',
        prenom: '',
        email: '',
        telephone: '',
        adresse: '',
      };
    }
  }

  toggleCommandeModal() {
    this.visibleCommandeModal = !this.visibleCommandeModal;
    if (this.visibleCommandeModal) this.chargerCommandes();
  }

  getClientPhoto(clientId: any): string | null {
    // 1. Sécurité : vérifier si la liste existe
    if (!this.listClients || this.listClients.length === 0) {
      return null;
    }

    // 2. Recherche (== permet de comparer "1" et 1)
    const client = this.listClients.find((c) => c.id == clientId);

    // Debug : décommentez la ligne suivante pour voir le résultat dans la console F12
    // console.log(`Commande ID Client: ${clientId} | Trouvé:`, client);

    if (client && client.imagePath) {
      // Nettoyage au cas où imagePath commence déjà par un slash
      const path = client.imagePath.startsWith('/')
        ? client.imagePath
        : '/' + client.imagePath;
      return `http://localhost:59082${path}`;
    }

    return null;
  }

  chargerCommandes() {
    this.commandeService.getCommandes().subscribe((data) => {
      this.listCommandes = data;
      this.cdr.detectChanges();
    });
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      // Cette partie sert uniquement à afficher l'aperçu dans la modal
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result as string;
        this.cdr.detectChanges(); // Pour forcer la mise à jour visuelle
      };
      reader.readAsDataURL(file);
    }
  }

  saveClient(fileInput: HTMLInputElement) {
    const formData = new FormData();
    const fileToUpload = fileInput.files?.[0];

    // Préparation du FormData
    formData.append('Nom', this.newClient.nom || '');
    formData.append('Prenom', this.newClient.prenom || '');
    formData.append('Email', this.newClient.email || '');
    formData.append('Telephone', this.newClient.telephone || '');
    formData.append('Adresse', this.newClient.adresse || '');

    if (fileToUpload) {
      console.log('Fichier trouvé :', fileToUpload.name);
      formData.append('ImageFile', fileToUpload, fileToUpload.name);
    }

    // --- LOGIQUE D'ACTION ---
    const isUpdate = !!this.newClient.id;

    // IMPORTANT : On passe (id, formData) pour l'update, et juste (formData) pour le create
    const clientAction$ = isUpdate
      ? this.clientService.updateClient(this.newClient.id, formData)
      : this.clientService.createClient(formData);

    clientAction$.subscribe({
      next: (res) => {
        console.log('Réponse du serveur :', res);

        Swal.fire({
          title: isUpdate ? 'Client Modifié !' : 'Client Ajouté !',
          text: isUpdate
            ? 'Les modifications ont été enregistrées avec succès.'
            : 'Le nouveau client a été enregistré avec succès.',
          icon: 'success',
          timer: 2000,
          showConfirmButton: false,
          position: 'center',
          customClass: { popup: 'my-custom-popup-class' },
          didOpen: () => {
            const container = Swal.getContainer();
            if (container) container.style.zIndex = '9999';
          },
        });

        setTimeout(() => {
          this.visibleCreate = false;
          this.chargerClients();
          this.cdr.detectChanges();
        }, 0);
      },
      error: (err) => {
        console.error('Erreur serveur :', err);
        Swal.fire(
          'Erreur',
          "L'opération a échoué. Vérifiez la connexion au serveur.",
          'error'
        );
      },
    });
  }

  saveCommande(fileInput: HTMLInputElement) {
  // 1. DÉMARRAGE ET SÉCURITÉ
  this.isSaving = true;

  const userJson = localStorage.getItem('user');
  const userObj = userJson ? JSON.parse(userJson) : null;
  const token = userObj?.token || userObj?.accessToken;

  if (!token) {
    this.isSaving = false;
    Swal.fire('Session expirée', 'Veuillez vous reconnecter.', 'warning');
    return;
  }

  // 2. PRÉPARATION DES DONNÉES (FormData)
  const formData = new FormData();
  const file = fileInput.files?.[0];

  // Debug pour toi
  console.log("Données envoyées :", this.newCommande);

  // On utilise String() pour garantir que les types primitifs passent bien dans le FormData
  formData.append('NumeroCommande', String(this.newCommande.numeroCommande || 0));
  formData.append('DateCommande', String(this.newCommande.dateCommande || ''));
  formData.append('ClientId', String(this.newCommande.clientId || 0));
  formData.append('Statut', this.newCommande.statut || 'En attente');

  // FIX PRÉCIS POUR LE MONTANT :
  // On s'assure que c'est un nombre, on remplace la virgule par un point (standard API)
  const montantNettoye = String(this.newCommande.montantTotal || 0).replace(',', '.');
  formData.append('MontantTotal', Math.floor(this.newCommande.montantTotal).toString());

  if (file) {
    formData.append('PhotoFile', file, file.name);
  }

  // 3. LOGIQUE D'ACTION (Update vs Create)
  const isUpdate = !!this.newCommande.id;
  const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

  const action$ = isUpdate
    ? this.commandeService.updateCommande(this.newCommande.id, formData, headers)
    : this.commandeService.createCommande(formData, headers);

  // 4. EXÉCUTION
  action$.subscribe({
    next: (res) => {
      this.isSaving = false; // Libère le bouton

      Swal.fire({
        title: isUpdate ? 'Modifié !' : 'Ajouté !',
        text: 'La commande a été enregistrée avec succès.',
        icon: 'success',
        timer: 2000,
        showConfirmButton: false,
        didOpen: () => {
          if (Swal.getContainer()) Swal.getContainer()!.style.zIndex = '9999';
        }
      });

      // Nettoyage et fermeture
      setTimeout(() => {
        this.visibleCreateCommande = false;
        this.imagePreview = null;
        fileInput.value = ''; // Reset l'input file
        this.chargerCommandes();
        this.cdr.detectChanges();
      }, 0);
    },
    error: (err) => {
      this.isSaving = false; // Libère le bouton pour correction
      console.error('Détails de l’erreur serveur :', err);
      
      // Message d'erreur plus précis si possible
      const detail = err.error?.errors?.MontantTotal ? "Format du montant invalide." : "L'opération a échoué.";
      Swal.fire('Erreur', detail, 'error');
    }
  });
}

  selectedFile: File | null = null; // Le fichier à envoyer (si besoin)

  public visible = false; // Contrôle la visibilité de la modal
  public listClients: any[] = [];
  toggleModal() {
    this.visible = !this.visible;
    if (this.visible) {
      this.chargerClients();
    }
  }

  toggleCreateCommandeModal() {
    this.visibleCreateCommande = !this.visibleCreateCommande;
    if (!this.visibleCreateCommande) {
      this.imagePreview = null;
      this.newCommande = {
        numeroCommande: '',
        dateCommande: '',
        montantTotal: 0,
        statut: '',
        clientId: '',
      };
    }
  }

 updateCommande(id: number, commandeData: any) {
  if (id && commandeData) {
    Swal.fire({
      title: 'Mode Édition',
      text: `Chargement de la commande N° ${commandeData.numeroCommande}...`,
      icon: 'info',
      timer: 1000,
      showConfirmButton: false,
      position: 'top-end',
      toast: true,
      didOpen: () => {
        // 1. On clone les données pour ne pas modifier la ligne du tableau directement
        // On force l'ID pour être sûr que saveCommande sache que c'est une modification
        this.newCommande = { ...commandeData, id: id };

        // 2. DEBUG : Visualisation complète de l'objet (utiliser la virgule pour inspecter)
        console.log('Données chargées pour modification :', this.newCommande);

        // 3. FIX DATE : Formatage obligatoire pour <input type="date"> (doit être YYYY-MM-DD)
        if (this.newCommande.dateCommande) {
          // On prend la partie avant le 'T' (ex: "2024-05-20T00:00:00" -> "2024-05-20")
          this.newCommande.dateCommande = this.newCommande.dateCommande.split('T')[0];
        }

        // 4. FIX PHOTO : Construction de l'URL pour l'aperçu
        if (commandeData.photo) {
          const baseUrl = 'http://localhost:59082';
          // On vérifie si le chemin commence par '/' pour éviter le double slash
          const path = commandeData.photo.startsWith('/') ? commandeData.photo : '/' + commandeData.photo;
          
          this.imagePreview = `${baseUrl}${path}`;
          console.log('Aperçu de la photo chargée :', this.imagePreview);
        } else {
          this.imagePreview = null; // Affiche l'image par défaut si pas de photo
        }

        // 5. OUVERTURE : On affiche la modale
        this.visibleCreateCommande = true;

        // 6. STABILITÉ : On force Angular à voir les changements immédiatement
        this.cdr.detectChanges();
      },
    });
  } else {
    Swal.fire('Erreur', 'Impossible de récupérer les données.', 'error');
  }
}


getPhotoUrl(photoPath: string | null): string {
  // 1. Si pas de photo du tout, on utilise un service d'image de secours (puisque ton fichier local est en 404)
  if (!photoPath) {
    return 'https://ui-avatars.com/api/?name=C&background=0D6EFD&color=fff';
  }

  // 2. Si la photo est déjà une URL complète (ex: https://picsum...)
  if (photoPath.startsWith('http')) {
    return photoPath;
  }

  // 3. Construction de l'URL vers ton API .NET
  // On s'assure qu'il y a un seul slash entre le port et le chemin
  const baseUrl = 'http://localhost:59082';
  const separator = photoPath.startsWith('/') ? '' : '/';
  
  return `${baseUrl}${separator}${photoPath}`;
}

// 2. Si même après ça l'image est cassée (404), on force une image de secours
updateToDefault(event: any) {
  event.target.src = 'https://via.placeholder.com/140?text=No+Image';
}



  updateClient(id: number, clientData: any) {
  if (id && clientData) {
    Swal.fire({
      title: 'Mode Édition',
      text: `Chargement des données de ${clientData.nom}...`,
      icon: 'info',
      timer: 1000,
      showConfirmButton: false,
      position: 'top-end',
      toast: true,
      didOpen: () => {
        // 1. Copie des données du client
        this.newClient = { ...clientData, id: id };

        // 2. Gestion intelligente de la photo
        const path = clientData.imagePath; // Assure-toi que c'est bien imagePath ou photo dans ta DB

        if (path) {
          if (path.startsWith('http')) {
            // Cas A : C'est une URL externe (ex: Picsum)
            this.imagePreview = path;
          } else {
            // Cas B : C'est un fichier local sur ton serveur
            const baseUrl = 'http://localhost:59082';
            const separator = path.startsWith('/') ? '' : '/';
            this.imagePreview = `${baseUrl}${separator}${path}`;
          }
          console.log('Aperçu client chargé :', this.imagePreview);
        } else {
          this.imagePreview = null;
        }

        // 3. Affichage de la modale
        this.visibleCreate = true;
        this.cdr.detectChanges();
      },
    });
  } else {
    Swal.fire('Erreur', 'Impossible de charger les données du client.', 'error');
  }
}
  deleteClient(id: number) {
    Swal.fire({
      title: 'Supprimer ce client ?',
      text: 'Cette action est irréversible !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Oui, supprimer !',
      cancelButtonText: 'Annuler',
      reverseButtons: true,
      background: '#fff',
      // On utilise customClass pour appliquer nos styles personnels
      customClass: {
        popup: 'my-custom-popup-class',
      },
    }).then((result) => {
      if (result.isConfirmed) {
        this.clientService.deleteClient(id).subscribe({
          next: () => {
            this.listClients = this.listClients.filter((c) => c.id !== id);

            Swal.fire({
              title: 'Supprimé !',
              icon: 'success',
              timer: 1500,
              showConfirmButton: false,
              customClass: {
                popup: 'my-custom-popup-class',
              },
            });

            this.cdr.detectChanges();
          },
        });
      }
    });
  }

  deleteCommande(id: number) {
    Swal.fire({
      title: 'Supprimer ce client ?',
      text: 'Cette action est irréversible !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Oui, supprimer !',
      cancelButtonText: 'Annuler',
      reverseButtons: true,
      background: '#fff',
      // On utilise customClass pour appliquer nos styles personnels
      customClass: {
        popup: 'my-custom-popup-class',
      },
    }).then((result) => {
      if (result.isConfirmed) {
        this.commandeService.deleteCommande(id).subscribe({
          next: () => {
            this.listCommandes = this.listCommandes.filter((c) => c.id !== id);

            Swal.fire({
              title: 'Supprimé !',
              icon: 'success',
              timer: 1500,
              showConfirmButton: false,
              customClass: {
                popup: 'my-custom-popup-class',
              },
            });

            this.cdr.detectChanges();
          },
        });
      }
    });
  }

  chargerClients() {
    this.clientService.getClients().subscribe((data) => {
      this.listClients = data;
      this.cdr.detectChanges();
    });
  }

  ngAfterContentInit(): void {
    this.changeDetectorRef.detectChanges();
  }

  setData() {
    for (let idx = 0; idx < 4; idx++) {
      this.data[idx] = {
        labels: idx < 3 ? this.labels.slice(0, 7) : this.labels,
        datasets: this.datasets[idx],
      };
    }
    this.setOptions();
  }

  setOptions() {
    for (let idx = 0; idx < 4; idx++) {
      const options = JSON.parse(JSON.stringify(this.optionsDefault));
      switch (idx) {
        case 0: {
          this.options.push(options);
          break;
        }
        case 1: {
          options.scales.y.min = -9;
          options.scales.y.max = 39;
          options.elements.line.tension = 0;
          this.options.push(options);
          break;
        }
        case 2: {
          options.scales.x = { display: false };
          options.scales.y = { display: false };
          options.elements.line.borderWidth = 2;
          options.elements.point.radius = 0;
          this.options.push(options);
          break;
        }
        case 3: {
          options.scales.x.grid = { display: false, drawTicks: false };
          options.scales.x.grid = {
            display: false,
            drawTicks: false,
            drawBorder: false,
          };
          options.scales.y.min = undefined;
          options.scales.y.max = undefined;
          options.elements = {};
          this.options.push(options);
          break;
        }
      }
    }
  }
}

@Component({
  selector: 'app-chart-sample',
  template:
    '<c-chart type="line" [data]="data" [options]="options" width="300" #chart />',
  imports: [ChartjsComponent],
})
export class ChartSample implements AfterViewInit {
  private authService = inject(AuthService);
  private jwtHelper = inject(JwtHelperService);
  private clientService = inject(ClientService);
  private cdr = inject(ChangeDetectorRef);
  public user$ = this.authService.user$;
  public isLoggedIn$ = this.user$.pipe(
    map((user: any) => {
      const token = user?.token;
      return !!token && !this.jwtHelper.isTokenExpired(token);
    })
  );
  public listClients: any[] = [];
  public visible = false;
  public visibleCreate = false;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.chargerDonnees();
  }

  chargerDonnees(): void {
    this.clientService.getClients().subscribe({
      next: (data) => {
        this.listClients = data;
        console.log('Clients chargés dans le widget !');
      },
      error: (err) => console.error('Erreur API:', err),
    });
  }

  readonly chartComponent = viewChild.required<ChartjsComponent>('chart');

  colors = {
    label: 'My dataset',
    backgroundColor: 'rgba(77,189,116,.2)',
    borderColor: '#4dbd74',
    pointHoverBackgroundColor: '#fff',
  };

  labels = ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'];

  data = {
    labels: this.labels,
    datasets: [
      {
        data: [65, 59, 84, 84, 51, 55, 40],
        ...this.colors,
        fill: { value: 65 },
      },
    ],
  };

  options = {
    maintainAspectRatio: false,
    plugins: {
      legend: {
        display: false,
      },
    },
    elements: {
      line: {
        tension: 0.4,
      },
    },
  };

  ngAfterViewInit(): void {
    setTimeout(() => {
      const data = () => {
        return {
          ...this.data,
          labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May'],
          datasets: [
            {
              ...this.data.datasets[0],
              data: [42, 88, 42, 66, 77],
              fill: { value: 55 },
            },
            {
              ...this.data.datasets[0],
              borderColor: '#ffbd47',
              data: [88, 42, 66, 77, 42],
            },
          ],
        };
      };
      const newLabels = ['Jan', 'Feb', 'Mar', 'Apr', 'May'];
      const newData = [42, 88, 42, 66, 77];
      let { datasets, labels } = { ...this.data };
      // @ts-ignore
      const before = this.chartComponent()?.chart?.data.datasets.length;
      console.log('before', before);
      // console.log('datasets, labels', datasets, labels)
      // @ts-ignore
      // this.data = data()
      this.data = {
        ...this.data,
        datasets: [
          { ...this.data.datasets[0], data: newData },
          {
            ...this.data.datasets[0],
            borderColor: '#ffbd47',
            data: [88, 42, 66, 77, 42],
          },
        ],
        labels: newLabels,
      };
      // console.log('datasets, labels', { datasets, labels } = {...this.data})
      // @ts-ignore
      setTimeout(() => {
        const after = this.chartComponent()?.chart?.data.datasets.length;
        console.log('after', after);
      });
    }, 5000);
  }
}
