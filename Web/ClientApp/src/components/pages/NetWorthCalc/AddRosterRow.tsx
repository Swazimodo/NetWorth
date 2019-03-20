import React from 'react';
import { TextField, Fab } from '@material-ui/core';
import { useTextField, useNumberField } from '../../common/fieldHooks';


export function AddRosterRow(onCreate: (title: string, value: number, currencyAbbrv: string) => void) {
    const title = useTextField('');
    const equity = useNumberField();
    const liability = useNumberField();
    const currencyAbbrv = useTextField('CAD');

    function createIfValid() {
        if (!title.value || !currencyAbbrv.value) {
            return;
        }
        if (equity.value) {
            onCreate(title.value, equity.value, currencyAbbrv.value);
        }
        if (liability.value) {
            onCreate(title.value, liability.value, currencyAbbrv.value);
        }
        if (equity.value || liability.value) {
            title.setValue('');
            equity.setValue(undefined);
            liability.setValue(undefined);
        }
    }

    return <div id="add-roster-row">
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
            {/* <TextField
                id="standard-select-currency"
                select
                label="Select"
                className={classes.textField}
                value={this.state.currency}
                onChange={this.handleChange('currency')}
                SelectProps={{
                    MenuProps: {
                        className: classes.menu,
                    },
                }}
                helperText="Please select your currency"
                margin="normal"
            >
                {currencies.map(option => (
                    <MenuItem key={option.value} value={option.value}>
                        {option.label}
                    </MenuItem>
                ))}
            </TextField> */}
            <Fab
                onClick={createIfValid}
                color="primary"
            >
                +
            </Fab>
        </div>
    </div>;
}