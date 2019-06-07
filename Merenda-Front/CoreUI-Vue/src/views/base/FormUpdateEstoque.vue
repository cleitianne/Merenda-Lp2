<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col md="12">
        <b-form>
          <b-form-group
            description="Item"
            label="Item"
            label-for="basicItem"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.item' id="basicItem" type="text" autocomplete="Item"></b-form-input>
          </b-form-group>
          <b-form-group
            description="Codigo"
            label="Código"
            label-for="basicCodigo"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.cod' id="basicCodigo" type="number" autocomplete="Codigo"></b-form-input>
          </b-form-group>
          <b-form-group
            label="Descrição"
            label-for="basicDescricao"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.descricao' id="basicDescricao" type="text" autocomplete="Descricao"></b-form-input>
          </b-form-group>
          <b-form-group
            description="QtdUtilizada"
            label="Quantidade Utilizada"
            label-for="basicQtdUtilizada"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.qtdUtilizada' id="basicQtdUtilizada" type="number" autocomplete="QtdUtilizada"></b-form-input>
          </b-form-group>
          <b-form-group
            description="QtdEstoque"
            label="Quantidade em Estoque"
            label-for="basicQtdEstoque"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.qtdEstoque' id="basicQtdEstoque" type="number" autocomplete="QtdEstoque"></b-form-input>
          </b-form-group>
          <b-form-group
            description="Valor"
            label="Valor"
            label-for="basicValor"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='dto.valor' id="basicValor" type="text" autocomplete="Valor"></b-form-input>
          </b-form-group>
          <div slot="footer">
            <b-button @click.stop.prevent="update()" type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i>Editar</b-button>
            <b-button type="reset" size="sm" variant="danger"><i class="fa fa-ban"></i> Deletar</b-button>
          </div>
          </b-form>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import Service from '../../Services/services.js'
export default {
  name: 'formUpdate',
  props: ['dto'],
  data () {
    return {
      selected: [], // Must be an array reference!
      show: true, 
      data: new Date(), 
      turno:  '',
      COD_Estoque: '',
      Encerrado: false,
      descricao: '',
      lanche: {}
      
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
    update (){
      let Estoque = {
        Id: this.dto.id,
        Item: this.dto.item,
        COD: parseInt(this.dto.cod),
        QtdUtilizada: parseInt(this.dto.qtdUtilizada),
        QtdEstoque: parseInt(this.dto.qtdEstoque),
        Valor: parseFloat(this.dto.valor),
        Descricao: this.dto.descricao
      }
      console.log('Estoque', Estoque)
      let services = new Service('Estoque').update(Estoque,this.dto.id).then(
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

