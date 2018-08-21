import { NgModule } from '@angular/core';

import { ContactComponent } from './contact.component';

import { SharedModule } from '../../../shared.module';
import { ContactRoutingModule } from './contact.routing';

@NgModule({
  declarations: [
    ContactComponent
  ],
  imports: [
    SharedModule,
    ContactRoutingModule
  ],
  exports: [

  ],
  providers: [

  ]
})
export class ContactModule { }
