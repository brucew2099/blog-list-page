import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Blog } from '../models/blogs.model';
import { Topic } from '../models/topics.model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor(private http: HttpClient) { }

  apiBaseUrl = environment.apiBaseUrl;
  id: string = "";
  blogs: Blog[] = [];
  topic: string = "";

  getAllBlogs(): Observable<Blog[]> {
    return this.http.get<Blog[]>(this.apiBaseUrl + '/api/Blogs');
  }

  getBlogByBlogId(id: string): Observable<Blog> {
    return this.http.get<Blog>(this.apiBaseUrl + '/api/Blogs/' + id);
  }

  getAllTopics(): Observable<Topic[]> {
    return this.http.get<Topic[]>(this.apiBaseUrl + '/blog/topics');
  }

  getBlogsByTopic(topic: string): Observable<Blog[]> {
    return this.http.get<Blog[]>(this.apiBaseUrl + '/blog/topics/' + topic + '/blogs');
  }
}
