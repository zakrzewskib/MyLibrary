import { combineReducers } from "redux";
import Books from "./books.store";

const ApplicationReducer = combineReducers({
    Books,
});

export default ApplicationReducer;