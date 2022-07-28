<template>
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-pic js-tilt" data-tilt>
					<img src="../assets/MainPage/images/img-01.png" alt="IMG">
				</div>

				<form class="login100-form validate-form">
					<span class="login100-form-title">
						CV FILTER
					</span>

					<div class="wrap-input100">
						<input class="input100" type="text" ref="Path" name="path" placeholder="Path">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-download" aria-hidden="true"></i>
						</span>
					</div>

					<div class="wrap-input100">
						<input class="input100" type="text" ref="RequiredMatches" name="RequiredMatches" placeholder="Required">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-key" aria-hidden="true"></i>
						</span>
					</div>

          <div class="wrap-input100">
						<input class="input100" type="text" ref="LanguageMatches" name="LanguageMatches" placeholder="Required Langugage">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-key" aria-hidden="true"></i>
						</span>
					</div>

          <div class="wrap-input100">
						<input class="input100" type="text" ref="EducationMatches" name="EducationMatches" placeholder="Required School">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-key" aria-hidden="true"></i>
						</span>
					</div>

          <div class="wrap-input100">
						<input class="input100" type="number" ref="Experience" name="Experience" placeholder="Experience">
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-graduation-cap" aria-hidden="true"></i>
						</span>
					</div>
					
					<div class="container-login100-form-btn">
						<button type="button" @click="SendData()" class="login100-form-btn">
							Filter
						</button>
					</div>
				</form>
			</div>
		</div>
	</div>

</template>
<script>
import router from 'vue-router'
export default {
  name: "Home",
  components: {},
  props: [""],
  methods: {
    async SendData(){
      const request = {
        Path: this.$refs.Path.value,
        RequiredMatches: this.$refs.RequiredMatches.value,
        LanguageMatches: this.$refs.LanguageMatches.value,
        EducationMatches: this.$refs.EducationMatches.value,
        Experience: parseInt(this.$refs.Experience.value)
      }
      const requestOptions = {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json",},
        body: JSON.stringify(request)
      };
    await fetch('http://localhost:7000/cv',requestOptions)
    .then(response => {
		if(response.status == 201)
		{
			router.push({path: '/Applicant'});
		}
	})
    .catch((err) => alert(err))
    }
  },
  created()
  {
    // var scripts = [
    //   "../assets/MainPage/vendor/jquery/jquery-3.2.1.min.js",
    //   "../assets/MainPage/vendor/bootstrap/js/popper.js",
    //   "../assets/MainPage/vendor/bootstrap/js/bootstrap.min.js",
    //   "../assets/MainPage/vendor/select2/select2.min.js",
    //   "../assets/MainPage/vendor/tilt/tilt.jquery.min.js",
    //   "../assets/MainPage/js/main.js"
    // ];
    // scripts.forEach(script => {
    //   let tag = document.createElement("script");
    //   tag.setAttribute("src",script);
    //   document.head.appendChild(tag);
    // });
  }
};
</script>
<style scoped>
@import '../assets/MainPage/vendor/bootstrap/css/bootstrap.min.css';
@import '../assets/MainPage/fonts/font-awesome-4.7.0/css/font-awesome.min.css';
@import '../assets/MainPage/vendor/animate/animate.css';
@import '../assets/MainPage/vendor/css-hamburgers/hamburgers.min.css';
@import '../assets/MainPage/vendor/select2/select2.min.css';
@import '../assets/MainPage/css/util.css';
@import '../assets/MainPage/css/main.css';
</style>


