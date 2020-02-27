import { Component, OnInit, Input } from '@angular/core';
import { Survey } from '../../Models/survey.model';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {

  //try to think of away to deign on the way of datasource and data members
  //suggestion
  //you will create an object from a custome model class called TypeName
  //and this object will take the name of your ViewModel Class which contain the views and instantiate an object from it
  //create another model class called DataMember and each viewModel inherit from it
  //in every component put the reference to an object from the type DataMember and the component on init will cast it according to the TypeName
  //and use it to put a fields according to his name
  @Input('DataSource') ds: Survey;
  constructor() {
    
  }

  ngOnInit() {
    //for testing purposes
    //console.log(this.ds.Age);
  }

}
