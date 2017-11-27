import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class WeatherService {

  apiUrl = "http://localhost:62196/api/weather";

  constructor(private _http: Http) {}
   
  getWeather(country: string, city: string): Observable<Response>  {
    return this._http.get(this.apiUrl + '/' + country + '/' + city)
    .map((response: Response) => {
      return response;
    });
   }
      

}
