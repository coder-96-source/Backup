import {
    Component, OnInit, Input, Output, OnChanges, EventEmitter,
    trigger, state, style, animate, transition
} from '@angular/core';
import { Article } from '../../models/dataModel/article';

@Component({
    selector: 'app-article-popup',
    templateUrl: './article-popup.component.html',
    styleUrls: ['./article-popup.component.css'],
    animations: [
        trigger('popup', [
            transition('void => *', [
                style({ transform: 'scale3d(.3, .3, .3)' }),
                animate(100)
            ]),
            transition('* => void', [
                animate(100, style({ transform: 'scale3d(.0, .0, .0)' }))
            ])
        ])
    ]
})
export class ArticlePopupComponent implements OnInit {
    @Input() article: Article;

    @Output() visibleChange: EventEmitter<boolean>
    = new EventEmitter<boolean>
        ();

    constructor() { }

    ngOnInit() { }

    close() {
        this.article.visible = false;
        this.visibleChange.emit(this.article.visible);
    }
}
