import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { NotfoundComponent } from './shared/notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import { ItemComponent } from './items/item/item.component';
import { CreateItemComponent } from './items/create-item/create-item.component';
import { AuthGuardService } from './services/auth-guard.service';
import { CanDeactivateGuard } from './services/can-deactivate-gaurd.service';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'items',
    component: ItemsComponent,
  },
  {
    path: 'items/create/:id',
    component: CreateItemComponent,
    canActivate: [AuthGuardService],
    canDeactivate: [CanDeactivateGuard],
  },
  { path: 'items/:id', component: ItemComponent },
  { path: 'login', component: LoginComponent },
  { path: 'notfound', component: NotfoundComponent },
  { path: '**', redirectTo: 'notfound' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
