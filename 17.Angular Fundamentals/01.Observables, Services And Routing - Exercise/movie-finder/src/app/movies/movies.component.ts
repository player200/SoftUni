import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../servises/movies.service';
import { Movie } from '../models/movie';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  popular: Object
  theaters: Object
  kids: Object
  drama: Object
  selected: Object
  isSelected: boolean = false

  constructor(private moviesServise: MoviesService) { }

  search(myQuery) {
    this.moviesServise
      .getSearched(myQuery.search)
      .subscribe(data => {
        this.selected = data
        this.isSelected = true
      })
  }

  ngOnInit() {
    this.moviesServise
      .getPopular()
      .subscribe(data => {
        this.popular = data
      })

    this.moviesServise
      .getTheathers()
      .subscribe(data => {
        this.theaters = data
      })

    this.moviesServise
      .getKidsMovies()
      .subscribe(data => {
        this.kids = data
      })

    this.moviesServise
      .getDrama()
      .subscribe(data => {
        this.drama = data
      })
  }
}
