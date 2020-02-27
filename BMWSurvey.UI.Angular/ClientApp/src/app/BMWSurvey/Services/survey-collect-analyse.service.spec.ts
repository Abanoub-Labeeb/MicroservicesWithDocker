import { TestBed } from '@angular/core/testing';

import { SurveyCollectAnalyseService } from './survey-collect-analyse.service';

describe('SurveyCollectAnalyseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SurveyCollectAnalyseService = TestBed.get(SurveyCollectAnalyseService);
    expect(service).toBeTruthy();
  });
});
