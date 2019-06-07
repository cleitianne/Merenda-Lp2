<template>
    <div>
      <div class="card">
        <div class="card-header">
          <h5>Estoque disponível</h5>
          <!--<div class="input-group ">-->
        </div>   
        <div class="card-body">
            <div class="table-responsive">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th scope="col">Código</th>
                    <th scope="col">Descrição</th>
                    <th scope="col">Quantidade em Estoque</th>

                    <th scope="col"><div class="text-center">Editar</div></th>  
                    <th scope="col"><div class="text-center">Ofertar</div></th>
                    
                    <!-- <th scope="col"><div class="text-center">Mais Informações</div></th> -->
                    
                  </tr>
                </thead>
                <tbody>
                  <tr v-if="estoque.length == 0">
                    <td colspan="3"
                        class="text-center font-italic">
                        <label> Nenhum registro foi cadastrado </label>
                      </td>
                  </tr>
                  <tr v-for="(row, index) in estoque"
                    :key="row.id">
                    
                    <td>{{row.cod}}</td>
                    <td>{{row.descricao}}</td>
                    <td>{{row.qtdEstoque}}</td>

                    <td>
                      <div class="text-center">
                        <a  style="" class="icon-pencil"
                            href="#/lanche"
                            @click="selectRow(index)"
                            v-b-modal.modal2>
                        </a>
                      </div>
                    </td>

                  <td>
                    <div class="text-center">
                      <a  style="" class="icon-plus"
                          href="#/lanche"
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
      <b-modal id="modal2" title="Editar estoque" size="lg" ok-title="Fechar" ok-only="">
          <ModalUpdateEstoque v-bind="{dto: dto}"></ModalUpdateEstoque>
      </b-modal>
    </div>


    <div>
      <b-modal id="modal1" title="Ofertar Lanche" size="lg" ok-title="Fechar" ok-only="">
          <ModalContent v-bind="{dto: dto}"></ModalContent>
      </b-modal>
    </div>


   

   </div>
 
   
</template>

<script>
//import usersData from './UsersData'
import Services from '../Services/services.js'
import ModalContent from './base/FormLanche'
import ModalUpdateEstoque from './base/FormUpdateEstoque'
export default {
  name: 'Users',
 
  data: () => {
    return {
      estoque: null,
      index: null,
      dto: null
    }
  },
  components:{
    ModalContent,
    ModalUpdateEstoque
  },

  computed: {
  },
  methods: {
    selectRow(index) {
      console.log('Index', index)
      this.index = index
      this.dto = this.estoque[this.index];
    },

    getAluno (){
      let services = new Services('estoque').getAll()
      .then(result =>{
        this.estoque = result
        console.log("sucesso: ", result)
         //console.log('alunos', this.alunos[0])
      })
     
    },
    getBadge (status) {
     
    },
    getRowCount (items) {
      
    },
    userLink (id) {
     
    },
    rowClicked (item) {
      
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

</style>