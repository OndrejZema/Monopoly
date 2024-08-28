import React from "react";
import "./style/App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Routes, Route, BrowserRouter } from "react-router-dom";
import { CustomRoute } from "./components/CustomRoute";
import { Games } from "./scenes/games/Games";
import { GameEdit } from "./scenes/gameEdit/GameEdit";
import { CardTypes } from "./scenes/cardTypes/CardTypes";
import { FieldTypes } from "./scenes/fieldTypes/FieldTypes";
import { CardTypeEdit } from "./scenes/cardTypeEdit/CardTypeEdit";
import { FieldTypeEdit } from "./scenes/fieldTypeEdit/FieldTypeEdit";
import { CardEdit } from "./scenes/cardEdit/CardEdit";
import { Cards } from "./scenes/cards/Cards";
import { Fields } from "./scenes/fields/Fields";
import { FieldEdit } from "./scenes/fieldEdit/FieldEdit";
import { Banknotes } from "./scenes/banknotes/Banknotes";
import { BanknoteEdit } from "./scenes/banknoteEdit/BanknoteEdit";
import { GlobalContextProvider } from "./store/GlobalContextProvider";
import { NotificationsPanel } from "./components/NotificationsPanel";
import { ProtectedRoutes } from "./components/ProtectedRoute";
import { Login } from "./scenes/auth/Login";
import { Register } from "./scenes/auth/Register";

function App() {
  return (
    <GlobalContextProvider>
      <NotificationsPanel />
      <BrowserRouter>
        <Routes>
          <Route element={<ProtectedRoutes />}>
            <Route
              path="/"
              element={
                <CustomRoute>
                  {" "}
                  <Games />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/games/create"
              element={
                <CustomRoute>
                  {" "}
                  <GameEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/games/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <GameEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/games/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <GameEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>

            <Route
              path="/card-types"
              element={
                <CustomRoute>
                  {" "}
                  <CardTypes />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/card-types/create"
              element={
                <CustomRoute>
                  {" "}
                  <CardTypeEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/card-types/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <CardTypeEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/card-types/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <CardTypeEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>

            <Route
              path="/field-types"
              element={
                <CustomRoute>
                  {" "}
                  <FieldTypes />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/field-types/create"
              element={
                <CustomRoute>
                  {" "}
                  <FieldTypeEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/field-types/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <FieldTypeEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/field-types/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <FieldTypeEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>

            <Route
              path="/cards"
              element={
                <CustomRoute>
                  {" "}
                  <Cards />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/cards/create"
              element={
                <CustomRoute>
                  {" "}
                  <CardEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/cards/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <CardEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/cards/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <CardEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>

            <Route
              path="/fields"
              element={
                <CustomRoute>
                  {" "}
                  <Fields />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/fields/create"
              element={
                <CustomRoute>
                  {" "}
                  <FieldEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/fields/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <FieldEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/fields/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <FieldEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>

            <Route
              path="/banknotes"
              element={
                <CustomRoute>
                  {" "}
                  <Banknotes />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/banknotes/create"
              element={
                <CustomRoute>
                  {" "}
                  <BanknoteEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/banknotes/edit/:id"
              element={
                <CustomRoute>
                  {" "}
                  <BanknoteEdit />{" "}
                </CustomRoute>
              }
            ></Route>
            <Route
              path="/banknotes/clone/:id"
              element={
                <CustomRoute>
                  {" "}
                  <BanknoteEdit doClone={true} />{" "}
                </CustomRoute>
              }
            ></Route>
          </Route>
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </BrowserRouter>
    </GlobalContextProvider>
  );
}

export default App;
