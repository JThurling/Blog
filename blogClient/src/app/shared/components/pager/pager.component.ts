import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit {
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();
  @Input() totalCount: number;

  constructor() { }

  ngOnInit(): void {
  }

  onPageChange(event: any) {
    this.pageChanged.emit(event.page);
  }
}
