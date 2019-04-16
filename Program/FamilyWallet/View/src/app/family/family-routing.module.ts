import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CONNECTION_PATH } from '../constants/default-constants';
import { FamiliesByPersonComponent } from './families-by-person/families-by-person.component';
import { AllFamiliesComponent } from './all-families/all-families.component';

const routes: Routes = [
  { path: '', redirectTo: 'family/', pathMatch: 'full' },

  { path: 'family/', component: AllFamiliesComponent},
  { path: 'family/person', component: FamiliesByPersonComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class FamilyRoutingModule { }
