import React from 'react';
import { Route, Switch } from 'react-router-dom';
import { NetWorthCalc, About } from './components/pages';

const Routes = () => (
  <Switch>
    <Route exact path="/" component={NetWorthCalc} />
    <Route path="/about" component={About} />
  </Switch>
);

export default Routes;
