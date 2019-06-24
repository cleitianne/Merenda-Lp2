import axios from 'axios'
import toastr from 'toastr'





const baseUrl =  'http://10.80.50.3:49933/api/' //'http://200.17.32.23:49933/api/'  //'http://localhost:49933/api/' //'http://10.80.50.3:49933/api/'

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
  async getAll (filter = {}, sub = '', msg=null, msgErro=null) {
    let params = {
      params: filter
    }
    return axios
      .get(this.url + sub, params)
      .then(response => {
        if(msg !== null){
          console.log("toastrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr")
          toastr.success(msg)
        }
        return response.data
      })
      .catch(err => {
        if(msgErro!== null)
          toastr.error(msgErro);
        else
          toastr.error("Falha, verifique sua conexão!");
        console.log(err);
      })
  }

  async getById (id, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .get(this.url + sub + id)
        .then(res => {
          resolve(res.data)
        })
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
          console.log("recurso criado com sucesso!")
          toastr.success("Recurso criado com sucesso")
          resolve(res.data)
        })
        .catch(err => {
          reject(err)
        })
    })
  }

  async update (newObject, id, sub = '') {
    return new Promise((resolve, reject) => {
      axios
        .put(this.url + sub  + id, newObject)
        .then(res => {
          toastr.success("Recurso atualizado com sucesso!")
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

  async uploadCsv (csv, sub = '') {
    let config = {
      headers: {
        'Content-Type': 'text/csv'
      }
    }
    return new Promise((resolve, reject) => {
      axios
        .post(this.url + sub + 'import', csv, config)
        .then(res => {
          console.log(res)
          resolve(res.data)
          if (res.status === 200) {
          } else if (res.status === 400 || res.status === 404 || res.status === 500) {
          }
        })
        .catch(err => {
          console.log('ERROR', err.response)
          reject(err.response)

        })
    })
  }
}