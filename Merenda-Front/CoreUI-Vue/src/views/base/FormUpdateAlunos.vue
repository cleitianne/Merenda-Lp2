<template>
  <div class="">
    <b-row>
      <b-col md="12">
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
            <b-button @click="update()" type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i> Atualizar</b-button>
            <b-button type="reset" size="sm" variant="danger"><i class="fa fa-ban"></i>Limpar</b-button>
          </div>
          </b-form>
        
      </b-col>
    </b-row>
  </div>
</template>

<script>
import Service from '../../Services/services.js'
export default {
  name: 'forms',
  props: ['dto'],
  data () {
    return {
      selected: [], // Must be an array reference!
      show: true, 
      nome:'', 
      matricula:'',
      curso:''
    }
  },
  watch: {
    dto: function(){
      console.log('Dados', this.dto)
       this.nome = this.dto.nome
       this.curso = this.dto.curso
       this.matricula = this.dto.matricula
    }
  },
  methods: {



    click () {
     
    },
    update (){
      
      let aluno = {
        Id: this.dto.id,
        Nome: this.nome,
        Matricula: this.matricula,
        Curso: this.curso
      }
      let services = new Service('aluno').update(aluno, this.dto.id).then(
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
