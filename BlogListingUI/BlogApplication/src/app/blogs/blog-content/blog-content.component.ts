import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Blog } from 'src/app/models/blogs.model';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-blog-content',
  templateUrl: './blog-content.component.html',
  styleUrls: ['./blog-content.component.css']
})
export class BlogContentComponent implements OnInit {

  constructor(private blogService: BlogService, private route:Router) { }

  blog: Blog = {
    blogId: "",
    title: "",
    shortDescription: "",
    authorName: "",
    topic: "",
    image: "",
    contents: "",
    publishedDate: new Date(),
  };

  id: string = "";

  ngOnInit(): void {
    this.id = this.blogService.id;

    this.blogService.getBlogByBlogId(this.id).subscribe(
      response => {
        this.blog = response;
      }
    )
  }

  backToBlogs() {
    this.route.navigate(['/blog/posts']);
  }

}
