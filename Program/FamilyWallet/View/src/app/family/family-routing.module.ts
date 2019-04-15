import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefaultConstants } from '../constants/default-constants';
import { FamiliesByPersonComponent } from './families-by-person/families-by-person.component';

const routes: Routes = [
  { path: '', redirectTo: 'person', pathMatch: 'full' },

  { path: 'person', component: FamiliesByPersonComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class FamilyRoutingModule { }
