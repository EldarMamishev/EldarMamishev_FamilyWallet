import { Component, OnInit } from '@angular/core';
import { FamilyService } from 'src/app/services/family.service';
import { FamilyWithPeople } from 'src/app/view-models/family-with-people';

@Component({
  selector: 'app-family-with-people',
  templateUrl: './family-with-people.component.html',
  styleUrls: ['./family-with-people.component.css']
})
export class FamilyWithPeopleComponent implements OnInit {

  family : FamilyWithPeople;

  constructor(private familyService : FamilyService) { }

  ngOnInit() {
  }

  getFamilyById(id : number) : void
  {
    this.familyService.getFamilyById(id).subscribe(family => this.family = family);
  }

}
