<template>
  <b-row>
    <b-col cols="12" xl="6">
      <transition name="slide">
      <b-card :header="caption">
        <b-table :hover="hover" :striped="striped" :bordered="bordered" :small="small" :fixed="fixed" responsive="sm" :items="items" :fields="fields" :current-page="currentPage" :per-page="perPage" @row-clicked="rowClicked">
          <template slot="nome" slot-scope="data">
            <strong>{{data.item.nome}}</strong>
          </template>
          <template slot="matricula" slot-scope="data">
            <strong>{{data.item.matricula}}</strong>
          </template>
         <template slot="curso" slot-scope="data">
            <strong>{{data.item.curso}}</strong>
          </template>
        </b-table>
        <nav>
          <b-pagination size="sm" :total-rows="getRowCount(items)" :per-page="perPage" v-model="currentPage" prev-text="Anterior" next-text="Próximo" hide-goto-end-buttons/>
        </nav>
      </b-card>
      </transition>
    </b-col>
  </b-row>
</template>

<script>
import usersData from './UsersData'
import Services from '../../Services/services.js'
export default {
  name: 'Users',
  props: {
    caption: {
      type: String,
      default: 'Alunos'
    },
    hover: {
      type: Boolean,
      default: true
    },
    striped: {
      type: Boolean,
      default: true
    },
    bordered: {
      type: Boolean,
      default: false
    },
    small: {
      type: Boolean,
      default: false
    },
    fixed: {
      type: Boolean,
      default: false
    }
  },
  data: () => {
    return {
      items: usersData.filter((user) => user.id < 42),
      fields: [
        {key: 'nome'},
        {key: 'Matrícula'},
        {key: 'Curso'}
      ],
      currentPage: 1,
      perPage: 5,
      totalRows: 0
    }
  },
  computed: {
  },
  methods: {
    getAluno (){
      let services = new Services('aluno').getAll()
      .then(result =>{
        this.data = result
        console.log("sucesso:", result)
      })
    },
    getBadge (status) {
      return status === 'Active' ? 'success'
        : status === 'Inactive' ? 'secondary'
          : status === 'Pending' ? 'warning'
            : status === 'Banned' ? 'danger' : 'primary'
    },
    getRowCount (items) {
      return items.length
    },
    userLink (id) {
      return `users/${id.toString()}`
    },
    rowClicked (item) {
      const userLink = this.userLink(item.id)
      this.$router.push({path: userLink})
    }

  },
  mounted(){
    this.getAluno()
  },
}
</script>

<style scoped>
.card-body >>> table > tbody > tr > td {
  cursor: pointer;
}
</style>
