import React from 'react';
import { BrowserRouter } from 'react-router-dom';

import Routes from './Routes';
import { TopBar, AppDrawer } from './components/layout';

const App = () => (
  <BrowserRouter>
    <main className="container">
      <TopBar />
      <AppDrawer />
      <Routes />
    </main>
  </BrowserRouter>
);

export default App;
