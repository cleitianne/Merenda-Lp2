<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="6" lg="3">
        <b-card no-body class="bg-warning">
          <b-card-body class="pb-0">
            <b-dropdown class="float-right" variant="transparent p-0" right>
              <template slot="button-content">
                <i class="icon-settings"></i>
              </template>
              <!-- <b-dropdown-item>Relatório Completo</b-dropdown-item>
              <b-dropdown-item>Relatório Parcial</b-dropdown-item> -->
            </b-dropdown>
            <h4 class="mb-0">{{qtdTecnico}}</h4>
            <p>Técnico</p>
          </b-card-body>
          <card-line3-chart-example chartId="card-chart-03" class="chart-wrapper" style="height:70px;" height="70"/>
        </b-card>
      </b-col>
      <b-col sm="6" lg="3">
        <b-card no-body class="bg-danger">
          <b-card-body class="pb-0">
            <b-dropdown class="float-right" variant="transparent p-0" right>
              <template slot="button-content">
                <i class="icon-settings"></i>
              </template>
              <!-- <b-dropdown-item>Relatório Completo</b-dropdown-item>
              <b-dropdown-item>Relatório Parcial</b-dropdown-item> -->
            </b-dropdown>
            <h4 class="mb-0">{{qtdSuperior}}</h4>
            <p>Superior</p>
          </b-card-body>
          <card-bar-chart-example chartId="card-chart-04" class="chart-wrapper px-3" style="height:70px;" height="70"/>
        </b-card>
      </b-col>
    </b-row>
    

    <b-card>
        <b-col sm="5">
          <h4 class="card-title mb-0">Lanche Ofertado</h4>
          <h4></h4>
        </b-col>
      <b-col sm="7" class="d-none d-md-block">
        <div v-if="lanche!==null">
          <div class="form-group row">
            <label class="col-sm-12 col-form-label">{{itemEstoque.descricao}}</label>
          </div>
          <div class="form-group row">
            <div class="col-sm-10">
              <b-button type="submit" size="sm" variant="primary" @click=" finalizarLanche()"><i class="fa fa-dot-circle-o"></i> Finalizar Lanche</b-button>
              
            </div>
          </div>
        </div>
        <div v-else>
          <div class="form-group row">
            <label class="col-sm-12 col-form-label">Não há lanche sendo ofertado!</label>
          </div>
        </div>
      </b-col>
    </b-card>



    <b-card v-if="lanche!==null">
        <b-col sm="5">
          <h4 class="card-title mb-0">Controle de Merenda Escolar</h4>
          <h4></h4>
        </b-col>
      <b-col sm="7" class="d-none d-md-block">
        <div class="form-group row">
          <label for="inputPassword3" class="col-sm-2 col-form-label">Matrícula</label>
          <div class="col-sm-10">
            <input type="text" class="form-control" id="inputPassword3" placeholder="Matrícula" v-model="matricula"  v-on:keyup.enter="confirmaLanche()">
          </div>
        </div>
        <div class="form-group row">
          <div class="col-sm-10">
            <b-button type="submit" size="sm" variant="primary" @click="confirmaLanche()"><i class="fa fa-dot-circle-o"></i> Enviar</b-button>
            <!-- <b-button type="reset" size="sm" variant="danger"><i class="fa fa-ban"></i> Cancelar</b-button> -->
          </div>
        </div>
      </b-col>
</b-card>

   
  </div>
</template>

