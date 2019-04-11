import { Component, OnInit } from '@angular/core';
import { FamilyService } from 'src/app/services/family.service';
import { Observable } from 'rxjs';
import { Family } from 'src/app/view-models/family';

@Component({
  selector: 'app-family',
  templateUrl: './family.component.html',
  styleUrls: ['./family.component.css']
})
export class FamilyComponent implements OnInit {

  families : Family[];

  constructor(private familyService : FamilyService) { }

  ngOnInit() {
  }

  getAll() : void {
    this.familyService.getFamilies().subscribe(families => this.families = families);
  }
}
