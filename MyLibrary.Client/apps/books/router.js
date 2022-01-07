import React from "react";
import { Switch, Route } from "react-router-dom";

import BooksPage from "./pages/books.page";

export const Router = props => {
  return (
    <Switch>
      <Route exact path={"/Book"} component={BooksPage} />
    </Switch>
  );
};
