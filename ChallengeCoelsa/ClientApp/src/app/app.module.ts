import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './public/nav-menu/nav-menu.component';
import { HomeComponent } from './public/home/home.component';
import { FetchDataComponent } from './public/fetch-data/fetch-data.component';
import { ContactListComponent } from './public/contact/contact-list.component';
import { CreateOrEditContactComponent } from './public/contact/createOrEdit/createOrEdit-contact.component';
import { ContactService } from './infraestructure/services/contact.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    ContactListComponent,
    CreateOrEditContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'contacts', component: ContactListComponent },
      { path: 'contacts/create', component: CreateOrEditContactComponent },
      { path: 'contacts/edit/:id', component: CreateOrEditContactComponent }
    ])
  ],
  providers: [
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
