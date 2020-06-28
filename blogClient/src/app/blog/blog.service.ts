import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpParams} from '@angular/common/http';
import {ITag} from '../shared/models/postTag';
import {ICategory} from '../shared/models/postCategory';
import {IAuthor} from '../shared/models/postAuthor';
import {IPaging} from '../shared/models/paging';
import {BlogParameters} from '../shared/models/blogParameters';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  baseUrl = environment.ApiUrl;

  constructor(private httpClient: HttpClient) { }

  getPosts(blogParameters: BlogParameters){
    let params = new HttpParams();

    if (blogParameters.tagId !== 0){
      params = params.append('tagId', blogParameters.tagId.toString());
    }

    if (blogParameters.categoryId !== 0){
      params = params.append('categoryId', blogParameters.categoryId.toString());
    }

    if (blogParameters.authorId !== 0){
      params = params.append('authorId', blogParameters.authorId.toString());
    }

    if (blogParameters.search){
      params = params.append('search', blogParameters.search);
    }

    params = params.append('sort', blogParameters.sort);
    params = params.append('pageIndex', blogParameters.pageNumber.toString());
    params = params.append('sort', blogParameters.pageSize.toString());

    return this.httpClient.get<IPaging>(this.baseUrl + 'blog/', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getTags(){
    return this.httpClient.get<ITag[]>(this.baseUrl + 'blog/tags');
  }

  getCategories(){
    return this.httpClient.get<ICategory[]>(this.baseUrl + 'blog/categories');
  }

  getAuthors(){
    return this.httpClient.get<IAuthor[]>(this.baseUrl + 'blog/author');
  }
}
