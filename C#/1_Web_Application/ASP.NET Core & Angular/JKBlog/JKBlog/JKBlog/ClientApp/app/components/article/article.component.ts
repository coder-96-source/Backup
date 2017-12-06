import { Component, Input } from '@angular/core';

@Component({
    selector: 'article',
    templateUrl: './article.component.html',
    styleUrls: ['./article.component.css']
})
export class ArticleComponent {
    @Input() datasource: any;
    selectedImage: any;

    setSelectedImage(image: any) {
        this.selectedImage = image;
    }

    navigate(forward: any) {
        var index = this.datasource.indexOf(this.selectedImage) + (forward ? 1 : -1);
        if (index >= 0 && index < this.datasource.length) {
            this.selectedImage = this.datasource[index];
        }
    }
}
