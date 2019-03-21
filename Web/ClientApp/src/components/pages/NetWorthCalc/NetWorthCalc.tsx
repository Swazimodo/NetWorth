import React, { useState, useEffect } from 'react';
import { Typography, TextField } from '@material-ui/core';

import './NetWorthCalc.scss';
import api from '../../../api';
import { IRosterItem } from '../../../api/currencyCalc';
import { AddRosterRow } from './AddRosterRow';
import { RosterTable } from './RosterTable';
import { useTextField } from '../../common/fieldHooks';
import { CurrencySelect } from '../../common/CurrencySelect';

export function NetWorthCalc() {
    const [currencies, setCurrencies] = useState<string[]>(['CAD']);
    const data = useTableRows();
    const assets = data.rows.filter(x => x.value >= 0);
    const liabilities = data.rows.filter(x => x.value < 0);
    const targetCurrency = useTextField("CAD");
    const [netWorth, setNetWorth] = useState(0);

    useEffect(() => {
        api.CurrencyCalc.getCurrencies()
            .then(response => setCurrencies(response.data))
            .catch(error => console.error(error));
    }, [true]); // true will never change so this effect only will ever run once

    useEffect(() => {
        if (!targetCurrency.value || data.rows.length === 0) {
            return;
        }
        api.CurrencyCalc.calculateTotal({
            targetCurrencyAbbrv: targetCurrency.value,
            roster: data.rows.map(x => ({
                value: x.value,
                currencyAbbrv: x.currencyAbbrv
            }) as IRosterItem)
        })
            .then(response => setNetWorth(response.data))
            .catch(error => console.error(error));
    }, [data, targetCurrency]);

    return <div className="page net-worth-page">
        <AddRosterRow currencies={currencies} onCreate={data.handleAdd} />
        <div className="tables">
            <Typography className="table-title" variant="h6">Assets</Typography>
            <RosterTable data={assets} onUpdate={data.handleValueUpdate} onDelete={data.handleDelete} />
            <Typography className="table-title" variant="h6">Liabilities</Typography>
            <RosterTable data={liabilities} onUpdate={data.handleValueUpdate} onDelete={data.handleDelete} />
            <div className="net-worth-total">
                <TextField
                    label="Total"
                    value={netWorth}
                    margin="none"
                />
                <CurrencySelect currencies={currencies} currency={targetCurrency.value || ''} onChnage={targetCurrency.handleChange} />
            </div>
        </div>
    </div>;
}

export interface IRosterRow {
    id: number;
    title: string;
    value: number;
    currencyAbbrv: string;
}

function useTableRows() {
    const [rows, setRows] = useState([] as IRosterRow[]);
    const [count, setCount] = useState(0);
    let currentCount = count;

    const handleValueUpdate = (id: number, value: number) => {
        const index = rows.findIndex(x => x.id === id);
        if (index >= 0) {
            const arr = [...rows];
            arr[index].value = value;
            setRows(arr);
        }
    }

    function handleDelete(id: number) {
        const arr = rows.filter(x => x.id !== id);
        setRows(arr);
    }

    function handleAdd(title: string, value: number, currencyAbbrv: string) {
        setCount(++currentCount);
        const row = {
            id: currentCount,
            title: title,
            value: value,
            currencyAbbrv: currencyAbbrv
        }
        setRows(arr => arr.concat([row]));
    }

    return {
        rows,
        handleAdd,
        handleDelete,
        handleValueUpdate
    };
}