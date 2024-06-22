import React from 'react';
import logo from './logo.svg';
import './App.css';
import ComponentOne from './components/ComponentOne';
import Events from './components/Events';
import CounterApp from './components/Counter';

import Profile from './components/Lamar';
import ShoppingList from './components/ShoppingList';
import MyButton from './components/YouClickedMe';
import MyApp from './components/SeparateUpdateCounters';
import Board from './components/TicTacToe';

function App() {
  return (
    <div className='App'>
    <ComponentOne />
    <Events />
    <CounterApp />
    
    <Profile />
    <ShoppingList />
    <MyButton />
    <MyApp />
    <Board />
    </div>
  );
}

export default App;
