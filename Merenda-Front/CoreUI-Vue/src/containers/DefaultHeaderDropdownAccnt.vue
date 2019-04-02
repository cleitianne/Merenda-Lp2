<template>
  <AppHeaderDropdown right no-caret>
    <template slot="header">
      <img
        src="img/avatars/6.jpg"
        class="img-avatar"
        alt="admin@bootstrapmaster.com" />
    </template>\
    <template slot="dropdown">
      <b-dropdown-header tag="div" class="text-center"><strong>Conta</strong></b-dropdown-header>
      <b-dropdown-item><i class="fa fa-envelope-o" /> Mensagens
        <b-badge variant="success">{{ itemsCount }}</b-badge>
      </b-dropdown-item>
      <b-dropdown-header
        tag="div"
        class="text-center">
        <strong>Configurações</strong>
      </b-dropdown-header>
      <b-dropdown-item><i class="fa fa-user" /> Perfil</b-dropdown-item>
      <b-dropdown-divider />
      <b-dropdown-item><i class="fa fa-shield" /> Fechar Conta</b-dropdown-item>
      <b-dropdown-item><i class="fa fa-lock" /> Sair</b-dropdown-item>
    </template>
  </AppHeaderDropdown>
</template>

<script>
import { HeaderDropdown as AppHeaderDropdown } from '@coreui/vue'
export default {
  name: 'DefaultHeaderDropdownAccnt',
  components: {
    AppHeaderDropdown
  },
  data: () => {
    return { itemsCount: 42 }
  }
}
</script>
