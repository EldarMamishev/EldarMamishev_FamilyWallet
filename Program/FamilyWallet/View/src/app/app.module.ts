import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FamilyWithPeopleComponent } from './family/family-with-people/family-with-people.component';
import { AddPersonToFamilyComponent } from './family/add-person-to-family/add-person-to-family.component';
import { UpdateFamilyComponent } from './family/update-family/update-family.component';
import { CreateFamilyComponent } from './family/create-family/create-family.component';
import { FamiliesByPersonComponent } from './family/families-by-person/families-by-person.component';
import { FamilyModule } from './family/family.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FamilyModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
