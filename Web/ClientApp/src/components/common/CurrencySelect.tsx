import React from 'react';
import { TextField, MenuItem } from '@material-ui/core';

export function CurrencySelect(props: { currencies: string[], currency: string, onChnage: (event: React.ChangeEvent<HTMLInputElement>) => void }) {
    return <TextField
        id="standard-select-currency"
        select
        label="Currency"
        value={props.currency}
        onChange={props.onChnage}
    >
        {props.currencies.map(option => (
            <MenuItem key={option} value={option}>
                {option}
            </MenuItem>
        ))}
    </TextField>;
}