import React from 'react';
import { BrowserRouter } from 'react-router-dom';

import Routes from './Routes';
import { TopBar, Footer } from './components/layout';

const App = () => (
  <BrowserRouter>
    <main>
      <TopBar />
      <Routes />
      <Footer />
    </main>
  </BrowserRouter>
);

export default App;
