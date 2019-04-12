import { Component, OnInit } from '@angular/core';
import { FamilyService } from 'src/app/services/family.service';
import { Observable } from 'rxjs';
import { Family } from 'src/app/entities/family';

@Component({
  selector: 'app-family',
  templateUrl: './family.component.html',
  styleUrls: ['./family.component.css']
})
export class FamilyComponent implements OnInit {
  
  constructor() { }

  ngOnInit() {
  }
}
 