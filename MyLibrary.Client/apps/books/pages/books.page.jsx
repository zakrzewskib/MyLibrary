import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

// actions
import { BookActions } from "../store/books.store";

// components
import BookComponent from "../components/book.component";

const BooksPage = ({ ...props }) => {
  const dispatch = useDispatch();
  const { items } = useSelector(s => s.Books);

  useEffect(() => {
    dispatch(BookActions.GetBooks());
  }, []);

  console.log(items);

  return (
    <div id="books-page">
      <div className="card-deck">
        {items.map((item, idx) => (
          <BookComponent key={idx} book={item} />
        ))}
      </div>
    </div>
  );
};

export default BooksPage;
