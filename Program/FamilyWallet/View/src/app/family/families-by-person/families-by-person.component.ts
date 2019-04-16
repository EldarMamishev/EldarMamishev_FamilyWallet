import { Component, OnInit } from '@angular/core';
import { Family } from 'src/app/entities/family';
import { FamilyService } from 'src/app/family/family.service';
import { AppService } from 'src/app/app.service';
import { getAllDebugNodes } from '@angular/core/src/debug/debug_node';
import { USER_ID } from 'src/app/constants/default-constants';

@Component({
  selector: 'app-families-by-person',
  templateUrl: './families-by-person.component.html',
  styleUrls: ['./families-by-person.component.css']
})
export class FamiliesByPersonComponent implements OnInit {    
  
  public families : Family[];
  public selectedFamily : Family;
  
  constructor(private familyService : FamilyService) { }

  ngOnInit() {
    this.getByPersonId(USER_ID);
  }  

  getByPersonId(id: number) : void {
    this.familyService.getFamiliesByPersonId(id).subscribe(families => this.families = families);
  }

  getFamilyById(id : number) : void
  {
    this.familyService.getFamilyById(id).subscribe(family => this.selectedFamily = family);
  }
}
