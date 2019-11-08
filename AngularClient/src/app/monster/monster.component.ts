import { Component, OnInit } from '@angular/core';
import { RestService } from '../_services/DnDApi/rest.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-monster',
  templateUrl: './monster.component.html',
  styleUrls: ['./monster.component.css']
})
export class MonsterComponent implements OnInit {
  monsters:any = []

  constructor(public rest:RestService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.getMonsters();
  }
  getMonsters()
  {
    this.monsters = [];
    this.rest.getMonsters().subscribe((data:{}) => {
      console.log(data);
      this.monsters = data;
    });
  }

}
