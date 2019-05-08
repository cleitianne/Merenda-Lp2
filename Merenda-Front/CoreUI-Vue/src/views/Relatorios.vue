<template>
  <div class="col-sm-10">
      <b-button type="submit" size="sm" variant="primary" @click="printPdf()"><i class="fa fa-dot-circle-o"></i>Gerar Relatório</b-button>
  </div> 
</template>

<script>
import Services from '../Services/services.js'
import reportMixin from '../mixins/report'
export default {
  name: 'relatorios',
  mixins: [reportMixin],
  components: {
   
  },
  data: function () {
    return {
    }
  },
  methods: {
    printPdf(){
      // Configurações do Relatórios
      var title = 'Cursos da Instituição';
      var labels = ['Código', 'Nome'];
      var columns = ['codigo', 'nome'];
      var widths = ['auto', '*' ]
      var success = [{
         id: 1,
        codigo: "1223",
        nome: "BCC",
        dataInicio: "2018-01-18T13:00:00",
        dataTermino: "2018-01-18T13:00:00",
        gestorId: 1,
        nivelEnsinoId: 1
      }]
      this.buildPdfReport(success, labels, columns, widths, title);
      // var filter = {...this.filter};
      // filter.GetAll = true;
      // let promise = new Service().getAll(filter, 'filter');
      // promise.then(
        // success => {this.buildPdfReport(success, labels, columns, widths, title);},
        // err => {}
      // );
    },
  },

  created() {
    
  },
  
}
</script>

<style>
  
</style>