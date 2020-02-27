import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SurveyComponent } from './BMWSurvey/Components/survey/survey.component';
import { SurveyModelComponent } from './BMWSurvey/Components/survey-model/survey-model.component';
import { SurveyContainerComponent } from './BMWSurvey/Components/survey-container/survey-container.component';
import { SurveyCollectAnalyseService } from './BMWSurvey/Services/survey-collect-analyse.service';
import { Survey } from './BMWSurvey/Models/survey.model';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AddDialogComponent } from './BMWSurvey/dialogs/add/add.dialog.component';
import { EditDialogComponent } from './BMWSurvey/dialogs/edit/edit.dialog.component';
import { DeleteDialogComponent } from './BMWSurvey/dialogs/delete/delete.dialog.component';
import { ReactiveFormsModule } from '@angular/forms';

import { DataService } from '../app/BMWSurvey/Services/data.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SurveyComponent,
    SurveyModelComponent,
    SurveyContainerComponent,
    AddDialogComponent,
    EditDialogComponent,
    DeleteDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    BrowserAnimationsModule,
    MatCheckboxModule,
    MatTableModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule,
    MatPaginatorModule,
    MatSortModule,
    MatToolbarModule,
    ReactiveFormsModule,
  ],
  providers: [SurveyCollectAnalyseService, Survey, DataService],
  bootstrap: [AppComponent],
  entryComponents: [AddDialogComponent, EditDialogComponent, DeleteDialogComponent]
})
export class AppModule { }
