import { Component, OnInit } from '@angular/core';

export interface PeriodicElement {
  question: string;
  num: number;
  actual: any;
  ideal: any;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {num: 1, question: 'What dfcevf v.... e fe f', actual: 1.0079, ideal: 79},
  {num: 2, question: 'Which bla bl......', actual: 4.0026, ideal: 79},
  {num: 3, question: 'Why .....', actual: 'this', ideal: 'that'},
  // {num: 4, question: 'Beryllium', actual: 9.0122, ideal: 79},
  // {num: 5, question: 'Boron', actual: 10.811, ideal: 79},
  // {num: 6, question: 'Carbon', actual: 12.0107, ideal: 79},
  // {num: 7, question: 'Nitrogen', actual: 14.0067, ideal: 79},
  // {num: 8, question: 'Oxygen', actual: 15.9994, ideal: 79},
  // {num: 9, question: 'Fluorine', actual: 18.9984, ideal: 79},
  // {num: 10, question: 'Neon', actual: 20.1797, ideal: 79},
];

@Component({
  selector: 'app-result-table',
  templateUrl: './result-table.component.html',
  styleUrls: ['./result-table.component.css']
})
export class ResultTableComponent implements OnInit {


  constructor() {

  }

  ngOnInit() {

  }
  displayedColumns: string[] = ['num', 'question', 'actual', 'ideal'];
  dataSource = ELEMENT_DATA;
}


