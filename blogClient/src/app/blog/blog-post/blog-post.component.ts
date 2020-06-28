import {Component, Input, OnInit} from '@angular/core';
import {IPosts} from '../../shared/models/posts';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.scss']
})
export class BlogPostComponent implements OnInit {
  @Input() blog: IPosts;

  constructor() { }

  ngOnInit(): void {
  }

}
