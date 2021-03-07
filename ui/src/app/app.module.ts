import { FilterService } from './core/services/filter.service';
import { NotificationService } from './core/services/notification.service';
import { ReservationService } from './core/services/reservation.service';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RestaurantListComponent } from './components/restaurant-list/restaurant-list.component';
import { ManagementComponent } from './components/management/management.component';

import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { FilterComponent } from './components/filter/filter.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantListComponent,
    ManagementComponent,
    FilterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatTabsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule
  ],
  providers: [NotificationService, ReservationService, FilterService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
