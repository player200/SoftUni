import {
    HttpResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
    HttpEventType,
    HttpErrorResponse
} from '@angular/common/http';
import { Injectable } from '@angular/core'
import { Observable, throwError } from 'rxjs'
import { tap, catchError } from 'rxjs/operators'
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private toastr: ToastrService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler)
        : Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(catchError((err: HttpErrorResponse) => {
                switch (err.status) {
                    case 401:
                        this.toastr.error(err.error.message, 'Warning!')
                        break
                    case 400:
                        const message = Object.keys(err.error.errors)
                            .map(e => err.error.errors[e])
                            .join('\n')
                        this.toastr.error(message, 'Warning!')
                        break
                }

                return throwError(err)
            }))
    }
}