import React from "react";
import { Switch, Route } from "react-router-dom";

import BooksPage from "./pages/books.page";
import BookCreatePage from "./pages/book.page.create";

export const Router = props => {
  return (
    <Switch>
      <Route exact path={"/Book"} component={BooksPage} />
      <Route exact path={"/Book/Create/"} component={BookCreatePage} />
    </Switch>
  );
};
