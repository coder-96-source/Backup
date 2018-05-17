import { Component, OnInit, ViewChild } from '@angular/core';
import { MatProgressBar, MatButton, MatSnackBar } from '@angular/material';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { User } from '../../../models/dataModel/user';
import { UserService } from '../../../services/user.service';
import { PasswordValidator } from '../../../directives/password-validator';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    //styleUrls: ['./registration.component.css']
})

export class RegistrationComponent {
    @ViewChild(MatProgressBar) progressBar: MatProgressBar;
    @ViewChild(MatButton) submitButton: MatButton;

    private signUpFormControl: FormGroup;
    private isPasswordHide: boolean;

    constructor(private userService: UserService,
        private formBuilder: FormBuilder, private snackBar: MatSnackBar) {
        this.isPasswordHide = true; // default password hide mode
    }

    ngOnInit() {
        this.signUpFormControl = this.formBuilder.group({
            name: ['', [<any>Validators.required, <any>Validators.maxLength(20)]],
            password: ['', [<any>Validators.required, <any>Validators.minLength(6), <any>Validators.maxLength(255)]],
            confirmPassword: ['', [<any>Validators.required, <any>Validators.minLength(6), <any>Validators.maxLength(255)]],
            isAgreed: ['', [<any>Validators.required, <any>Validators.requiredTrue]]
        }, { validator: PasswordValidator.MatchPassword });
    }

    signUp() {
        let signUpModel = new User;
        signUpModel.name = this.signUpFormControl.value.name as string;
        signUpModel.password = this.signUpFormControl.value.password as string;

        this.userService.signUp(signUpModel)
            .subscribe(res => {
                this.userService.navigateHome();
            },
            error => {
                // Refresh form status
                this.submitButton.disabled = false;
                this.progressBar.mode = 'determinate';

                this.openSnackBark(error, 'Error');
            });

        this.submitButton.disabled = true;
        this.progressBar.mode = 'indeterminate';
    }

    openSnackBark(notificationMessage: string, actionMessage: string) {
        this.snackBar.open(notificationMessage, actionMessage, {
            duration: 2000
        });
    }
}