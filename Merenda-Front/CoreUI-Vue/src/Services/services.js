import axios from 'axios'
import toastr from 'toastr'





const baseUrl = 'http://localhost:49933/api/'

export default class ApiService {
  constructor (serviceName) {
    this.serviceName = serviceName
    if (serviceName != null && serviceName !== undefined) {
      this.url = baseUrl + this.serviceName + '/'
    } else {
      this.url = baseUrl + '/'
    }
    console.log('URLL: ', this.url)
  }

 

  // GetAll
  async getAll (filter = {}, sub = '') {
    let params = {
      params: filter
    }
    return axios
      .get(this.url + sub, params)
      .then(response => response.data)
      .catch(err => {
        console.log(err);
      })
  }

  async getById (id, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .get(this.url + sub + id)
        .then(res => resolve(res.data))
        .catch(err => {
          reject(err.response)
        })
    })
  }

  async create (newObject = {}, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .post(this.url + sub, newObject)
        .then(res => {
          toastr.success("Recurso criado com sucesso")
          resolve(res.data)
        })
        .catch(err => {
          reject(err.response)
        })
    })
  }

  async update (newObject, id, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .put(this.url + sub  + id, newObject)
        .then(res => {
          resolve(res.data)
        })
        .catch(err => {
          reject(err.response)
        })
    })
  }

  async delete (id, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .delete(this.url + sub + id)
        .then(res => {
          resolve(res.data)
        })
        .catch(err => {
          // if (err.response.data) {
           toastr.error("falha ao deletar")
          // } else {
          // }
          reject(err.response)
        })
    })
  }

  count () {}

  // async uploadCsv (csv, sub = '') {
  //   let config = {
  //     headers: {
  //       'Content-Type': 'text/csv'
  //     }
  //   }
  //   return new Promise((resolve, reject) => {
  //     axios
  //       .post(this.url + sub + '/import', csv, config)
  //       .then(res => {
  //         console.log(res)
  //         resolve(res.data)
  //         if (res.status === 200) {
  //         } else if (res.status === 400 || res.status === 404 || res.status === 500) {
  //         }
  //       })
  //       .catch(err => {
  //         console.log('ERROR', err.response)
  //         reject(err.response)

  //       })
  //   })
  // }
}