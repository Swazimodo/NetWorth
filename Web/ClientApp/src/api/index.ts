import axios from 'axios';
import CurrencyCalcApi from './currencyCalc';

const axiosInstance = axios.create({
    headers: { 'content-type': 'application/json' }
});

export default {
    CurrencyCalc: new CurrencyCalcApi(axiosInstance),
}
