import { HttpClient } from '@angular/common/http';
import { DataService } from '../services/data.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Issue } from '../Models/issue';
import { DataSource} from '@angular/cdk/collections';
import { BehaviorSubject, fromEvent, merge, Observable } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';

export class IssuesDataSource extends DataSource<Issue> {

  private readonly API_URL = 'https://api.github.com/repos/angular/angular/issues';
  columns: any[] = [
    { columnDef: 'select', header: 'select', width: 100 , cell: (issue: Issue, index: number) => `${issue.select}`, type: 'text' },
    { columnDef: 'id', header: 'id', width: 100, cell: (issue: Issue, index: number) => `${issue.id}`, type: 'number' },
    { columnDef: 'title', header: 'title', width: 100, cell: (issue: Issue, index: number) => `${issue.title}`, type: 'text' },
    { columnDef: 'state', header: 'state', width: 100, cell: (issue: Issue, index: number) => `${issue.state}`, type: 'text' },
    { columnDef: 'url', header: 'url', width: 100, cell: (issue: Issue, index: number) => `${issue.url}`, type: 'text' },
    { columnDef: 'created_at', header: 'created_at', width: 100, cell: (issue: Issue, index: number) => `${issue.created_at}`, type: 'text' },
    { columnDef: 'updated_at', header: 'updated_at', width: 100, cell: (issue: Issue, index: number) => `${issue.updated_at}`, type: 'text' },    
  ];

  displayedColumns = this.columns.map(c => c.columnDef);

  dataService: DataService<Issue> | null;
  _filterChange = new BehaviorSubject('');

  get filter(): string {
    return this._filterChange.value;
  }

  set filter(filter: string) {
    this._filterChange.next(filter);
  }

  filteredData: Issue[] = [];
  renderedData: Issue[] = [];

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  constructor(public httpClient: HttpClient, public _paginator: MatPaginator, public _sort: MatSort) {
    super();
    this.dataService = new DataService<Issue>(this.httpClient, this.API_URL);
    // Reset to the first page when the user changes the filter.
    this._filterChange.subscribe(() => this._paginator.pageIndex = 0);
  }


  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Issue[]> {
    // Listen for any changes in the base data, sorting, filtering, or pagination
    const displayDataChanges = [
      this.dataService.dataRows,
      this._sort.sortChange,
      this._filterChange,
      this._paginator.page
    ];

    this.dataService.getAllDataRows();


    return merge(...displayDataChanges)

      .pipe(
      map(() => {
        // Filter data
        this.filteredData = this.dataService.data.slice().filter((issue: Issue) => {
        const searchStr = (issue.id + issue.title + issue.url + issue.created_at).toLowerCase();
        return searchStr.indexOf(this.filter.toLowerCase()) !== -1;
      });

      // Sort filtered data
      const sortedData = this.sortData(this.filteredData.slice());

      // Grab the page's slice of the filtered sorted data.
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      this.renderedData = sortedData.splice(startIndex, this._paginator.pageSize);
      return this.renderedData;
    }
    ));
  }

  disconnect() { }


  /** Returns a sorted copy of the database data. */
  sortData(data: Issue[]): Issue[] {
    if (!this._sort.active || this._sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      let propertyA: number | string = '';
      let propertyB: number | string = '';

      switch (this._sort.active) {
        case 'id': [propertyA, propertyB] = [a.id, b.id]; break;
        case 'title': [propertyA, propertyB] = [a.title, b.title]; break;
        case 'state': [propertyA, propertyB] = [a.state, b.state]; break;
        case 'url': [propertyA, propertyB] = [a.url, b.url]; break;
        case 'created_at': [propertyA, propertyB] = [a.created_at, b.created_at]; break;
        case 'updated_at': [propertyA, propertyB] = [a.updated_at, b.updated_at]; break;
      }

      const valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      const valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction === 'asc' ? 1 : -1);
    });
  }
}
