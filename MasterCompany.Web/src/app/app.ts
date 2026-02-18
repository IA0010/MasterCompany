import { Component } from '@angular/core';
import { EmployeeListComponent } from './components/employee-list/employee-list';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EmployeeListComponent],
  template: '<app-employee-list></app-employee-list>'
})
export class AppComponent { }