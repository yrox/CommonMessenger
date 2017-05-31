import {CRUD} from './crudApi';
const resource = 'accounts';

function getAll() {
    return CRUD.getAll(resource);
}

function getAllOfType(type) {
    //TODO 
}

function get(id) {
    return CRUD.get(resource, id);
}

function post(item) {
    CRUD.insert(resource, item);
}

function update(item) {
    CRUD.update(resource, item);
}

function remove(id) {
    CRUD.remove(resource, id);
}