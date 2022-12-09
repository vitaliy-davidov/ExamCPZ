

class AppointmentService {
    API_URL = '/api/appointment';

    getAll() {
        return fetch(this.API_URL + '/all')
        .then((respond) => respond.json())
    }

    getById(id) {
        return fetch(this.API_URL + `/${id}`)
        .then((respond) => respond.json())
    }

    create(data) {
        return fetch(this.API_URL + `/create`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        }).then((respond) => console.log(respond))
    }

    update(id, data) {
        return fetch(this.API_URL + `/edit/${id}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        }).then((respond) => respond.json())
    }

    delete(id) {
        return fetch(this.API_URL + `/delete/${id}`, {
            method: 'DELETE',
        }).then((respond) => respond.json())
    }
} 

export default new AppointmentService();