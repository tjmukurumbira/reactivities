import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Header, Icon } from 'semantic-ui-react';

function App() {
  return (
    <div className="App">
       <Header as='h2' icon>
        <Icon name='settings' />
        Reactivities
        <Header.Subheader>
          Manage your account settings and set e-mail preferences.
        </Header.Subheader>
      </Header>
    </div>
  );
}

export default App;
