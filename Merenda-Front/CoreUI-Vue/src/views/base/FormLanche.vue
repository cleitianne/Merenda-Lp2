<template>
  <div class="">

     <!-- public DateTime Dia { get; set; }
        public string Turno { get; set; }
        public int COD_Estoque { get; set; }

        public bool Encerrado { get; set; }
        -->
    <b-row>
      <b-col md="12">
          <b-form>
            <b-form-group
              description="Descrição do Lanche"
              label="Descrição do Lanche"
              label-for="desc"
              :label-cols="3"
              :horizontal="true">
              <b-form-input v-model='this.dto.descricao' id="desc" type="text" autocomplete=""></b-form-input>
            </b-form-group>
            <b-form-group
              description="Data"
              label="Data"
              label-for="data"
              :label-cols="3"
              :horizontal="true">
              <b-form-input v-model='nome' id="data" type="date" autocomplete=""></b-form-input>
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
            <div slot="footer">
              <b-button @click.stop.prevent="create()" type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i>Ofertar</b-button>
              
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
      data: new Date(), 
      turno:  '',
      COD_Estoque: '',
      Encerrado: false,
      descricao: ''
      
    }
  },
  watch: {
    dto: function(){
      console.log('Dados', this.dto)
       this.COD_Estoque = this.dto.cod
       this.descricao = this.dto.descricao
       
    }
  },
  methods: {



    click () {
     
    },
    create (){
      
      let lanche = {

        Dia: this.data,
        Turno: this.turno,
        COD_Estoque: this.COD_Estoque,
        Encerrado: this.Encerrado
      }
      let services = new Service('lanche').create(lanche).then(
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
