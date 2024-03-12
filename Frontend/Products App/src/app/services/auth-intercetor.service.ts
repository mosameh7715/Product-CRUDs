import {
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';

export class AuthIntercetorService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = localStorage.getItem('userToken');
    const modifiedRequest = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` },
    });

    return next.handle(modifiedRequest);
  }
}
