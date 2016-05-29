


export class ZipcodeWeather {
    zipcode: string;
    city: string;
    state: string;
    latitude: number;
    longitude: number;
    historicalTemperatures: Array<HistoricalTemperature>;

    constructor() {
        this.historicalTemperatures = new Array<HistoricalTemperature>();
    }
}


export class HistoricalTemperature {
    date: Date;
    low: number;
    high: number;
}


// The mapper class is a technique to convert the 
//  raw json objects returned by the API into full
//  typescript-based instances. This is required when
//  the typescript class includes additional functionality
//
export class ZipcodeWeatherMapper {
    static fromObject(x: any): ZipcodeWeather {
        const result = new ZipcodeWeather();

        Object.assign(result, x);

        result.historicalTemperatures = HistoricalTemperatureMapper.fromArray(x.historicalTemperatures);

        return result;
    }
}


export class HistoricalTemperatureMapper {
    static fromObject(x: any): HistoricalTemperature {
        const result = new HistoricalTemperature();

        Object.assign(result, x);

        result.date = new Date(x.date);

        return result;
    }

    static fromArray(x: any[]): HistoricalTemperature[] {
        if (x === undefined || x === null) {
            return new Array<HistoricalTemperature>();
        }

        return x.map((i: any) => HistoricalTemperatureMapper.fromObject(i));
    }
}