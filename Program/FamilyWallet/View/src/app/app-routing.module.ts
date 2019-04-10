import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FamilyComponent } from './components/family/family.component';
import { DefaultConstants } from './constants/default-constants';

const routes: Routes = [
  { path: DefaultConstants.CONNECTION_PATH + '/family', component: FamilyComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
