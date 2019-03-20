import { AxiosInstance } from 'axios';

export default class currencyCalc {

    constructor(private network: AxiosInstance) { }

    public getCurrencies = () => {
        return this.network.get<string[]>('/api/v1/CurrencyCal');
    }

    public calculateTotal = () => {
        return this.network.post<number>('/api/v1/CurrencyCal', {
            currentTime: new Date()
        });
    }
}
