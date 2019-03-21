import React from 'react';
import { Table, TableHead, TableBody, TableRow, TableCell, TextField, InputAdornment } from '@material-ui/core';
import { IRosterRow } from './NetWorthCalc';
import { useNumberField } from '../../common/fieldHooks';

export function RosterTable(props: { data: IRosterRow[], onUpdate: (id: number, value: number) => void, onDelete: (id: number) => void }) {
    return <div className="table">
        <Table>
            <TableHead>
                <TableRow>
                    <TableCell>Title</TableCell>
                    <TableCell>Value</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {props.data.map(row => <Row key={row.id} data={row} onUpdate={props.onUpdate} onDelete={props.onDelete} />)}
            </TableBody>
        </Table>
    </div>;
}

function Row(props: { data: IRosterRow, onUpdate: (id: number, value: number) => void, onDelete: (id: number) => void }) {
    const value = useNumberField(props.data.value);

    const handleBlur = () => {
        props.onUpdate(props.data.id, value.value || 0);
    }

    return <TableRow key={props.data.id}>
        <TableCell>{props.data.title}</TableCell>
        <TableCell>
            <TextField
                value={value.value}
                margin="none"
                onChange={value.handleChange}
                onBlur={handleBlur}
                InputProps={{
                    endAdornment: <InputAdornment
                        position="end"
                    >
                        {props.data.currencyAbbrv}
                    </InputAdornment>,
                }}
            />
        </TableCell>
    </TableRow>;
}