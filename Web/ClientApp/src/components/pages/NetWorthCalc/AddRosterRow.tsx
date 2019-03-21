import React from 'react';
import { TextField, Fab } from '@material-ui/core';
import { useTextField, useNumberField } from '../../common/fieldHooks';
import { CurrencySelect } from '../../common/CurrencySelect';


export function AddRosterRow(props: { onCreate: (title: string, value: number, currencyAbbrv: string) => void, currencies: string[] }) {
    const title = useTextField('');
    const equity = useNumberField();
    const liability = useNumberField();
    const currencyAbbrv = useTextField('CAD');

    function createIfValid() {
        if (!title.value || !currencyAbbrv.value) {
            return;
        }
        if (equity.value) {
            props.onCreate(title.value, equity.value, currencyAbbrv.value);
        }
        if (liability.value) {
            const value = liability.value < 0 ? liability.value : liability.value * -1;
            props.onCreate(title.value, value, currencyAbbrv.value);
        }
        if (equity.value || liability.value) {
            title.setValue('');
            equity.setValue(undefined);
            liability.setValue(undefined);
        }
    }

    return <div className="add-roster-row">
        <div className="inner">
            <TextField
                label="Title"
                value={title.value}
                onChange={title.handleChange}
            />
            <TextField
                label="Equity or positive balance"
                value={equity.value ? equity.value : ''}
                onChange={equity.handleChange}
            />
            <TextField
                label="Liability"
                value={liability.value ? liability.value : ''}
                onChange={liability.handleChange}
            />
            <CurrencySelect
                currencies={props.currencies}
                currency={currencyAbbrv.value || ''}
                onChnage={currencyAbbrv.handleChange}
            />
            <Fab
                onClick={createIfValid}
                color="primary"
            >
                +
            </Fab>
        </div>
    </div>;
}