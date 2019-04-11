import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FamilyComponent } from './components/family/family.component';
import { FamilyWithPeopleComponent } from './components/family-components/family-with-people/family-with-people.component';
import { AddPersonToFamilyComponent } from './components/family-components/add-person-to-family/add-person-to-family.component';
import { UpdateFamilyComponent } from './components/family-components/update-family/update-family.component';
import { CreateFamilyComponent } from './components/family-components/create-family/create-family.component';
import { FamiliesByPersonComponent } from './components/family-components/families-by-person/families-by-person.component';

@NgModule({
  declarations: [
    AppComponent,
    FamilyComponent,
    FamilyWithPeopleComponent,
    AddPersonToFamilyComponent,
    UpdateFamilyComponent,
    CreateFamilyComponent,
    FamiliesByPersonComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
