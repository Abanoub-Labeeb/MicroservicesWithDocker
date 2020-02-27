import { Enums } from '../Constants/enums';
import { SurveyModel } from './survey-model.model';
import { Injectable } from "@angular/core";

@Injectable()
export class Survey {
  Age: number;
  Gender: Enums.Gender;
  OwnLicence: Enums.OwnLicence;
  FirstCar: Enums.YesNo;
  DriveTrain: Enums.DriveTrain;
  Drifting: Enums.YesNo;
  NumberOfBMWs: number;
  Details: string;
  ReturnFlag: Enums.ReturnFlag;
  Models: Array<SurveyModel>;
}
