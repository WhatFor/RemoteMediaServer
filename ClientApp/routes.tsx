import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { AllTorrents } from './components/AllTorrents';
import { AddNew } from './components/AddNew';

export const routes = <Layout>
    <Route exact path='/' component={ AllTorrents } />
    <Route path='/add-new' component={ AddNew } />
</Layout>;
