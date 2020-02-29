import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Issue } from '../../models/issue';
import { EditDialogComponent } from '../../dialogs/edit/edit.dialog.component';
import { DeleteDialogComponent } from '../../dialogs/delete/delete.dialog.component';
import { fromEvent} from 'rxjs';
import { IssuesDataSource } from '../../DataSources/issues-data-source.datasource';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-survey-model',
  templateUrl: './survey-model.component.html',
  styleUrls: ['./survey-model.component.css']
})
export class SurveyModelComponent implements OnInit {

  dataSource: IssuesDataSource | null;
  index: number;
  id: number;
  selection = new SelectionModel<Issue>(true, []);

  constructor(public httpClient: HttpClient, public dialog: MatDialog) { }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('filter', { static: true }) filter: ElementRef;

  ngOnInit() {
    this.loadData();
  }

  refresh() {
    this.loadData();
  }

  //addNew(issue: Issue) {

    //const dialogRef = this.dialog.open(AddDialogComponent, { data: { issue: issue } });

    //dialogRef.afterClosed().subscribe(result => {
    //  if (result === 1) {
    //    // After dialog is closed we're doing frontend updates
    //    // For add we're just pushing a new row inside DataService
    //    this.dataSource.dataService.dataChange.value.push(this.dataSource.dataService.getDialogData());
    //    this.refreshTable();
    //  }
    //});
  //}

  addNew() {
    //in real apps you call a function on the server to intialize
    this.dataSource.dataService.dataRows.value.unshift(new Issue());
    this.refreshTable();
  }

  // <button mat-icon-button (click)="startEdit(i, row.id, row.title, row.state, row.url, row.created_at, row.updated_at)">
  //startEdit(i: number, id: number, title: string, state: string, url: string, created_at: string, updated_at: string) {
  //  this.id = id;
  //  // index row is used just for debugging proposes and can be removed
  //  this.index = i;
  //  console.log(this.index);
  //  const dialogRef = this.dialog.open(EditDialogComponent, {
  //    data: { id: id, title: title, state: state, url: url, created_at: created_at, updated_at: updated_at }
  //  });

  //  dialogRef.afterClosed().subscribe(result => {
  //    if (result === 1) {
  //      // When using an edit things are little different, firstly we find record inside DataService by id
  //      const foundIndex = this.dataSource.dataService.dataRows.value.findIndex(x => x.id === this.id);
  //      // Then you update that record using data from dialogData (values you enetered)
  //      this.dataSource.dataService.dataRows.value[foundIndex] = this.dataSource.dataService.getDialogData();
  //      // And lastly refresh table
  //      this.refreshTable();
  //    }
  //  });
  //}

  startEdit() {
    this.selection.selected.forEach(selected => {
      //const foundIndex = this.dataSource.dataService.dataRows.value.findIndex(x => x.id === selected.id);
      // for delete we use splice in order to remove single object from DataService
      //this.dataSource.dataService.dataRows.value.splice(foundIndex, 1);
      
      this.refreshTable();
    });
  }

  //<button mat-icon-button (click)="deleteItem(i, row.id, row.title, row.state, row.url)">
  //deleteItem(i: number, id: number, title: string, state: string, url: string) {
    //this.index = i;
    //this.id = id;
    //const dialogRef = this.dialog.open(DeleteDialogComponent, {
    //  data: { id: id, title: title, state: state, url: url }
    //});

    //dialogRef.afterClosed().subscribe(result => {
    //  if (result === 1) {
    //    const foundIndex = this.dataSource.dataService.dataRows.value.findIndex(x => x.id === this.id);
    //    // for delete we use splice in order to remove single object from DataService
    //    this.dataSource.dataService.dataRows.value.splice(foundIndex, 1);
    //    this.refreshTable();
    //  }
    //});
  //}

  deleteItem() {
    this.selection.selected.forEach(selected => {
      const foundIndex = this.dataSource.dataService.dataRows.value.findIndex(x => x.id === selected.id);
         // for delete we use splice in order to remove single object from DataService
        this.dataSource.dataService.dataRows.value.splice(foundIndex, 1);
        this.refreshTable();
    });
  }

  private refreshTable() {
    // Refreshing table using paginator
    // Thanks yeager-j for tips
    // https://github.com/marinantonio/angular-mat-table-crud/issues/12
    this.paginator._changePageSize(this.paginator.pageSize);
  }

  public loadData() {
    this.dataSource = new IssuesDataSource(this.httpClient,this.paginator, this.sort);
    fromEvent(this.filter.nativeElement, 'keyup')
      // .debounceTime(150)
      // .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) {
          return;
        }
        this.dataSource.filter = this.filter.nativeElement.value;
      });
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.dataService.dataRows.value.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.dataService.dataRows.value.forEach(row => this.selection.select(row));
  }
}

