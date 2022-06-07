import * as React from 'react';
import {Route} from 'react-router-dom';
import {Layout} from './components/Layout';
import {Home} from './components/Home';
import {FetchData} from './components/FetchData';
import {Counter} from './components/Counter';
import './custom.css'
import CreditForm from "./components/CreditForm";

export function App() {
    return (
        <Layout>
            <Route exact path='/' component={Home}/>
            <Route path='/counter' component={Counter}/>
            <Route path='/fetch-data' component={FetchData}/>
            <Route path='/pageCredit' component={CreditForm}/>
        </Layout>
    )
}