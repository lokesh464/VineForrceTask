import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { CountryComponent } from './country/country.component';
import { StateComponent } from './state/state.component';
import {TableModule} from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { DropdownModule } from 'primeng/dropdown';

@NgModule({
  declarations: [HomeComponent, StateComponent, CountryComponent],
  imports: [SharedModule, HomeRoutingModule, FormsModule, TableModule, ButtonModule, DialogModule, ToastModule, DropdownModule],
})
export class HomeModule {}
