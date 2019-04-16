<template>
   <div>
     <div class="card">
        <div class="card-header">
          <h5>Lista de Alunos</h5>
          <!--<div class="input-group ">-->
        </div>   
        <div class="card-body">
            <div class="table-responsive">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th scope="col">Nome</th>
                    <th scope="col">Matricula</th>
                    <th scope="col">Curso</th>

                    <th scope="col"><div class="text-center">Edit</div></th>
                    
                    <!-- <th scope="col"><div class="text-center">Mais Informações</div></th> -->
                    
                  </tr>
                </thead>
                <tbody>
                  <tr v-if="alunos.length == 0">
                    <td colspan="3"
                        class="text-center font-italic">
                        <label> Nenhum registro foi cadastrado </label>
                      </td>
                  </tr>
                  <tr v-for="(row, index) in alunos"
                    :key="row.id">
                    
                    <td>{{row.nome}}</td>
                    <td>{{row.matricula}}</td>
                    <td>{{row.curso}}</td>

                    <td>
                    <div class="text-center">
                      <a  style="" class="fas fa-eye"
                          href="#/users"
                          @click="selectRow(index)"
                          v-b-modal.modal1>
                      </a>
                    </div>
                  </td>
                  </tr>
                </tbody>
              </table>
            </div>
        </div>
   </div>
    <div>
      <b-modal id="modal1" title="Atualizar Alunos" size="lg" ok-title="Fechar" ok-only="">
          <ModalContent v-bind="{dto: dto}"></ModalContent>
      </b-modal>
    </div>

   </div>
     
</template>

<script>
import usersData from './UsersData'
import Services from '../../Services/services.js'
import ModalContent from '../base/FormUpdateAlunos'
export default {
  name: 'Users',
  props: {
    caption: {
      type: String,
      default: 'Alunos'
    },
    hover: {
      type: Boolean,
      default: true
    },
    striped: {
      type: Boolean,
      default: true
    },
    bordered: {
      type: Boolean,
      default: false
    },
    small: {
      type: Boolean,
      default: false
    },
    fixed: {
      type: Boolean,
      default: false
    }
  },
  data: () => {
    return {
      alunos: null,
      dto: {},
      items: usersData.filter((user) => user.id < 42),
      fields: [
        {key: 'nome'},
        {key: 'Matrícula'},
        {key: 'Curso'}
      ],
      currentPage: 1,
      perPage: 5,
      totalRows: 0
    }
  },
  components:{
    ModalContent
  },

  computed: {
  },
  methods: {
    selectRow(index) {
      console.log('Index', index)
      this.index = index
      this.dto = this.alunos[this.index];
    },

    getAluno (){
      let services = new Services('aluno').getAll()
      .then(result =>{
        this.alunos = result
        console.log("sucesso: ", result)
         console.log('alunos', this.alunos[0])
      })
     
    },
    getBadge (status) {
      return status === 'Active' ? 'success'
        : status === 'Inactive' ? 'secondary'
          : status === 'Pending' ? 'warning'
            : status === 'Banned' ? 'danger' : 'primary'
    },
    getRowCount (items) {
      return items.length
    },
    userLink (id) {
      return `users/${id.toString()}`
    },
    rowClicked (item) {
      const userLink = this.userLink(item.id)
      this.$router.push({path: userLink})
    }

  },
  created() {
    
  },
  mounted(){
    this.getAluno()
  },
}
</script>

<style scoped>
.card-body >>> table > tbody > tr > td {
  cursor: pointer;
}
</style>
