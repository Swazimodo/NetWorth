import React from 'react';
import { mount } from 'enzyme';
import { MemoryRouter } from 'react-router-dom';
import Routes from './../../Routes';
import { NetWorthCalc, About } from '../../components/pages';

describe('Routes', () => {
  it('default path should redirect to Home component', () => {
    const wrapper = mount(
      <MemoryRouter initialEntries={['/']} initialIndex={0}>
        <Routes />
      </MemoryRouter>,
    );
    expect(wrapper.find(NetWorthCalc)).toHaveLength(1);
  });

  it('/about path should redirect to About component', () => {
    const wrapper = mount(
      <MemoryRouter initialEntries={['/about']} initialIndex={0}>
        <Routes />
      </MemoryRouter>,
    );
    expect(wrapper.find(About)).toHaveLength(1);
  });
});
