import { AxiosInstance } from 'axios';

export default class currencyCalc {

    constructor(private network: AxiosInstance) { }

    public getCurrencies = async () => {
        return await this.network.get<string[]>('/api/v1/CurrencyCalc');
    }

    public calculateTotal = async (request: ICalculateTotal) => {
        return await this.network.post<number>('/api/v1/CurrencyCalc', request);
    }
}

export interface ICalculateTotal {
    roster: IRosterItem[];
    targetCurrencyAbbrv: string;
}

export interface IRosterItem {
    value: number,
    currencyAbbrv: string
}