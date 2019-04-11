import { Component, OnInit } from '@angular/core';
import { Family } from 'src/app/view-models/family';
import { FamilyService } from 'src/app/services/family.service';

@Component({
  selector: 'app-families-by-person',
  templateUrl: './families-by-person.component.html',
  styleUrls: ['./families-by-person.component.css']
})
export class FamiliesByPersonComponent implements OnInit {    
  
  families : Family[];

  constructor(private familyService : FamilyService) { }

  ngOnInit() {
  }  

  getAll() : void {
    this.familyService.getFamilies().subscribe(families => this.families = families);
  }
}
