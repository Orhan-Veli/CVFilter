<template>
  <form class="form-config">
    <div class="form-row">
      <div class="form-group col-md-6">
        <label for="inputEmail4">User</label>
        <input
          type="text"
          class="form-control"
          v-model="applicant.user"
        />
        <input type="text" class="form-control" v-model="applicant.id" hidden />
      </div>
      <div class="form-group col-md-6">
        <label for="inputPassword4">Matches</label>
        <input
          type="text"
          class="form-control"
          v-model="applicant.matches"
        />
      </div>
    </div>
    <div class="form-group">
      <label for="inputAddress">Path</label>
      <input
        type="text"
        class="form-control"
        v-model="applicant.path"
      />
    </div>
    <div class="form-group">
      <label for="inputAddress2">PathText</label>
      <input type="text" class="form-control"/>
    </div>
    <button @click="UpdateApplicant()" type="submit" class="btn btn-primary">Sign in</button>
  </form>
</template>
<script>
import router from '../router'
export default {
  name: "Edit",
  props: [""],
  data() {
    return {
      applicant: {},
    };
  },
  components: {},
  created() {
    this.GetApplicant(this.$route.query.Id);
  },
  methods: {
    async GetApplicant(id) {
      const requestOptions = {
        method: "GET",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
      };
      await fetch(
        "http://localhost:7000/applicant/getbyid?Id=" + id,
        requestOptions
      )
        .then((response) => response.json())
        .then((res) => {
          if (res.status) {
            this.applicant = res.data;
            console.log(res.data);
          }
        })
        .catch((err) => alert(err));
    },
    async UpdateApplicant(){
      const request = {
        Id: this.applicant.id,
        Name: this.applicant.user,
        Matches: this.applicant.matches,
        Path: this.applicant.path
      }

      const requestOptions = {
        method: "PUT",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(request)
      };
      await fetch(
        "http://localhost:7000/applicant",
        requestOptions
      )
        .then((response) => {
          if (response.status == 200) {
            router.push({path:"/Applicant"})
          }
        })
        .catch((err) => alert(err));
    },
  },
};
</script>
<style>
.form-config {
  align-items: center;
  justify-content: center;
  width: 50%;
  margin-left: 25%;
  margin-top: 10%;
  border: 10px solid rgb(83, 183, 161);
  border-radius: 50px;
  background: rgb(142, 152, 226);
}
</style>