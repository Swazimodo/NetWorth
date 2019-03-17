import { AxiosInstance } from 'axios';

export default class currencyCalc {

    constructor(private network: AxiosInstance) { }

    public updateLocation = (location: string) => {
        return this.network.post('/api/admin/location', { location });
    }

    public updateTimeZone = () => {
        return this.network.post('/api/admin/timezone', { currentTime: new Date() });
    }
}
