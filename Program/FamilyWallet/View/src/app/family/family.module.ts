import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FamilyRoutingModule } from './family-routing.module';
import { AddPersonToFamilyComponent } from './add-person-to-family/add-person-to-family.component';
import { UpdateFamilyComponent } from './update-family/update-family.component';
import { CreateFamilyComponent } from './create-family/create-family.component';
import { FamiliesByPersonComponent } from './families-by-person/families-by-person.component';
import { AllFamiliesComponent } from './all-families/all-families.component';

@NgModule({
  declarations: [
    AddPersonToFamilyComponent,
    UpdateFamilyComponent,
    CreateFamilyComponent,
    FamiliesByPersonComponent,
    AllFamiliesComponent
  ],
  imports: [
    FamilyRoutingModule,
    CommonModule
  ]
})
export class FamilyModule { }
