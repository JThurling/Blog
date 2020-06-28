import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagerComponent } from './components/pager/pager.component';
import {PaginationModule} from 'ngx-bootstrap/pagination';



@NgModule({
  declarations: [PagerComponent],
  exports: [
    PagerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ]
})
export class SharedModule { }
