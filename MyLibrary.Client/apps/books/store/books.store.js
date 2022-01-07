import Axios from "axios";

const SET_BOOKS = "Books.SET_BOOKS";

const InitialState = {
    items: [],
};

const reducer = (state = InitialState, action) => {
    const { type, data } = action;

    switch (type) {
        case SET_BOOKS:
            {
                return {
                    ...state,
                    items: data,
                };
            }
    }

    return state;
};

export default reducer;

export const BookActions = {
    GetBooks: () => {
        return async(dispatch, getState) => {
            const response = await Axios.get(`https://localhost:5001/book`);
            dispatch({
                type: SET_BOOKS,
                data: response.data,
            });
        };
    },
};