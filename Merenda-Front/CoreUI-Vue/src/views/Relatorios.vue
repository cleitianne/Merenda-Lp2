<template>

  <div class="animated fadeIn">
    <b-row>
      <b-col md="12">
        <b-card>
          <div slot="header">
            Relatório de Merenda Escolar
          </div>
          <b-form>
            <b-form-group
              description="Data"
              label="Data"
              label-for="dia"
              :label-cols="3"
              :horizontal="true">
              <b-form-input v-model='data' id="data" type="date" autocomplete="" ></b-form-input>
            </b-form-group>
            <b-form-group
              label="Turno"
              label-for="turno"
              :label-cols="3"
              :horizontal="true">
              <b-form-select v-model='turno' id="turno"
                :plain="true"
                :options="['Selecionar', 'Manhã', 'Tarde', 'Noite']"
                value="Selecionar">
              </b-form-select>
            </b-form-group>

            <b-form-group
              label="Nível"
              label-for="nivel"
              :label-cols="3"
              :horizontal="true">
              <b-form-select v-model='nivel' id="nivel"
                :plain="true"
                :options="['Selecionar', 'Superior', 'Técnico']"
                value="Selecionar">
              </b-form-select>
            </b-form-group>


            <b-form-group
              label="Curso"
              label-for="basicSelect"
              :label-cols="3"
              :horizontal="true">
              <b-form-select v-model='curso' id="basicSelect"
                :plain="true"
                :options="['Selecionar', 'Bacharelado em Ciência da Computação', 'Bacharelado em Engenharia de Aquicultura',
                          'Licenciatura em Química', 'Tecnologia em Hotelaria', 'Técnico em Aquicultura', 'Técnico em Eventos',
                          'Técnico em Guia de Turismo', 'Técnico em Informática', 'Técnico em Petroquímica']"
                value="Selecionar">
              </b-form-select>
            </b-form-group>
            <div slot="footer">
            <b-button type="submit" size="sm" variant="primary" @click="printPdf()"><i class="fa fa-dot-circle-o"></i>Gerar Relatório</b-button>
            </div>
          </b-form>
        </b-card>
      </b-col>
    </b-row>
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
      data: new Date(),
      turno: null,
      curso: null, 
      nivel: null

    }
  },
  methods: {
    printPdf(){
      
      let filter = {
        Nivel: this.nivel,
        Turno: this.turno,
        Curso: this.curso,
        Dia: this.data
      }
      let services = new Services('AlunoLanche').getAll(filter, 'Relatorio')
        .then(result =>{
            console.log("Resultado", result)
            let services2 = new Services('AlunoLanche').getAll(filter, 'Valor')
                .then(valor => {
                    var title = 'Relatório de Merenda Escolar';
                    var labels = ['Aluno', 'Curso', 'Nível', "Codigo do lanche"];
                    var columns = ['nome', 'curso', 'nivel', 'coD_Estoque'];
                    var widths = ['auto', '*', '*', '*' ]
                    // var success = [{
                    //   id: 1,
                    //   codigo: "1223",
                    //   nome: "BCC",
                    //   gestorId: 1,
                    //   nivelEnsinoId: 1
                    // }]
                    this.buildPdfReport(result, labels, columns, widths, title, filter.Dia, valor);
                })
            
      
          console.log('Resultado', result);
        }).catch(err => {
          console.log("DEU RUIM", err);
        })
      // Configurações do Relatórios
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