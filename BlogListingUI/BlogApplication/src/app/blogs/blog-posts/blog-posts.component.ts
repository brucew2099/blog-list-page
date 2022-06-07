import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Blog } from 'src/app/models/blogs.model';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-blog-posts',
  templateUrl: './blog-posts.component.html',
  styleUrls: ['./blog-posts.component.css']
})
export class BlogPostsComponent implements OnInit {

  constructor(private blogService: BlogService, private route:Router) { }

  blogs: Blog[] = [];
  show:boolean = false;
  topic: string = "";

  ngOnInit(): void {
    this.topic = this.blogService.topic;

    this.blogService.getBlogsByTopic(this.topic).subscribe(
      response => {
        this.blogs = response;
      }
    )
  }

  readMore(blogId: string) {
    this.blogService.id = blogId;
    this.route.navigate(['/blog/content']);
  }

}
