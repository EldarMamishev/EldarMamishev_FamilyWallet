import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Family } from '../entities/family';
import { DefaultConstants } from '../constants/default-constants';

@Injectable({
  providedIn: 'root'
})
export class FamilyService {
  constructor( 
    private http: HttpClient
  ) { }

  getFamilies() : Observable<Family[]> {
    return this.http.get<Family[]>( DefaultConstants.CONNECTION_PATH + '/family' )
  }
}
