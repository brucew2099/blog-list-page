import { Component, OnInit } from '@angular/core';
import { Blog } from 'src/app/models/blogs.model';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-blog-posts',
  templateUrl: './blog-posts.component.html',
  styleUrls: ['./blog-posts.component.css']
})
export class BlogPostsComponent implements OnInit {

  constructor(private blogService: BlogService) { }

  blogs: Blog[] = [];
  show:boolean = false;
  buttonName:any = "Read More";
  blogToShow: Blog = {
    blogId: "",
    title: "",
    shortDescription: "",
    authorName: "",
    topic: "",
    image: "",
    contents: "",
    publishedDate: new Date(),
  };

  ngOnInit(): void {
    this.blogService.getAllBlogs().subscribe(
      response => {
        this.blogs = response;
      }
    )
  }

  showAndHideContents(temp: Blog) {
    // this.show = !this.show;

    // if(this.show)
    //   this.buttonName = "Hide Contents";
    // else
    //   this.buttonName = "Read More";
    this.blogToShow = temp;
  }

}
