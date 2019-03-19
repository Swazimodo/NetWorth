import React from 'react';
import { TextField, Button } from '@material-ui/core';
import { useTextField, useNumberField } from '../../common/fieldHooks';


export function AddRosterRow(onCreate: () => void) {
    const title = useTextField('');
    const equity = useNumberField();
    const liability = useNumberField();

    function createIfValid() {
        if (title.value && (equity.value || liability.value)) {
            onCreate();
            title.setValue('');
            equity.setValue(undefined);
            liability.setValue(undefined);
        }
    }

    return <div id="add-roster-item">
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
        <Button
            onClick={createIfValid}
        >
            +
        </Button>
    </div>;
}