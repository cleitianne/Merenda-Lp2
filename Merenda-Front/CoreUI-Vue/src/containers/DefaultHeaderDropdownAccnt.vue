<template>
  <AppHeaderDropdown right no-caret>
    <template slot="header">
      <!-- <img
        src="img/avatars/6.jpg"
        class="img-avatar"
        alt="admin@bootstrapmaster.com" /> -->
        <i class="icon-settings"></i>
    </template>\
    <template slot="dropdown">
      <b-dropdown-header tag="div" class="text-center"><strong>Conta</strong></b-dropdown-header>
      <b-dropdown-item><i class="fa fa-envelope-o" /> {{usuarioAtual}}
        <!-- <b-badge variant="success">{{ itemsCount }}</b-badge> -->
      </b-dropdown-item>
      <b-dropdown-header
        tag="div"
        class="text-center">
        <strong>Configurações</strong>
      </b-dropdown-header>
    
      <b-dropdown-item @click="loggout"><i class="fa fa-lock" /> Sair</b-dropdown-item>
    </template>
  </AppHeaderDropdown>
</template>

<script>
import { HeaderDropdown as AppHeaderDropdown } from '@coreui/vue'
import firebase from 'firebase'
export default {
  name: 'DefaultHeaderDropdownAccnt',
  components: {
    AppHeaderDropdown
  },
  data: () => {
    return { 
      itemsCount: 42,
      usuarioAtual: 'Junin'
    }
  },
  methods: {
    loggout: function() {
      console.log("Saindo")
      firebase.auth().signOut().then(() => {
        this.$router.replace('/pages/login')
      })
    },
    currentUser: function() {
      this.usuarioAtual = firebase.auth().currentUser.email
    }
  },
  created() {
    this.currentUser()
  }
}
</script>
