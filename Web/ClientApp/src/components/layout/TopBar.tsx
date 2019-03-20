import React from 'react';
import { AppBar, Toolbar, Typography } from '@material-ui/core';

export function TopBar() {
    return <AppBar
        position="static"
        color="primary"
    >
        <Toolbar>
            <Typography variant="h6" color="inherit">
                Net Worth Calculator
            </Typography>
        </Toolbar>
    </AppBar>;
}