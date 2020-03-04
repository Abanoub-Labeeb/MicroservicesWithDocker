import { Component, ElementRef, OnInit, ViewChild, Renderer2, ContentChildren} from '@angular/core';
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
import { FormControl, FormArray, FormGroup, Validators } from '@angular/forms';
import { MatTable, MatHeaderCell, MatCell } from '@angular/material/table';
import { AfterViewInit, HostListener} from '@angular/core';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-survey-model',
  templateUrl: './survey-model.component.html',
  styleUrls: ['./survey-model.component.css'],
})
export class SurveyModelComponent implements OnInit {

  dataSource: IssuesDataSource | null;
  index: number;
  id: number;
  selection = new SelectionModel<Issue>(true, []);

  constructor(public httpClient: HttpClient, public dialog: MatDialog, private renderer: Renderer2) { }


  @ViewChild(MatTable, { read: ElementRef, static: true }) private matTableRef: ElementRef;
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
    const index = this.dataSource.dataService.dataRows.value.unshift(new Issue());
    this.selection.select(this.dataSource.dataService.dataRows.value[0]);
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

  startEdit(i: number) {
    /**
    let foundIndex: Number = -1;
    foundIndex = this.dataSource.dataService.dataRows.value.findIndex(x => x.id === selected.id);
    this.selection.selected.forEach(selected => {
      
    });

    if (foundIndex === -1) {
      return false;
    } else {
      return true;
    }
    */
    return false;
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
      this.selection.clear();
      //this.selection.selected.splice(foundIndex, 1);
      //const x = this.dataSource.dataService.dataRows.value.find(x => x.id === selected.id);
      //console.log(x.title + "." + selected.title);
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
    let columnConfig;


    if (!isNullOrUndefined(this.dataSource)) {
      columnConfig = this.dataSource.columns;
    }

    //in case of refresh we must render based on widths of old table
    //  columnConfig = this.dataSource.columns;
    this.dataSource = new IssuesDataSource(this.httpClient, this.paginator, this.sort);

    if (!isNullOrUndefined(columnConfig)) {
      this.dataSource.columns = columnConfig;
      this.selection.clear();
    }
    

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
    const numRows     = this.dataSource.dataService.dataRows.value.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ? this.selection.clear() :
                           this.dataSource.dataService.dataRows.value.forEach(row => this.selection.select(row));    
  } 

  getToolTipData(id: string): string {
    return `Please select the row to edit`;
  }


/**Resizable**/
  pressed = false;
  currentResizeIndex: number;
  startX: number;
  startWidth: number;
  isResizingRight: boolean;
  resizableMousemove: () => void;
  resizableMouseup: () => void;


  //used to intialize the column sized from the provided array
  ngAfterViewInit() {
    this.setTableResize(this.matTableRef.nativeElement.clientWidth);
  }

  setTableResize(tableWidth: number) {
    let columnsTotalWidth = 0;
    this.dataSource.columns.forEach((column) => {
      columnsTotalWidth += column.width;
    });
    
    const scale = (tableWidth - this.dataSource.columns.length) / columnsTotalWidth;
    this.dataSource.columns.forEach((column) => {
      column.width *= scale;
    });
  }

  

  
  onResizeColumn(event: any, index: number) {
    this.checkResizing(event, index);
    this.currentResizeIndex = index;
    this.pressed = true;
    this.startX = event.pageX;
    this.startWidth = event.target.clientWidth;
    event.preventDefault();
    this.mouseMove(index);
  }

  private checkResizing(event, index) {
    const cellData = this.getCellData(index);
    if ((index === 0) || (index === this.dataSource.columns.length - 1) || (Math.abs(event.pageX - cellData.right) < cellData.width / 2 && index !== this.dataSource.columns.length - 1)) {
      this.isResizingRight = true;
    } else {
      this.isResizingRight = false;
    }
  }

  private getCellData(index: number) {
    const headerRow = this.matTableRef.nativeElement.children[0];
    const cell = headerRow.children[index];
    return cell.getBoundingClientRect();
  }

  mouseMove(index: number) {
    this.resizableMousemove = this.renderer.listen('document', 'mousemove', (event) => {
      if (this.pressed && event.buttons) {
        const dx = (this.isResizingRight) ? (event.pageX - this.startX) : (-event.pageX + this.startX);
        const width = this.startWidth + dx;
        if (this.currentResizeIndex === index && width > 50) {
          this.setColumnWidthChanges(index, width);
        }
      }
    });
    this.resizableMouseup = this.renderer.listen('document', 'mouseup', (event) => {
      if (this.pressed) {
        this.pressed = false;
        this.currentResizeIndex = -1;
        this.resizableMousemove();
        this.resizableMouseup();
      }
    });
  }

  setColumnWidthChanges(index: number, width: number) {

   //you can uncomment the next code if you wish the width of all columns together to be fixed
   //aka if you stretch one you decrease another
   // const orgWidth = this.dataSource.columns[index].width;
   // const dx = width - orgWidth;
   // if (dx !== 0) {

   //   const j = (this.isResizingRight) ? index + 1 : index - 1;
   //   const newWidth = this.dataSource.columns[j].width - dx;
   //  if (newWidth > 10) {
     if (width > 10) {
        this.dataSource.columns[index].width = width;
        //this.setColumnWidth(this.dataSource.columns[index]);
        //this.dataSource.columns[j].width = newWidth;
        //this.setColumnWidth(this.dataSource.columns[j]);
      }
   // }
  }

  /*
  setColumnWidth(column: any) {
    const columnEls = Array.from(document.getElementsByClassName('mat-column-' + column.columnDef));
    columnEls.forEach((el: HTMLDivElement) => {
      el.style.width = column.width + 'px';
    });
  }
  */

  //used to execute function based on event happened in the client side 
  /*
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.setTableResize(this.matTableRef.nativeElement.clientWidth);
  }
  */
}

