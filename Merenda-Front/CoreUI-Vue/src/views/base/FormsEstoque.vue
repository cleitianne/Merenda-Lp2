<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col md="12">
        <b-card>
          <div slot="header">
            <strong>Dados</strong> Estoque
          </div>
          <b-form>
          <b-form-group
            description="Item"
            label="Item"
            label-for="basicItem"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='Item' id="basicItem" type="text" autocomplete="Item"></b-form-input>
          </b-form-group>
          <b-form-group
            description="Codigo"
            label="Código"
            label-for="basicCodigo"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='Codigo' id="basicCodigo" type="number" autocomplete="Codigo"></b-form-input>
          </b-form-group>
          <b-form-group
            label="Descrição"
            label-for="basicDescricao"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='Descricao' id="basicDescricao" type="text" autocomplete="Descricao"></b-form-input>
          </b-form-group>
          <b-form-group
            description="QtdUtilizada"
            label="Quantidade Utilizada"
            label-for="basicQtdUtilizada"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='QtdUtilizada' id="basicQtdUtilizada" type="number" autocomplete="QtdUtilizada"></b-form-input>
          </b-form-group>
          <b-form-group
            description="QtdEstoque"
            label="Quantidade em Estoque"
            label-for="basicQtdEstoque"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='QtdEstoque' id="basicQtdEstoque" type="number" autocomplete="QtdEstoque"></b-form-input>
          </b-form-group>
          <b-form-group
            description="Valor"
            label="Valor"
            label-for="basicValor"
            :label-cols="3"
            :horizontal="true">
            <b-form-input v-model='Valor' id="basicValor" type="number" autocomplete="Valor"></b-form-input>
          </b-form-group>
          <div slot="footer">
            <b-button @click="create()" type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i> Cadastrar</b-button>
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
  data () {
    return {
      selected: [], // Must be an array reference!
      show: true, Item:'', Codigo: null, Descricao:'', QtdUtilizada: null, QtdEstoque: null, Valor:null
    }
  },
  methods: {



    click () {
     
    },
    create (){
      
      let Estoque = {
        Item: this.Item,
        COD: parseInt(this.Codigo),
        QtdUtilizada: parseInt(this.QtdUtilizada),
        QtdEstoque: parseInt(this.QtdEstoque),
        Valor: parseFloat(this.Valor),
        Descricao: this.Descricao
      }
      console.log('Estoque', Estoque)
      let services = new Service('Estoque').create(Estoque).then(
        success => {
          console.log('sucesso', success); 
        },
        error => {
          console.log('erro', error);
        }
        
      )
    }
  }
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
