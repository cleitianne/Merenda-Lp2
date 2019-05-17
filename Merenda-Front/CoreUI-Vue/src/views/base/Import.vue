<template>
  <div class="parametroImportacao">
    <div class="container">
      <form enctype="multipart/form-data">
        <div class="">
					<input :id="rota" type="file" @change="onFileChange" :name="uploadFieldName" accept=".csv" class="inputfile"  :disabled="isSaving">
					<label :for="rota" class="label-input"><i style="margin: 2px" class="fa fa-upload"></i><span>{{titulo}}</span></label>
				</div>
      </form>
		</div>
  </div>
</template>

<script>
import Service from '../../Services/services.js'
export default {
	data() {
		return {
			uploadError: null,
			currentStatus: null,
			uploadFieldName: 'Csv',
			fileinput: '',
		};
	},
	props: ['titulo', 'rota'],
	computed: {
		// isInitial() {
		// 	return this.currentStatus === STATUS_INITIAL;
		// },
		// isSaving() {
		// 	return this.currentStatus === STATUS_SAVING;
		// },
		// isSuccess() {
		// 	return this.currentStatus === STATUS_SUCCESS;
		// },
		// isFailed() {
		// 	return this.currentStatus === STATUS_FAILED;
		// },
	},

	methods: {
		reset() {
			// reset form to initial state
			//this.currentStatus = STATUS_INITIAL;
			this.fileinput = '';
			this.uploadError = null;
		},
		onFileChange(e) {
			console.log(e)
			var files = e.target.files || e.dataTransfer.files;
			if (!files.length) return;
			this.createInput(files[0]);
		},
		createInput(file) {
			var reader = new FileReader();
			var vm = this;
			reader.onload = e => {
				vm.fileinput = e.target.result;
				this.save();
			};
			reader.readAsText(file);
		},
		save() {
			let service = new Service('Aluno');
			//this.currentStatus = STATUS_SAVING;
			let promise = service.uploadCsv(this.fileinput);
			promise
				.then(
					success => {
						//this.fileinput = success;
						//this.currentStatus = STATUS_SUCCESS;
					},
					err => {
						//this.currentStatus = STATUS_FAILED;
					},
				);
		},
	},

	created() {
		console.log('created', this.rota);
		this.reset();
	},
};
</script>

<style lang="scss">
.inputfile {
	width: 0.1px;
	height: 0.1px;
	opacity: 0;
	overflow: hidden;
	position: absolute;
	z-index: -1;
}

.inputfile + .label-input {
    font-size: 1em;
    font-weight: 700;
    color: white;
    border-color: black;
	background-color: #20a8d8;
	border-radius: 4%;
	display: inline-block;
	padding: 5px;
}

.inputfile:focus + .label-input,
.inputfile + .label-input:hover {
    background-color: rgb(198, 208, 214);
}

.inputfile + .label-input {
	cursor: pointer; /* "hand" cursor */
}

.dropbox p {
	font-size: 1.2em;
	text-align: center;
	padding: 50px 0;
}

.sucess {
	color: #31708f;
}

.error {
	color: #a94442;
}

.loader {
	border: 5px solid #fdfbfb;
	/* Light grey */
	border-top: 5px solid #8979e2;
	/* Blue */
	border-radius: 50%;
	border-top: 5px solid #8979e2;
	border-bottom: 5px solid #8979e2;
	width: 50px;
	height: 50px;
	animation: spin 2s linear infinite;
}

.footer {
	position: absolute;
	bottom: 0;
	width: 100%;
}

@keyframes spin {
	0% {
		transform: rotate(0deg);
	}
	100% {
		transform: rotate(360deg);
	}
}
</style>