<script>
import CardLine1ChartExample from './dashboard/CardLine1ChartExample'
import CardLine2ChartExample from './dashboard/CardLine2ChartExample'
import CardLine3ChartExample from './dashboard/CardLine3ChartExample'
import CardBarChartExample from './dashboard/CardBarChartExample'
import MainChartExample from './dashboard/MainChartExample'
import SocialBoxChartExample from './dashboard/SocialBoxChartExample'
import CalloutChartExample from './dashboard/CalloutChartExample'
import { Callout } from '@coreui/vue'
import Services from '../Services/services.js'
export default {
  name: 'dashboard',
  components: {
    Callout,
    CardLine1ChartExample,
    CardLine2ChartExample,
    CardLine3ChartExample,
    CardBarChartExample,
    MainChartExample,
    SocialBoxChartExample,
    CalloutChartExample
  },
  data: function () {
    return {
      selected: 'Month',
      matricula: null,
      itemEstoque: null,
      lanche: null,
      qtdTecnico: 0,
      qtdSuperior: 0,
      dataLanche: null,
      tableItems: [
        {
          avatar: { url: 'img/avatars/1.jpg', status: 'success' },
          user: { name: 'Yiorgos Avraamu', new: true, registered: 'Jan 1, 2015' },
          country: { name: 'USA', flag: 'us' },
          usage: { value: 50, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'Mastercard', icon: 'fa fa-cc-mastercard' },
          activity: '10 sec ago'
        },
        {
          avatar: { url: 'img/avatars/2.jpg', status: 'danger' },
          user: { name: 'Avram Tarasios', new: false, registered: 'Jan 1, 2015' },
          country: { name: 'Brazil', flag: 'br' },
          usage: { value: 22, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'Visa', icon: 'fa fa-cc-visa' },
          activity: '5 minutes ago'
        },
        {
          avatar: { url: 'img/avatars/3.jpg', status: 'warning' },
          user: { name: 'Quintin Ed', new: true, registered: 'Jan 1, 2015' },
          country: { name: 'India', flag: 'in' },
          usage: { value: 74, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'Stripe', icon: 'fa fa-cc-stripe' },
          activity: '1 hour ago'
        },
        {
          avatar: { url: 'img/avatars/4.jpg', status: '' },
          user: { name: 'Enéas Kwadwo', new: true, registered: 'Jan 1, 2015' },
          country: { name: 'France', flag: 'fr' },
          usage: { value: 98, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'PayPal', icon: 'fa fa-paypal' },
          activity: 'Last month'
        },
        {
          avatar: { url: 'img/avatars/5.jpg', status: 'success' },
          user: { name: 'Agapetus Tadeáš', new: true, registered: 'Jan 1, 2015' },
          country: { name: 'Spain', flag: 'es' },
          usage: { value: 22, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'Google Wallet', icon: 'fa fa-google-wallet' },
          activity: 'Last week'
        },
        {
          avatar: { url: 'img/avatars/6.jpg', status: 'danger' },
          user: { name: 'Friderik Dávid', new: true, registered: 'Jan 1, 2015' },
          country: { name: 'Poland', flag: 'pl' },
          usage: { value: 43, period: 'Jun 11, 2015 - Jul 10, 2015' },
          payment: { name: 'Amex', icon: 'fa fa-cc-amex' },
          activity: 'Last week'
        }
      ],
      tableFields: {
        avatar: {
          label: '<i class="icon-people"></i>',
          class: 'text-center'
        },
        user: {
          label: 'User'
        },
        country: {
          label: 'Country',
          class: 'text-center'
        },
        usage: {
          label: 'Usage'
        },
        payment: {
          label: 'Payment method',
          class: 'text-center'
        },
        activity: {
          label: 'Activity'
        }
      }
    }
  },
  methods: {
    variant (value) {
      let $variant
      if (value <= 25) {
        $variant = 'info'
      } else if (value > 25 && value <= 50) {
        $variant = 'success'
      } else if (value > 50 && value <= 75) {
        $variant = 'warning'
      } else if (value > 75 && value <= 100) {
        $variant = 'danger'
      }
      return $variant
    },
    flag (value) {
      return 'flag-icon flag-icon-' + value
    },
    getLacheOfertado () {
      
      let services = new Services('Lanche/atual', '', null, "Não há lanche sendo ofertado!").getAll()
      .then(result =>{
        
        this.lanche = result
       console.log('resultado', this.lanche)
        this.dataLanche = result.dia
        this.getNumeroDeAlunos()
        let estoqueService = new Services("Estoque").getById(this.lanche.coD_Estoque, "COD/")
                                .then(estoque =>{
                                  this.itemEstoque  = estoque
                                  console.log("Estoque", estoque)
                                   
                                })
         
      }).catch(err => {
        console.log("DEU RUIM",err);
        this.lanche = null
      })
    },

    confirmaLanche(){
      let filter = {
         AlunoMatricula: this.matricula,
         COD_Estoque: this.itemEstoque.cod,
         LancheId: this.lanche.id

      }

      let services = new Services('Lanche/aluno').getAll(filter, '', "Lanche registrado com sucesso", "Falha. Verifique sua matricula!").then(
        success => {
          
          this.getNumeroDeAlunos() 
          this.matricula = null
        },
        // error => {
        //   console.log('erro', error);
        // }
        
      )
    },
    finalizarLanche () {
      console.log('finalizando lanche', this.lanche)
      let lanche2 = {
        Id: this.lanche.id,
        Dia: this.lanche.dia,
        Turno: this.lanche.turno,
        COD_Estoque: this.lanche.coD_Estoque,
        Encerrado: true
      }
      let services = new Services('lanche').update(lanche2, this.lanche.id).then(
        success => {
          console.log('Lanche Finalizado', success)
          //this.getLacheOfertado()
          this.lanche = null 
        },
        error => {
          console.log('erro', error);
        }
        
      )
    },
    getNumeroDeAlunos () {
      let filterSup = {
        Dia: this.dataLanche,
        Nivel: 'Superior'
      }
      let services = new Services('AlunoLanche').getAll(filterSup, 'Count').then(
        success => {
          this.qtdSuperior = success 
        },
      )



       let filterTec = {
        Dia: this.dataLanche,
        Nivel: 'Tecnico'
      }
      let services2 = new Services('AlunoLanche').getAll(filterTec, 'Count').then(
        success => {
          this.qtdTecnico = success 
        },
      )
    }
    
  },

  created() {
   
    this.getLacheOfertado()
    
  },
  
}
</script>

<style>
  /* IE fix */
  #card-chart-01, #card-chart-02 {
    width: 100% !important;
  }
</style>