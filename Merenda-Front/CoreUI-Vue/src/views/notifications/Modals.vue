<template>
  <div class="wrapper">
    <div class="animated fadeIn">
      <b-row>
        <b-col cols="12">
          <b-card header="">
            <b-button type="button" variant="success" @click="successModal = true" class="mr-1">Técnico</b-button>
            <b-button type="button" variant="warning" @click="warningModal = true" class="mr-1">Superior</b-button>
          </b-card>
        </b-col><!--/.col-->
      </b-row><!--/.row-->
    </div>

    <!-- Modal Component -->
    <b-modal title="Modal title" v-model="myModal" @ok="myModal = false">
      
    </b-modal>
    <b-modal title="Modal title" size="lg" v-model="largeModal" @ok="largeModal = false">
      Também nada
    </b-modal>
    <b-modal title="Modal title" size="sm" v-model="smallModal" @ok="smallModal = false">
      Novamente nada
    </b-modal>

    <b-modal title="Técnico Integrado" class="modal-primary" v-model="primaryModal" @ok="primaryModal = false">
     Por enquanto nada
    </b-modal>
    <b-modal title="Técnico" class="modal-success" v-model="successModal" @ok="successModal = false" ok-variant="success">
      Também nada
    </b-modal>
    <b-modal title="Superior" class="modal-warning" v-model="warningModal" @ok="warningModal = false" ok-variant="warning">
    Novamente nada
    </b-modal>
    <b-modal title="Modal title" class="modal-danger" v-model="dangerModal" @ok="dangerModal = false" ok-variant="danger">
      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
      quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
      consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
      cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
      proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
    </b-modal>
    <b-modal title="Modal title" class="modal-info" v-model="infoModal" @ok="infoModal = false" ok-variant="info">
      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
      quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
      consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
      cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
      proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
    </b-modal>
  </div>

</template>

<script>
export default {
  name: 'modals',
  data () {
    return {
      myModal: false,
      largeModal: false,
      smallModal: false,
      primaryModal: false,
      successModal: false,
      warningModal: false,
      dangerModal: false,
      infoModal: false
    }
  }
}
</script>
