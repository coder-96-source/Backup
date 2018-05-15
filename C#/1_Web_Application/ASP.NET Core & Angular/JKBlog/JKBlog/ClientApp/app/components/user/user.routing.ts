import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

export const UserRouterModule: ModuleWithProviders = RouterModule.forChild([
    { path: 'signup', component: RegistrationComponent },
    { path: 'signin', component: LoginComponent },
]); 