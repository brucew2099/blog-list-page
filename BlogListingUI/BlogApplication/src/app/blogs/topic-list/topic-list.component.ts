import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Blog } from 'src/app/models/blogs.model';
import { Topic } from 'src/app/models/topics.model';
import { BlogService } from 'src/app/services/blog.service';

@Component({
  selector: 'app-topic-list',
  templateUrl: './topic-list.component.html',
  styleUrls: ['./topic-list.component.css']
})
export class TopicListComponent implements OnInit {

  topics: Topic[] = [];
  blogs: Blog[] = [];

  constructor(private blogService: BlogService, private router:Router) { }

  ngOnInit(): void {
    this.blogService.getAllTopics().subscribe(
      response => {
        this.topics = response;
      }
    )
  }

  clickOnTopic(topic: string) {
    this.blogService.topic = topic;
    this.router.navigate(['/blog/posts']);
  }

}
