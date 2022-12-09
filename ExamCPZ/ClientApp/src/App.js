import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppointmentPage from './components/apointment-page/AppointmentPage';
import { Layout } from './components/Layout';
import PatientPage from './components/patient-page/PatientPage';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          <Route path='/' index={true} element={<PatientPage/>}/>
          <Route path='/appointments' index={true} element={<AppointmentPage/>}/>
        </Routes>
      </Layout>
    );
  }
}
