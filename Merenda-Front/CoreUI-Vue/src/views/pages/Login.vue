<template>
  <div class="app flex-row align-items-center">
    <div class="container">
      <b-row class="justify-content-center">
        <b-col md="8">
          <b-card-group>
            <b-card no-body class="p-4">
              <b-card-body>
                <b-form>
                  <h1>Login</h1>
                  <p class="text-muted">Entre com sua conta</p>
                  <b-input-group class="mb-3">
                    <b-input-group-prepend><b-input-group-text><i class="icon-user"></i></b-input-group-text></b-input-group-prepend>
                    <b-form-input type="email" class="form-control" placeholder="Email" autocomplete="username email" v-model="email" />
                  </b-input-group>
                  <b-input-group class="mb-4">
                    <b-input-group-prepend><b-input-group-text><i class="icon-lock"></i></b-input-group-text></b-input-group-prepend>
                    <b-form-input type="password" class="form-control" placeholder="Senha" autocomplete="current-password" v-model="password"/>
                  </b-input-group>
                  <b-row>
                    <b-col cols="6">
                      <b-button @click="login" variant="primary" class="px-4">Login</b-button>
                    </b-col>
                    
                  </b-row>
                </b-form>
              </b-card-body>
            </b-card>
            <!-- <b-card no-body class="text-white bg-primary py-5 d-md-down-none" style="width:44%">
              <b-card-body class="text-center">
                <div>
                  <h2>Sign up</h2>
                  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                  <b-button variant="primary" class="active mt-3">Register Now!</b-button>
                </div>
              </b-card-body>
            </b-card> -->
          </b-card-group>
        </b-col>
      </b-row>
    </div>
  </div>
</template>

<script>
import firebase from 'firebase'
export default {
  
  name: 'Login',
   data: function () {
    return {
      email: '',
      password: ''
    }
   },
  methods: {
    login: function () {
      firebase.auth().signInWithEmailAndPassword(this.email, this.password)
          .then((user) => {
            console.log("LOGGANDO....")
            this.$router.replace('/dashboard')
          },
          (err) => {
            alert('Verifique seu email e senha')
          });
     // this.$router.replace('/dashboard')
    }
  }
}
</script>
