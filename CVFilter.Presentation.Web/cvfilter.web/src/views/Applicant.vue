<template>
  <div class="container">
    	<div class="row">
			<div class="col-md-6">
				<div class="panel panel-primary">
					<div class="panel-heading">
						<h3 class="panel-title">APPLICANT</h3>
						<div class="pull-right">
							<span class="clickable filter" data-toggle="tooltip" title="Toggle table filter" data-container="body">
								<i class="glyphicon glyphicon-filter"></i>
							</span>
						</div>
					</div>
					<div class="panel-body">
						<input type="text" class="form-control" id="dev-table-filter" data-action="filter" data-filters="#dev-table" placeholder="Filter Developers" />
					</div>
					<table class="table" id="dev-table">
						<thead>
							<tr>
								<th>Id</th>
								<th>Name</th>
								<th>Email</th>
								<th>Phone</th>
                <th>Matches</th>
                <th>Language</th>
                <th>School</th>
				<th>Edit</th>
				<th>Delete</th>
							</tr>
						</thead>
						<tbody>
							<tr>
								<td>1</td>
								<td>Kilgore</td>
								<td>Trout</td>
								<td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
				<td><button OnClick="EditUser">Edit</button></td>
                <td><button OnClick="DeleteUser">Delete</button></td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
export default {
    name: "Applicant",
    props: [""],
    data(){
        return{

        }
    },
    components: {
        
    },
    methods: {
        EditUser(id){
		},
		async DeleteUser(id){
      const requestOptions = {
        method: "DELETE",
        mode: "cors",
        headers: { "Content-Type": "application/json",}
      };
    await fetch('http://localhost:7000/cv/getbyid?Id='+id,requestOptions)
    .then(response => {
		if(response.status != 200)
		{
			alert("There is an error! Check logs!");
		}
	})
    .catch((err) => alert(err))
    }
    }
}
</script>
<style>
	.row{
		    margin-top:40px;
		    padding: 0 10px;
		}
		.clickable{
		    cursor: pointer;   
		}

		.panel-heading div {
			margin-top: -18px;
			font-size: 15px;
		}
		.panel-heading div span{
			margin-left:5px;
		}
		.panel-body{
			display: none;
		}
    .panel-title{
      align-items: center;
	  margin-bottom: 5%;
	  margin-left: 80%;
    }
    .container{
      margin-left: 25%;
      margin-top: 5%;
      border: 10px solid #222;
      width: 50%;
      border-radius: 50px;
      background: white;
    }
</style>
