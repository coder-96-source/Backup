import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
    { path: 'register', component: RegistrationComponent },
    { path: 'login', component: LoginComponent },
]);