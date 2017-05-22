const baseUrl = 'smth/api/';
const headers = new Headers({
    'Accept': 'application/json',
    'Content-Type': 'application/json',
});

function CRUD() {
    return {
        getAll(resource) {
            fetch(`${baseUrl}${resource}`, {method: 'GET', headers: headers})
            .then(response => response)
            .catch(err =>{console.log(err)});
            },

        get(resource, id) {
            fetch(`${baseUrl}${resource}/${id}`, {method: 'GET', headers: headers})
            .then(response => response)
            .catch(err => {console.log(err)});;
        },

        insert(resource, item) {
            let body = JSON.stringify(item);
            let request = new Request(`${baseUrl}${resource}`, {
                method: 'POST',
                body: body,
                headers: headers
            });
            fetch(request);
        },

        update(resource, item) {
            let body = JSON.stringify(item);
            let request = new Request(`${baseUrl}${resource}`, {
                method: 'PUT',
                body: body,
                headers: headers
            });
            fetch(request);
        },

        remove(resource, id) {
            fetch(`${baseUrl}${resource}/${id}`, {method: 'DELETE', headers: headers})
            .then(response => response)
            .catch(err => {console.log(err)});;
        }
    }
}

export default CRUD;

