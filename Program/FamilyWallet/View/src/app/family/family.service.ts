import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Family } from '../entities/family';
import { DefaultConstants } from '../constants/default-constants';
import { RequestPersonIdFamilyName } from '../view-models/request-person-id-family-name';
import { PersonFamily } from '../view-models/person-family';
import { FamilyWithPeople } from '../view-models/family-with-people';

@Injectable({
  providedIn: 'root'
})
export class FamilyService {  
  private root = DefaultConstants.CONNECTION_PATH + '/family';

  constructor( 
    private http: HttpClient
  ) { }

  getFamilies() : Observable<Family[]> {
    return this.http.get<Family[]>(this.root);
  }

  getFamilyById(id : number) : Observable<FamilyWithPeople> {
    return this.http.get<FamilyWithPeople>(this.root + id);
  }

  getFamiliesByPersonId(id : number) : Observable<Family[]> {
    return this.http.get<Family[]>(this.root + '/person' + id);
  }

  update(family : Family) : Observable<Family> {
    return this.http.put<Family>(this.root, family);
  }

  createFamilyByPerson(personFamily : RequestPersonIdFamilyName) : Observable<Family> {
    return this.http.post<Family>(this.root, personFamily);
  }

  addPersonToFamily(personFamily : PersonFamily) : Observable<Family>{
    return this.http.post<Family>(this.root, personFamily);
  }
}
