import { Component } from '@angular/core';
import { fadeInAnimation } from '../../../animations/animations'

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
  animations: [fadeInAnimation]
})

export class ContactComponent {

  constructor() {

  }
}
