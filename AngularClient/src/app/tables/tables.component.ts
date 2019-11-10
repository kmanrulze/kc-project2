import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.css']
})
export class TablesComponent {
  closeResult: string;

  constructor(public auth: AuthService, public dbnd: DbndService, private modalService: NgbModal) {}
  mode = 'gameSelection';
  form = 'new';
  openCreate(createTable) {
    this.modalService.open(createTable, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      // POST form data to /api/games (or something)
      // Create alert upon success
      // Update list on page
      this.closeResult = `Closed with: ${result}`;
      console.log(this.closeResult);
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  submitCreate() {

  }

  openJoin(joinTable) {
    this.modalService.open(joinTable, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      // POST form data to /api/games/join/{id} (or something)
      // Create alert upon success
      // Update list on page
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

    console.log(this.closeResult);
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}
