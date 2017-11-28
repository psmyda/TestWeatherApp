import { WeatherService } from './weather.service';
import { Component, OnInit } from '@angular/core';

import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  weather;
  err;
  loading: boolean;
  country = new FormControl('', [Validators.required]);
  city = new FormControl('', [Validators.required]);
  


  constructor(private _service: WeatherService){  }

  getWeather(){
    this.loading = true;
    this._service.getWeather(this.country.value, this.city.value)
    .subscribe(result => {
      if (result){
        this.loading = false;    
        this.weather = result.json();
      }
    }, 
    err => {
      this.loading = false;
      this.err = err.json();
    })
  }
}
