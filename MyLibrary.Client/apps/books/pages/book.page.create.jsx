import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

// actions
import { BookActions } from "../store/books.store";

const BookCreatePage = ({ ...props }) => {
  return (
    <div>
      <h1>This is a create book page, maybe posting with axios would be easier to implement</h1>
    </div>
  );
};

export default BookCreatePage;
