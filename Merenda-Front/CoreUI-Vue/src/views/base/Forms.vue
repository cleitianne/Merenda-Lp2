<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col md="12">
        <b-card>
          <div slot="header">
            <strong>Dados</strong> Alunos
          </div>
          <b-form>
          <b-form-group
            description="Nome"
            label="Nome"
            label-for="basicName"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='nome' id="basicName" type="text" autocomplete="name"></b-form-input>
          </b-form-group>
          <b-form-group
            description="Matrícula"
            label="Matrícula"
            label-for="basicName"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='matricula' id="basicName" type="text" autocomplete="name"></b-form-input>
          </b-form-group>
          <b-form-group
            label="Curso"
            label-for="basicSelect"
            :label-cols="3"
            :horizontal="true">
            <b-form-select v-model='curso' id="basicSelect"
              :plain="true"
              :options="['Selecionar', 'Superior', 'Técnico']"
              value="Selecionar">
            </b-form-select>
          </b-form-group>
          <div slot="footer">
            <b-button @click.stop.prevent="create()" type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i> Cadastrar</b-button>
            <b-button type="reset" size="sm" variant="danger"><i class="fa fa-ban"></i> Deletar</b-button>
          </div>
          </b-form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import Service from '../../Services/services.js'
export default {
  name: 'forms',
  props: ['data'],
  data () {
    return {
      selected: [], // Must be an array reference!
      show: true, nome:'', matricula:'', curso:''
    }
  },
  methods: {



    click () {
     
    },
    create (){
      
      let aluno = {
        Nome: this.nome,
        Matricula: this.matricula,
        Curso: this.curso
      }
      let services = new Service('aluno').create(aluno).then(
        success => {
          console.log('sucesso', success); 
        },
        error => {
          console.log('erro', error);
        }
        
      )
    }
  },
  created() {
    if(this.data==null || this.data==undefined){
      console.log('create')
    } else {
      console.log('update')
    }
  },
}
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>
