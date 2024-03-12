import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { SearchComponent } from './shared/search/search.component';
import { PaginationComponent } from './shared/pagination/pagination.component';
import { ItemComponent } from './items/item/item.component';
import { ItemcardComponent } from './items/itemcard/itemcard.component';
import { NotfoundComponent } from './shared/notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateItemComponent } from './items/create-item/create-item.component';
import { DeletingModalComponent } from './shared/deleting-modal/deleting-modal.component';
import { AuthIntercetorService } from './services/auth-intercetor.service';
import { SpinnerComponent } from './shared/spinner/spinner.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ItemsComponent,
    NavbarComponent,
    FooterComponent,
    SearchComponent,
    PaginationComponent,
    ItemComponent,
    ItemcardComponent,
    NotfoundComponent,
    LoginComponent,
    CreateItemComponent,
    DeletingModalComponent,
    SpinnerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthIntercetorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
