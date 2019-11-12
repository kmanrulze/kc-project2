import {Component, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'ngbd-tooltip-customclass',
  templateUrl: './tooltip-customclass.html',
  encapsulation: ViewEncapsulation.None,
  styles: [`
    .table-character .tooltip-inner {
      background-color: darkgreen;
      font-size: 125%;
    }
    .table-character .arrow::before {
      border-top-color: darkgreen;
    }
  `]
})
export class NgbdTooltipCustomclass {
}
