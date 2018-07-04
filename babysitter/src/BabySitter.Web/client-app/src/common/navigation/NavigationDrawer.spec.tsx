import * as React from "react";
import {shallow} from "enzyme";
import {NavigationDrawer} from "./NavigationDrawer";
import { Link, MemoryRouter } from 'react-router-dom';

it('should show shifts and baby sitter links', () => {
    const navigationDrawer = shallow(<MemoryRouter><NavigationDrawer /></MemoryRouter>);
    const links = navigationDrawer.find(Link);
    expect(links.someWhere(l => l.text().includes('Sitters'))).toBe(true);
})