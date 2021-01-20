import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './public/nav-menu/nav-menu.component';
import { ContactListComponent } from './public/contact/contact-list.component';
import { CreateOrEditContactComponent } from './public/contact/createOrEdit/createOrEdit-contact.component';
import { ContactService } from './infraestructure/services/contact.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ContactListComponent,
    CreateOrEditContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'contacts', pathMatch: 'full' },
      { path: 'contacts', component: ContactListComponent },
      { path: 'contacts/create', component: CreateOrEditContactComponent },
      { path: 'contacts/edit/:contactId', component: CreateOrEditContactComponent }
    ])
  ],
  providers: [
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
