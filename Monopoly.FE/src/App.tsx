import React from 'react';
import './style/App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import {
  Routes,
  Route,
  BrowserRouter
} from "react-router-dom";
import { CustomRoute } from './components/CustomRoute';
import { Games } from './scenes/games/Games';

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<CustomRoute> <Games /> </CustomRoute>}></Route>
        </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
