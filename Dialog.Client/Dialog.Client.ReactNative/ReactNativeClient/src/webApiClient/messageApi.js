import {CRUD} from './crudApi';
const resource = 'messages';

function getAll() {
    return CRUD.getAll(resource);
}

function getAllOfType(type) {
    //TODO 
}