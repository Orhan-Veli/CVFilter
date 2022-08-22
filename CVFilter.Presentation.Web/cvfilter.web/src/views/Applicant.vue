<template>
  <div class="container">
    <div class="row">
      <div class="col">
        <div class="row">
          <div class="col">
            <div class="panel panel-primary">
              <div class="panel-heading">
                <h3 class="panel-title">APPLICANT</h3>
                <div class="pull-right">
                  <span
                    class="clickable filter"
                    data-toggle="tooltip"
                    title="Toggle table filter"
                    data-container="body"
                  >
                    <i class="glyphicon glyphicon-filter"></i>
                  </span>
                </div>
              </div>
              <div class="panel-body">
                <input
                  type="text"
                  class="form-control"
                  id="dev-table-filter"
                  data-action="filter"
                  data-filters="#dev-table"
                  placeholder="Filter Developers"
                />
              </div>
              <table class="table" id="dev-table">
                <thead>
                  <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Matches</th>
                    <th>Path</th>
                    <th>Edit</th>
                    <th>Delete</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="applicant in applicants" :key="applicant.id">
                    <td>{{ applicant.id }}</td>
                    <td>{{ applicant.user }}</td>
                    <td>{{ applicant.matches }}</td>
                    <td>{{ applicant.path }}</td>
                    <td>
                      <button @Click="EditUser(applicant.id)">Edit</button>
                    </td>
                    <td>
                      <button @Click="DeleteUser(applicant.id)">Delete</button>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import router from "../router";
export default {
  name: "Applicant",
  props: [""],
  data() {
    return {
      applicants: [],
    };
  },
  components: {},
  created() {
    this.GetAllApplicant();
  },
  methods: {
    async GetAllApplicant() {
      const request = {
        User: "",
      };
      const requestOptions = {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(request),
      };
      await fetch("http://localhost:7000/applicant/getall", requestOptions)
        .then((response) => response.json())
        .then((res) => {
          this.applicants = res.data.getApplicantQueryResponses;
        })
        .catch((err) => alert(err));
    },
    EditUser(id) {
      router.push({ path: "/Edit", query: { Id: id } });
    },
    async DeleteUser(id) {
      const requestOptions = {
        method: "DELETE",
        mode: "cors",
        headers: { "Content-Type": "application/json" },
      };
      await fetch(
        "http://localhost:7000/applicant/delete?Id=" + id,
        requestOptions
      )
        .then((response) => {
          if (response.status != 204) {
            alert("There is an error! Check logs!");
            return;
          }
          window.location.reload();
        })
        .catch((err) => alert(err));
    },
  },
};
</script>
<style>
.row {
  padding: 0 10px;
}
.clickable {
  cursor: pointer;
}

.panel-heading div {
  margin-top: -18px;
  font-size: 15px;
}
.panel-body {
  display: none;
}
.panel-title {
  align-items: center;
  margin-bottom: 2%;
  margin-top: 2%;
}
.container {
  border: 10px solid #222;
  border-radius: 50px;
  background: white;
  margin: 20%;
}
</style>
