import React from 'react';
import { MemoryRouter, Route } from 'react-router-dom';

export const wrapWithRoute = (Component: any, path: string) => () => <Route path={path} component={Component} />;
