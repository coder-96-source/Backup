import {
    Component, OnInit, Input, Output, OnChanges, EventEmitter,
    trigger, state, style, animate, transition
} from '@angular/core';
import { Article } from '../../models/article';

@Component({
    selector: 'articleAnimation',
    templateUrl: './articleAnimation.component.html',
    styleUrls: ['./articleAnimation.component.css'],
    animations: [
        trigger('dialog', [
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
export class ArticleAnimationComponent implements OnInit {
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
