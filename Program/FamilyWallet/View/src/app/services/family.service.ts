import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Family } from '../entities/family';
import { DefaultConstants } from '../constants/default-constants';

@Injectable({
  providedIn: 'root'
})
export class FamilyService {  
  private root = DefaultConstants.CONNECTION_PATH + '/family';

  constructor( 
    private http: HttpClient
  ) { }

  getFamilies() : Observable<Family[]> {
    return this.http.get<Family[]>( this.root );
  }

  getFamilyById(id : number) : Observable<Family> {
    return this.http.get<Family>( this.root + id );
  }

  
}
