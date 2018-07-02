import { NgModule } from '@angular/core';

import { AboutModule } from './about/about.module';
import { ContactModule } from './contact/contact.module';

@NgModule({
  declarations: [

  ],
  imports: [
    AboutModule,
    ContactModule
  ],
  exports: [
    ContactModule
  ],
  providers: [

  ]
})
export class MainModule { }
