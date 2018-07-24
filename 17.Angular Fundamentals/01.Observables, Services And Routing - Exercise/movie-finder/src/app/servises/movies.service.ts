import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'

import { HttpClient } from '@angular/common/http';
import { Movies } from '../models/movies';

const apiKey = 'edcbd11ea4f19cca35aa6276567d7e9f';

@Injectable()
export class MoviesService {
    path: string = 'https://api.themoviedb.org/3/'
    popular: string = 'discover/movie?sort_by=popularity.desc'
    theathers: string = 'discover/movie?primary_release_data.gte=2014-09-15&primary_release_date.lte=2014-10-22'
    kids: string = 'discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc'
    drama: string = 'discover/movie?with_genres=18&sort_by=vote_average.desc&vote_count.gte=10'
    movie: string = 'movie/'
    authentication: string = '&api_key='
    movieAuth: string = '?api_key='
    search: string = 'search/movie?query='

    constructor(private httpClient: HttpClient) { }

    getPopular(): Observable<Movies> {
        return this.httpClient.get<Movies>(`${this.path}${this.popular}${this.authentication}${apiKey}`)
    }

    getTheathers(): Observable<Movies> {
        return this.httpClient.get<Movies>(`${this.path}${this.theathers}${this.authentication}${apiKey}`)
    }

    getKidsMovies(): Observable<Movies> {
        return this.httpClient.get<Movies>(`${this.path}${this.kids}${this.authentication}${apiKey}`)
    }

    getDrama(): Observable<Movies> {
        return this.httpClient.get<Movies>(`${this.path}${this.drama}${this.authentication}${apiKey}`)
    }

    getMovie(id) {
        return this.httpClient.get(`${this.path}${this.movie}${id}${this.movieAuth}${apiKey}`)
    }

    getSearched(searched) {
        return this.httpClient.get(`${this.path}${this.search}${searched}${this.authentication}${apiKey}`)
    }
}