import firebase from "firebase";

//<!-- The core Firebase JS SDK is always required and must be listed first -->
//<script src="https://www.gstatic.com/firebasejs/6.3.2/firebase-app.js"></script>


export default class FireBaseService {

    constructor() {
        // Your web app's Firebase configuration
        var config = {
            apiKey: "AIzaSyAxfhBKpjek1GRMiK561sQJ-izjVGRWYUw",
            authDomain: "merendaifce.firebaseapp.com",
            databaseURL: "https://merendaifce.firebaseio.com",
            projectId: "merendaifce",
            storageBucket: "",
            messagingSenderId: "910404201704",
            appId: "1:910404201704:web:aaa394e9282383bb"
        };
        // Initialize Firebase
        if (!firebase.apps.length) {
            firebase.initializeApp(config);
        }

    }

    async signInWithEmail(email, password) {
        return new Promise((resolve, reject) => {
            firebase
                .auth()
                .setPersistence(firebase.auth.Auth.Persistence.LOCAL)
                .then(function () {
                    firebase
                        .auth()
                        .signInWithEmailAndPassword(email, password)
                        .then(result => {
                            console.log("RESULT:", result);
                            resolve(result);
                        })
                        .catch(error => {
                            console.log("Error---Na funccao sigin", error);
                            reject(error);
                        });
                });
        });
    }


    async logout() {
        return new Promise((resolve, reject) => {
            firebase
                .auth()
                .signOut()
                .then(function () {
                    console.log("Logout");
                    resolve("Deslogado");
                })
                .catch(function (error) {
                    console.log("Falha logout");
                    reject(error);
                });
        });
    }



}