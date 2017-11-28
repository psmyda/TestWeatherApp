import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { environment } from '../environments/environment';

@Injectable()
export class WeatherService {

  apiUrl = environment.apiUrl;
  
  constructor(private _http: Http) {}
   
  getWeather(country: string, city: string): Observable<Response>  {
    return this._http.get(this.apiUrl + '/weather/' + country + '/' + city)
    .map((response: Response) => {
      return response;
    });
   }
      

}
