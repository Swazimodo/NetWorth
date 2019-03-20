import React, { useState } from 'react';
import { AddRosterRow } from './AddRosterRow';

import './NetWorthCalc.scss';
// import { } from '@material-ui/core';

export function NetWorthCalc() {
    const data = useTableRows();
    const assets = data.rows.filter(x => x.value >= 0);
    const liabilities = data.rows.filter(x => x.value < 0);

    return <div className="page">
        {AddRosterRow(data.handleAdd)}
        <div>Assets</div>
        {assets
            .map(x => x.title + x.value + x.currencyAbbrv)
            .join(", ")}
        <div>Liabilities</div>
        {liabilities
            .map(x => x.title + x.value + x.currencyAbbrv)
            .join(", ")}
    </div>;
}

interface IRosterRow {
    id: number;
    title: string;
    value: number;
    currencyAbbrv: string;
}

function useTableRows() {
    const [rows, setRows] = useState([] as IRosterRow[]);
    const [count, setCount] = useState(1);

    const handleValueUpdate = (id: number) => (event: React.ChangeEvent<HTMLInputElement>) => {
        const index = rows.findIndex(x => x.id === id);
        if (index > 0) {
            const arr = [...rows];
            arr[index].value = event.target.valueAsNumber;
        }
    }

    function handleDelete(id: number) {
        const arr = rows.filter(x => x.id !== id);
        setRows(arr);
    }

    function handleAdd(title: string, value: number, currencyAbbrv: string) {
        setCount(count => count + 1);
        setRows(arr => arr.concat([{
            id: count,
            title: title,
            value: value,
            currencyAbbrv: currencyAbbrv
        }]));
    }

    return {
        rows,
        handleAdd,
        handleDelete,
        handleValueUpdate
    };
}