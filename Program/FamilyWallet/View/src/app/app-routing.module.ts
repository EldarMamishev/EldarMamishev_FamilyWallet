import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DefaultConstants } from './constants/default-constants';
import { FamiliesByPersonComponent } from './family/families-by-person/families-by-person.component';

const routes: Routes = [
  { path: DefaultConstants.CONNECTION_PATH + '/family', component: FamiliesByPersonComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
