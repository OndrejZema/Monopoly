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
import { GameEdit } from './scenes/gameEdit/GameEdit';
import { CardTypes } from './scenes/cardTypes/CardTypes';
import { FieldTypes } from './scenes/fieldTypes/FieldTypes';
import { CardTypeEdit } from './scenes/cardTypeEdit/CardTypeEdit';
import { FieldTypeEdit } from './scenes/fieldTypeEdit/FieldTypeEdit';
import { CardEdit } from './scenes/cardEdit/CardEdit';
import { Cards } from './scenes/cards/Cards';
import { Fields } from './scenes/fields/Fields';
import { FieldEdit } from './scenes/fieldEdit/FieldEdit';
import { Banknotes } from './scenes/banknotes/Banknotes';
import { BanknoteEdit } from './scenes/banknoteEdit/BanknoteEdit';
import { GlobalContextProvider } from './store/GlobalContextProvider';

function App() {
  return (
    <GlobalContextProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<CustomRoute> <Games /> </CustomRoute>}></Route>
          <Route path="/games/create" element={<CustomRoute> <GameEdit /> </CustomRoute>}></Route>
          <Route path="/card-types" element={<CustomRoute> <CardTypes /> </CustomRoute>}></Route>
          <Route path="/card-types/create" element={<CustomRoute> <CardTypeEdit /> </CustomRoute>}></Route>
          <Route path="/field-types" element={<CustomRoute> <FieldTypes /> </CustomRoute>}></Route>
          <Route path="/field-types/create" element={<CustomRoute> <FieldTypeEdit /> </CustomRoute>}></Route>
          <Route path="/cards" element={<CustomRoute> <Cards /> </CustomRoute>}></Route>
          <Route path="/cards/create" element={<CustomRoute> <CardEdit /> </CustomRoute>}></Route>
          <Route path="/fields" element={<CustomRoute> <Fields /> </CustomRoute>}></Route>
          <Route path="/fields/create" element={<CustomRoute> <FieldEdit /> </CustomRoute>}></Route>
          <Route path="/banknotes" element={<CustomRoute> <Banknotes /> </CustomRoute>}></Route>
          <Route path="/banknotes/create" element={<CustomRoute> <BanknoteEdit /> </CustomRoute>}></Route>
        </Routes>
      </BrowserRouter>

    </GlobalContextProvider>
  );
}

export default App;
