import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'app-editor',
    templateUrl: './editor.component.html',
    //styleUrls: ['./editor.component.css']
})

export class EditorComponent {
    @Input() private content: string;

    @Output() private changedContent = new EventEmitter<string>();

    constructor() {

    }

    onContentChanged() {
        this.changedContent.emit(this.content);
    }
}
