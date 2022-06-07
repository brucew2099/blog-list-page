import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogContentComponent } from './blogs/blog-content/blog-content.component';
import { BlogPostsComponent } from './blogs/blog-posts/blog-posts.component';
import { TopicListComponent } from './blogs/topic-list/topic-list.component';

const routes: Routes = [
  {
    path: 'blog/posts',
    component: BlogPostsComponent
  },
  {
    path: 'blog/content',
    component: BlogContentComponent
  },
  {
    path: 'topic/list',
    component: TopicListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
