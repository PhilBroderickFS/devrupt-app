import { GuestStatsComponent } from './components/guest-stats/guest-stats.component';
import { KitchenComponent } from './components/kitchen/kitchen.component';
import { MealSetComponent } from './components/meal-set/meal-set.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: KitchenComponent },
  { path: 'meal-set', component: MealSetComponent },
  { path: 'guest-stats', component: GuestStatsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
