import React from 'react';
import ReactDOM from 'react-dom';
import { AppDrawer } from '../../components/layout';

it('renders without crashing', () => {
  const div = document.createElement('div');
  ReactDOM.render(<AppDrawer />, div);
  ReactDOM.unmountComponentAtNode(div);
});
