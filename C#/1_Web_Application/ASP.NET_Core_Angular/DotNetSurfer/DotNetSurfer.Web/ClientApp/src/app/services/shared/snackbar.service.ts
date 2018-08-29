import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

export enum SnackbarAction {
  Load,
  Create,
  Update,
  Delete,
  Error
}

@Injectable()
export class SnackbarService {

  public constructor(private snackBar: MatSnackBar) {

  }

  public openSnackBar(message: string, snackbarAction: SnackbarAction) {
    this.snackBar.open(message, SnackbarAction[snackbarAction], {
      duration: 2000
    });
  }
}
