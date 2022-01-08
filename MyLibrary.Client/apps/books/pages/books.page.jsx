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

  return (
    <div id="books-page">
      <div className="card-deck" style={{ width: "80%", marginLeft: "auto", marginRight: "auto" }}>
        {items.map(item => (
          <BookComponent key={item.id} book={item} />
        ))}
      </div>
    </div>
  );
};

export default BooksPage;
