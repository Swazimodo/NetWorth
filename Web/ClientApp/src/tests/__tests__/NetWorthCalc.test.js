import React from 'react';
import ReactDOM from 'react-dom';
import { NetWorthCalc } from '../../components/pages/NetWorthCalc';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<NetWorthCalc />, div);
  ReactDOM.unmountComponentAtNode(div);
});
