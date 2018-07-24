import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MoviesService } from '../servises/movies.service';

@Component({
  selector: 'app-selected-movie',
  templateUrl: './selected-movie.component.html',
  styleUrls: ['./selected-movie.component.css']
})
export class SelectedMovieComponent implements OnInit {
  myMovie: Object

  constructor(private route: ActivatedRoute, private movieService: MoviesService) { }

  ngOnInit() {
    this.route.params.subscribe(data => {
      let id = data['id']
      this.movieService
        .getMovie(id)
        .subscribe(selectedMovie => {
          this.myMovie = selectedMovie
        })
    })
  }

}
