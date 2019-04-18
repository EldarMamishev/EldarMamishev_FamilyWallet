import { Component, OnInit } from '@angular/core';
import { FamilyService } from '../family.service';
import { RequestPersonIdFamilyName } from 'src/app/view-models/request-person-id-family-name';
import { USER_ID } from 'src/app/constants/default-constants';
import { getAllDebugNodes } from '@angular/core/src/debug/debug_node';

@Component({
  selector: 'app-create-family',
  templateUrl: './create-family.component.html',
  styleUrls: ['./create-family.component.css']
})
export class CreateFamilyComponent implements OnInit {
  //TODO change from constant UserID to getCurrentUser()
  public family : RequestPersonIdFamilyName = { FamilyName: "", PersonID: USER_ID };

  constructor(private familyService : FamilyService) { }

  ngOnInit() {
  }
  
  createFamily() : void
  {
    this.familyService.createFamilyByPerson(this.family).toPromise();
  }

}
