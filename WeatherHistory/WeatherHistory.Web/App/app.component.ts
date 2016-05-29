import {Component} from "@angular/core";
import {Http, Headers, Response} from "@angular/http";

import {CHART_DIRECTIVES} from "ng2-charts/ng2-charts";

import {ZipcodeWeather, ZipcodeWeatherMapper, HistoricalTemperature} from "./zipcodeWeather.model";

@Component({
    selector: "my-weather-app",
    directives: [CHART_DIRECTIVES],
    //
    // By using the webpack raw-loader in the processing of .scss files we
    //  can use sass *and* Angular 2's view encapsulation together. Awesome!
    //
    styles: [require("./app.styles.scss")],
    //
    // By using the webpack html-loader we can leverage Visual Studio's intelli-sense
    //  for html files
    //
    template: require("./app.template.html")
})
export class AppComponent {
    zipcode: string;
    zipcodeWeather: ZipcodeWeather;
    errorMessage: string;

    loading = false;

    barChartOptions: any = {
        scaleShowVerticalLines: false,
        responsive: true
    };
    barChartType: string = 'bar';
    barChartLegend: boolean = true;
    barChartLabels: string[];
    barChartData: any[];

    constructor(
        private http: Http
    ) {
    }


    loadWeather() {
        this.errorMessage = undefined;
        this.zipcodeWeather = undefined;
        this.loading = true;

        // Make the API call using standard Angular 2
        //
        this.http
            .get(`/api/temperatures?zipcode=${this.zipcode}`, {
                headers: new Headers({
                    'Accept': '*/*'
                })
            })
            .subscribe(
            (response: Response) => {
                this.loading = false;
                this.zipcodeWeather = ZipcodeWeatherMapper.fromObject(response.json());

                // let's update the order of the temps regardless of how they came in
                //  from the API
                //
                this.zipcodeWeather.historicalTemperatures = this.zipcodeWeather.historicalTemperatures
                    .sort((a: HistoricalTemperature, b: HistoricalTemperature) => {
                        return a.date > b.date ? 1 : a.date < b.date ? -1 : 0;
                    });

                // Now map the response into the data we need for the chart
                //
                this.barChartLabels = this.zipcodeWeather.historicalTemperatures.map(x => x.date.getFullYear().toString());

                this.barChartData = [
                    {
                        data: this.zipcodeWeather.historicalTemperatures.map(x => x.high),
                        label: "High"
                    },
                    {
                        data: this.zipcodeWeather.historicalTemperatures.map(x => x.low),
                        label: "Low"
                    }
                ];
            },
            (error: Response) => {
                this.errorMessage = error.json().message;
                this.loading = false;
            });
    }
}