import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    forecasts: IWeatherForecast[];
    baseUrl = 'http://localhost:61110/';

    constructor(http: Http) {
        http.get(this.baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as IWeatherForecast[];
        }, error => console.error(error));
    }
}

interface IWeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
