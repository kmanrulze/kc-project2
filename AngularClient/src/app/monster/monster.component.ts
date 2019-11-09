import { Component, OnInit } from '@angular/core';
import { RestService } from '../_services/DnDApi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-monster',
  templateUrl: './monster.component.html',
  styleUrls: ['./monster.component.css']
})
export class MonsterComponent implements OnInit {
  monster:any = []

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getMonster();
  }
  getMonster()
  {
    this.monster = [];
    this.rest.getMonster(3).subscribe((data:{}) => {
      console.log(data);
      this.monster = data;
    });
  }

}
