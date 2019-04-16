import { Component, OnInit } from '@angular/core';
import { Family } from 'src/app/entities/family';
import { FamilyService } from 'src/app/family/family.service';
import { getAllDebugNodes } from '@angular/core/src/debug/debug_node';

@Component({
  selector: 'app-families-by-person',
  templateUrl: './families-by-person.component.html',
  styleUrls: ['./families-by-person.component.css']
})
export class FamiliesByPersonComponent implements OnInit {    
  
  public families : Family[];

  constructor(private familyService : FamilyService) { }

  ngOnInit() {
    this.getAll();
  }  

  getAll() : void {
    this.familyService.getFamilies().subscribe(families => this.families = families);
  }
}
