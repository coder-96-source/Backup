import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Component({
    selector: 'app-picture-uploader',
    templateUrl: './picture-uploader.component.html',
    //styleUrls: ['./picture-uploader.component.css']
})

export class PictureUploaderComponent implements OnInit {
    @Input() private picture: string;
    @Input() private pictureMimeType: string;

    @Output() private uploadedPicture = new EventEmitter<string>();

    private pictureSrc: string;

    private uploadedPictureFile: File;
    private uploadedPictureSrc: string;

    private acceptedExtension: string;
    private acceptedPattern: RegExp;

    private isBrowsable: boolean;
    private isUploaded: boolean;
    private isCancelable: boolean;
    private isRemovable: boolean;

    private currentPictureSrc: string;
    private currentStatus: string;

    constructor(
        private snackBar: MatSnackBar
    ) { }

    ngOnInit() {
        if (this.picture != undefined) {
            this.pictureSrc = 'data:' + this.pictureMimeType + ';base64,' + this.picture; // src format: data:image/png;base64,iVBO~
        }
        this.acceptedExtension = 'image/*'; // to check file input
        this.acceptedPattern = /image-*/; // to check after browsing
        this.isBrowsable = true;
        this.isRemovable = true;
        this.currentPictureSrc = this.pictureSrc;
        this.currentStatus = 'Unselected';
    }

    fileInputOnChange(e) {
        this.uploadedPictureFile = e.dataTransfer ? e.dataTransfer.files[0] : e.target.files[0];

        if (!this.uploadedPictureFile.type.match(this.acceptedPattern)) {
            this.openSnackBark('Please Select Image Files' ,'Upload')
            return;
        }

        this.isUploaded = true;
        this.currentStatus = 'Selected';
    }

    uploadPicture() {
        const fileReader = new FileReader();
        fileReader.onloadend = (e) => {
            this.uploadedPictureSrc = fileReader.result;
            this.uploadedPictureSrc.includes('base64') // to avoid indexOutOfRange
                ? this.uploadedPicture.emit(this.uploadedPictureSrc.split('base64,')[1]) // base64 string
                : this.uploadedPicture.emit(undefined);

            this.isUploaded = false;
            this.isCancelable = true;
            this.currentPictureSrc = this.uploadedPictureSrc;
            this.currentStatus = 'Uploaded';
        }
        fileReader.readAsDataURL(this.uploadedPictureFile);       
    }

    cancelPicture() {
        this.isBrowsable = true;
        this.isCancelable = false;
        this.uploadedPicture.emit(this.picture); // revert to input picture
        this.currentPictureSrc = this.pictureSrc;
        this.currentStatus = 'Canceled';
    }

    removePicture() {
        this.isUploaded = false;
        this.isBrowsable = false;
        this.isCancelable = true;
        this.uploadedPicture.emit(undefined);    
        this.currentPictureSrc = '';
        this.currentStatus = 'Removed';
    }

    openSnackBark(notificationMessage: string, actionMessage: string) {
        this.snackBar.open(notificationMessage, actionMessage, {
            duration: 2000
        });
    }
}
