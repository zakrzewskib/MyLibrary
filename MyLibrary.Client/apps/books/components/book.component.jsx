import React from "react";
import { useState } from "react";
import { Modal, CloseButton } from "react-bootstrap";
import { NavLink } from "react-router-dom";

const BookComponent = ({ book: { id, title, imageURL, authors }, ...props }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <div className="card" style={{ cursor: "pointer" }} onClick={handleShow}>
        <img className="card-image" style={{ height: "100%" }} src={imageURL} alt="Book image" />
      </div>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header className="justify-content-center">
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Modal.Body className="text-right">
          <div className="text-center">
            {authors.map(author => (
              <p key={author.id}>
                {author.name} {author.surname}
              </p>
            ))}
            <p>There would be publishing house</p>
          </div>
          <NavLink className="btn btn-primary" to={`Book/${id}`}>
            See details
          </NavLink>
        </Modal.Body>
      </Modal>
    </>
  );
};

export default BookComponent;
