import React, { useState } from 'react';
import { Table, TableHead, TableBody, TableRow, TableCell } from '@material-ui/core';
import { Title } from '../layout';

interface IColumn {
    title: string;
    id: string;
    visible: boolean;
}

interface ITableProps {
    title?: string;
    columns: IColumn[];
    data: any[][];
};

export function useEditableTable(props: ITableProps) {



    return <div className="table">
        {props.title && Title(props.title)}
        <Table>
            <TableHead>
                <TableRow>
                    {props.columns
                        .filter(x => x.visible)
                        .map(x => HeaderCell)}
                </TableRow>
            </TableHead>
            <TableBody>
                {props.data.map(x => Row)}
            </TableBody>
        </Table>
    </div>;
}

function HeaderCell(props: IColumn, index: number) {
    return <TableCell>{props.title}</TableCell>;
}

interface ITableRow {

}

function Row(data: ITableRow, index: any) {

}