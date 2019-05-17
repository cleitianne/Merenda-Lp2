<template>
 <!-- <h1>Aquququw</h1> -->
  
  <div class="card">
    <h5 class="card-header">Importação de dados legados</h5>
      <div class="card-body">
        <div class="container">
          <div class="row">
            <Imp class="t" titulo="Alunos" rota="Aluno"></Imp>
          </div>
        </div>
      </div>
  </div>
</template>

<script>
import Imp from './Import';

export default {
	data() {
		return {};
	},
	components: {
    Imp,
    
	},
	computed: {},

	methods: {},
};
</script>

<style lang="scss">
 .t {
   margin-left: -10px;
   margin-right: -10px;
   padding: 0px;
 }
</style>
