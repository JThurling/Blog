import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {IPosts} from '../shared/models/posts';
import {IAuthor} from '../shared/models/postAuthor';
import {ITag} from '../shared/models/postTag';
import {ICategory} from '../shared/models/postCategory';
import {BlogService} from './blog.service';
import {BlogParameters} from '../shared/models/blogParameters';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  posts: IPosts[];
  authors: IAuthor[];
  tag: ITag[];
  categories: ICategory[];
  blogParameters = new BlogParameters();
  sortOptions = [
    {name: 'Latest', value: 'latest'},
    {name: 'Oldest', value: 'oldest'},
  ];
  totalCount: number;

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.getPosts();
    this.getTags();
    this.getAuthors();
    this.getCategories();
  }

  getPosts(){
    this.blogService.getPosts(this.blogParameters).subscribe(response => {
      this.posts = response.blogList;
      this.blogParameters.pageNumber = response.pageIndex;
      this.blogParameters.pageSize = response.pageSize;
      this.totalCount = response.count;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  getTags(){
    this.blogService.getTags().subscribe( response => {
      this.tag = [{id: 0, name: 'All'}, ...response];
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  getCategories(){
    this.blogService.getCategories().subscribe(response => {
      this.categories = [{id: 0, name: 'View All'}, ...response];
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  getAuthors(){
    this.blogService.getAuthors().subscribe(response => {
      this.authors = [{id: 0, name: 'View All'}, ...response];
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  onTagSelected(id: number) {
    this.blogParameters.tagId = id;
    this.blogParameters.pageNumber = 1;
    this.getPosts();
  }

  onAuthorSelected(id: number) {
    this.blogParameters.authorId = id;
    this.blogParameters.pageNumber = 1;
    this.getPosts();
  }

  onCategorySelected(id: number) {
    this.blogParameters.categoryId = id;
    this.blogParameters.pageNumber = 1;
    this.getPosts();
  }

  onSortSelected(value: any) {
    this.blogParameters.sort = value;
    this.getPosts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.blogParameters = new BlogParameters();
    this.getPosts();
  }

  onSearch() {
    this.blogParameters.search = this.searchTerm.nativeElement.value;
    this.blogParameters.pageNumber = 1;
    this.getPosts();
  }

  onPageChanged(event: any) {
    if (this.blogParameters.pageNumber !== event){
      this.blogParameters.pageNumber = event;
      this.getPosts();
    }
  }
}
