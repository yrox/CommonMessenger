import {CRUD} from './crudApi';
const resource = 'contacts';

function getAll() {
    return CRUD.getAll(resource);
}

function getAllOfType(type) {
    //TODO 
}