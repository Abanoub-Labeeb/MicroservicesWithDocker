import { Component, OnInit } from '@angular/core';
import { Survey } from '../../Models/survey.model';

@Component({
  selector: 'app-survey-container',
  templateUrl: './survey-container.component.html',
  styleUrls: ['./survey-container.component.css']
})
export class SurveyContainerComponent implements OnInit {

  constructor(public survey: Survey) {
    survey.Age = 50;
  }

  ngOnInit() {
  }

  onSubmit() {
    alert(this.survey.Age.toString());
  }
}
