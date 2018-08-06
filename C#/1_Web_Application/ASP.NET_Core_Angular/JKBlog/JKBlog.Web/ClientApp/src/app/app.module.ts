import { NgModule } from '@angular/core';
import { MainModule } from './components/main/main.module';
import { SharedModule } from './shared.module';

import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    MainModule,
    SharedModule,

    AppRoutingModule
  ],
  providers: [

  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
