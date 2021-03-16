import { InMemoryReservationService } from './core/services/in-memory-reservation.service';
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

import { HttpClientInMemoryWebApiModule  } from 'angular-in-memory-web-api';
import { HttpClientModule } from '@angular/common/http';
import { KitchenComponent } from './components/kitchen/kitchen.component';
import { CalenderSliderComponent } from './components/calender-slider/calender-slider.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantListComponent,
    ManagementComponent,
    FilterComponent,
    KitchenComponent,
    CalenderSliderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatTabsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    HttpClientModule,
    // TODO Only used in test - remove when ready to pull data from backend
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryReservationService, {dataEncapsulation: false}
    )
  ],
  providers: [NotificationService, ReservationService, FilterService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
