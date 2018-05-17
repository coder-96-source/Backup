import { Component, OnInit, ViewChild } from '@angular/core';
import { MatProgressBar, MatButton, MatSnackBar } from '@angular/material';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { User } from '../../../models/dataModel/user';
import { UserService } from '../../../services/user.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    //styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    @ViewChild(MatProgressBar) private progressBar: MatProgressBar;
    @ViewChild(MatButton) private submitButton: MatButton;

    private signInFormControl: FormGroup;
    private isPasswordHide: boolean;

    constructor(private userService: UserService,
        private formBuilder: FormBuilder, private snackBar: MatSnackBar) {
        this.isPasswordHide = true; // default password hide mode
    }

    ngOnInit() {
        this.signInFormControl = this.formBuilder.group({
            name: ['', [<any>Validators.required, <any>Validators.maxLength(20)]],
            password: ['', [<any>Validators.required, <any>Validators.minLength(6), <any>Validators.maxLength(255)]]
        });
    }

    signIn() {
        const signInModel = this.signInFormControl.value as User
        this.userService.signIn(signInModel)
            .subscribe(res => {
                // Set session
                const user = res.user as User;
                const jwtToken = res.auth_token as string;
                this.userService.setUserSession(user, jwtToken);
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
