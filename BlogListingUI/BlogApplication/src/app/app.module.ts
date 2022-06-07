import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BlogPostsComponent } from './blogs/blog-posts/blog-posts.component';
import { BlogContentComponent } from './blogs/blog-content/blog-content.component';
import { TopicListComponent } from './blogs/topic-list/topic-list.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogPostsComponent,
    BlogContentComponent,
    TopicListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
