import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Route, RouterModule } from '@angular/router'
import { FormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import { NavigationComponent } from './navigation/navigation.component';

import { MoviesService } from './servises/movies.service';
import { MovieComponent } from './movie/movie.component';
import { SelectedMovieComponent } from './selected-movie/selected-movie.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    NavigationComponent,
    MovieComponent,
    SelectedMovieComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: MoviesComponent },
      { path: 'movie/:id', component: SelectedMovieComponent }
    ]),
    FormsModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
