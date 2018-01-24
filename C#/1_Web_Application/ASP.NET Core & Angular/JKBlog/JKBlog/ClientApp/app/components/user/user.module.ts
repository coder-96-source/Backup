import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { UserService } from '../../services/user.service';

import { routing } from './user.routing';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';

@NgModule({
    imports: [
        CommonModule, FormsModule, routing,
    ],
    declarations: [RegistrationComponent, LoginComponent],
    providers: [UserService]
})
export class UserModule { }
